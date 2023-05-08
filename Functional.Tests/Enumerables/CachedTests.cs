namespace Functional.Tests.AsyncEnumerables
{
	public class CachedTests
	{
		[Fact]
		public async Task EvaluatesOnlyOnceFromSingleThread()
		{
			int evaluationCount = 0;
			var collection = new[] { 1, 2, 3, 4, 5 };

			var enumerable = collection
				.AsAsyncEnumerable()
				.Do(_ => ++evaluationCount)
				.Cached();

			evaluationCount.Should().Be(0);
			await enumerable.Should().BeEquivalentTo(collection);
			evaluationCount.Should().Be(collection.Length);
			await enumerable.Should().BeEquivalentTo(collection);
			evaluationCount.Should().Be(collection.Length);
		}

		[Fact]
		public async Task EvaluatesOnlyOnceFromTwoParallelThreads()
		{
			int evaluationCount = 0;
			var collection = new[] { new TaskCompletionSource<int>(), new TaskCompletionSource<int>() };
			
			var semaphore = new SemaphoreSlim(0);

			var enumerable = collection
				.Do(_ => ++evaluationCount)
				.Do(_ => semaphore.Release())
				.SelectAsync(t => t.Task)
				.Cached();


			evaluationCount.Should().Be(0);
			var firstEvaluation = Task.Run(() => enumerable.Should().BeEquivalentTo(new[] { 1, 2 }));
			await semaphore.WaitAsync();
			evaluationCount.Should().Be(1);
			var secondEvaluation = Task.Run(() => enumerable.Should().BeEquivalentTo(new[] { 1, 2 }));
			collection[0].SetResult(1);
			await semaphore.WaitAsync();
			evaluationCount.Should().Be(2);
			collection[1].SetResult(2);
			await firstEvaluation;
			await secondEvaluation;
			evaluationCount.Should().Be(2);
		}

		[Theory]
		[InlineData(0, 5)]
		[InlineData(2, 5)]
		[InlineData(4, 5)]
		public async Task ExceptionThrowsAtCorrectStep(int exceptionIndex, int taskCount)
		{
			var exception = new Exception();

			var collection = Enumerable
				.Range(0, taskCount)
				.Select(_ => new TaskCompletionSource<int>())
				.ToArray();

			var semaphore = new SemaphoreSlim(0);

			var enumerable = collection
				.SelectAsync(t => t.Task)
				.Cached();

			var evaluations = Enumerable
				.Range(1, taskCount)
				.Select(i => enumerable.Take(i))
				.ToArray();

			for (int i = 0; i < exceptionIndex; ++i)
				collection[i].SetResult(i);

			collection[exceptionIndex].SetException(exception);

			for (int i = 0; i < taskCount; ++i)
			{
				if (i < exceptionIndex)
					await evaluations[i].Should().BeEquivalentTo(Enumerable.Range(0, i + 1));
				else
					(await Assert.ThrowsAsync<AggregateException>(() => evaluations[i].ToArray()))?.InnerException.Should().Be(exception);
			}
		}

		[Fact]
		public async Task SecondEvaluationThrowsAtCorrectIndex()
		{
			var exception = new Exception();

			var collection = new Task<int>[] { Task.FromResult(1), Task.FromResult(2), Task.FromException<int>(exception), Task.Delay(-1).ContinueWith(_ => 2) }
				.SelectAsync()
				.Cached();

			await collection.Take(2).Should().BeEquivalentTo(new[] { 1, 2 });
			await collection.Take(2).Should().BeEquivalentTo(new[] { 1, 2 });

			(await Assert.ThrowsAsync<AggregateException>(() => collection.ToArray()))?.InnerException.Should().Be(exception);
			(await Assert.ThrowsAsync<AggregateException>(() => collection.ToArray()))?.InnerException.Should().Be(exception);
		}

		[Fact]
		public async Task DisposeExceptionThrownOnFinalMoveNext()
		{
			var disposeCount = 0;
			var exception = new Exception();

			var collection = new ExceptionOnDisposeEnumerable(new[] { 1, 2, 3 }.AsAsyncEnumerable(), () => { ++disposeCount; return exception; }).Cached();

			await collection.Take(3).Should().BeEquivalentTo(new[] { 1, 2, 3 });

			(await Assert.ThrowsAsync<AggregateException>(() => collection.ToArray()))?.InnerException.Should().Be(exception);
			(await Assert.ThrowsAsync<AggregateException>(() => collection.ToArray()))?.InnerException.Should().Be(exception);

			await collection.Take(3).Should().BeEquivalentTo(new[] { 1, 2, 3 });

			disposeCount.Should().Be(1);
		}

		private class ExceptionOnDisposeEnumerable : IAsyncEnumerable<int>
		{
			private readonly IAsyncEnumerable<int> _enumerable;
			private readonly Func<Exception> _onDisposeException;

			public ExceptionOnDisposeEnumerable(IAsyncEnumerable<int> enumerable, Func<Exception> onDisposeException)
			{
				_enumerable = enumerable;
				_onDisposeException = onDisposeException;
			}

			public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
				=> new Enumerator(_enumerable.GetAsyncEnumerator(cancellationToken), _onDisposeException);

			private class Enumerator : IAsyncEnumerator<int>
			{
				private readonly IAsyncEnumerator<int> _enumerator;
				private readonly Func<Exception> _onDisposeException;

				public int Current => _enumerator.Current;

				public Enumerator(IAsyncEnumerator<int> enumerator, Func<Exception> onDisposeException)
				{
					_enumerator = enumerator;
					_onDisposeException = onDisposeException;
				}

				public async ValueTask DisposeAsync()
				{
					await _enumerator.DisposeAsync();
					throw _onDisposeException.Invoke();
				}

				public ValueTask<bool> MoveNextAsync()
					=> _enumerator.MoveNextAsync();
		}
		}
	}
}
