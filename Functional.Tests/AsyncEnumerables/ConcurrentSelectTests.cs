using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class ConcurrentSelectTests
	{
		[Fact]
		public async Task AllSelectsAreInvokedImmediately()
		{
			var tasks = new[]
			{
				new TaskCompletionSource<int>(),
				new TaskCompletionSource<int>(),
				new TaskCompletionSource<int>()
			};

			int count = 0;

			var results = AsyncEnumerable
				.Create(new[] { 1, 2, 3 })
				.ConcurrentSelectAsync(i => tasks[count++].Task)
				.AsEnumerable();

			count.Should().Be(3);

			results.IsCompleted.Should().BeFalse();

			foreach (var task in tasks)
				task.SetResult(++count);

			(await results)
				.Should()
				.BeEquivalentTo(new[] { 4, 5, 6 });
		}

		[Fact]
		public async Task ExceptionDuringSelectHandledOnAwait()
		{
			var exception = new TestException();

			var results = AsyncEnumerable
				.Create(new[] { 1, 2, 3 })
				.ConcurrentSelectAsync<int, int>(i => throw exception)
				.AsEnumerable();

			(await Assert.ThrowsAsync<AggregateException>(() => results))
				.InnerExceptions
				.Should()
				.Equal(new[] { exception });
		}

		[Fact]
		public async Task ExceptionInSelectedTaskHandledOnAwait()
		{
			var tasks = new[]
			{
				new TaskCompletionSource<int>(),
				new TaskCompletionSource<int>(),
				new TaskCompletionSource<int>()
			};

			int count = 0;

			var results = AsyncEnumerable
				.Create(new[] { 1, 2, 3 })
				.ConcurrentSelectAsync(i => tasks[count++].Task)
				.AsEnumerable();

			var exceptions = tasks.Select(_ => new TestException()).ToArray();

			for (int i = 0; i < tasks.Length; ++i)
				tasks[i].SetException(exceptions[i]);

			(await Assert.ThrowsAsync<AggregateException>(() => results))
				.InnerExceptions
				.Should()
				.Equal(exceptions);
		}

		[Fact]
		public async Task ExceptionInSelectAndAwait()
		{
			var exception = new TestException();

			var tasks = new[]
			{
				new TaskCompletionSource<int>(),
				new TaskCompletionSource<int>()
			};

			int count = 0;

			var results = AsyncEnumerable
				.Create(new[] { 1, 2, 3 })
				.ConcurrentSelectAsync(i => i == 3 ? throw exception : tasks[count++].Task)
				.AsEnumerable();

			var exceptions = tasks.Select(_ => new TestException()).ToArray();

			for (int i = 0; i < tasks.Length; ++i)
				tasks[i].SetException(exceptions[i]);

			(await Assert.ThrowsAsync<AggregateException>(() => results))
				.InnerExceptions
				.Should()
				.Equal(Enumerable.Repeat(exception, 1).Concat(exceptions));
		}
	}
}
