using FluentAssertions;
using System.Threading;

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
	}
}
