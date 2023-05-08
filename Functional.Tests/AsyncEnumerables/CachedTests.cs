namespace Functional.Tests.Enumerables
{
	public class CachedTests
	{
		[Fact]
		public void EvaluatesOnlyOnceFromSingleThread()
		{
			int evaluationCount = 0;
			var collection = new[] { 1, 2, 3, 4, 5 };

			var enumerable = collection
				.Do(_ => ++evaluationCount)
				.Cached();

			evaluationCount.Should().Be(0);
			enumerable.Should().BeEquivalentTo(collection);
			evaluationCount.Should().Be(collection.Length);
			enumerable.Should().BeEquivalentTo(collection);
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
				.Select(t => t.Task.Result)
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
		public void ExceptionThrowsAtCorrectStep(int exceptionIndex, int taskCount)
		{
			var exception = new Exception();

			var collection = Enumerable
				.Range(0, taskCount)
				.Select(_ => new TaskCompletionSource<int>())
				.ToArray();

			var semaphore = new SemaphoreSlim(0);

			var enumerable = collection
				.Select(t => t.Task.Result)
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
				if (i < exceptionIndex)
					evaluations[i].Should().BeEquivalentTo(Enumerable.Range(0, i + 1));
				else
					(Assert.Throws<AggregateException>(() => evaluations[i].ToArray()).InnerException as AggregateException).InnerException.Should().Be(exception);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
			}
		}

		[Fact]
		public void SecondEvaluationThrowsAtCorrectIndex()
		{
			var exception = new Exception();

			var collection = new Task<int>[] { Task.FromResult(1), Task.FromResult(2), Task.FromException<int>(exception), Task.Delay(-1).ContinueWith(_ => 2) }
				.Select(t => t.Result)
				.Cached();

			collection.Take(2).Should().BeEquivalentTo(new[] { 1, 2 });
			collection.Take(2).Should().BeEquivalentTo(new[] { 1, 2 });

#pragma warning disable CS8602 // Dereference of a possibly null reference.
			(Assert.Throws<AggregateException>(() => collection.ToArray()).InnerException as AggregateException).InnerException.Should().Be(exception);
			(Assert.Throws<AggregateException>(() => collection.ToArray()).InnerException as AggregateException).InnerException.Should().Be(exception);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
		}

		[Fact]
		public void DisposeExceptionThrownOnFinalMoveNext()
		{
			var disposeCount = 0;
			var exception = new Exception();

			var collection = new ExceptionOnDisposeEnumerable(new[] { 1, 2, 3 }, () => { ++disposeCount; return exception; }).Cached();

			collection.Take(3).Should().BeEquivalentTo(new[] { 1, 2, 3 });

			Assert.Throws<AggregateException>(() => collection.ToArray())?.InnerException.Should().Be(exception);
			Assert.Throws<AggregateException>(() => collection.ToArray())?.InnerException.Should().Be(exception);

			collection.Take(3).Should().BeEquivalentTo(new[] { 1, 2, 3 });

			disposeCount.Should().Be(1);
		}

		private class ExceptionOnDisposeEnumerable : IEnumerable<int>
		{
			private readonly IEnumerable<int> _enumerable;
			private readonly Func<Exception> _onDisposeException;

			public ExceptionOnDisposeEnumerable(IEnumerable<int> enumerable, Func<Exception> onDisposeException)
			{
				_enumerable = enumerable;
				_onDisposeException = onDisposeException;
			}

			public IEnumerator<int> GetEnumerator()
				=> new Enumerator(_enumerable.GetEnumerator(), _onDisposeException);

			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();

			private class Enumerator : IEnumerator<int>
			{
				private readonly IEnumerator<int> _enumerator;
				private readonly Func<Exception> _onDisposeException;

				public int Current => _enumerator.Current;

				object IEnumerator.Current => Current;

				public Enumerator(IEnumerator<int> enumerator, Func<Exception> onDisposeException)
				{
					_enumerator = enumerator;
					_onDisposeException = onDisposeException;
				}

				public void Dispose()
				{
					_enumerator.Dispose();
					throw _onDisposeException.Invoke();
				}

				public bool MoveNext()
					=> _enumerator.MoveNext();

				public void Reset() 
					=> throw new NotSupportedException();
			}
		}
	}
}
