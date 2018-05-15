using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class SelectTests
    {
		[Fact]
		public async Task SelectIndex()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Select((_, index) => index)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 0, 1, 2 });

		[Fact]
		public async Task SelectCompletedTask()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Select(value => value * 10)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 10, 20, 30 });

		[Fact]
		public async Task SelectNonCompletedTask()
		{
			var task = new TaskCompletionSource<IEnumerable<int>>();

			var result = AsyncEnumerable
				.Create(task.Task)
				.Select(value => value * 10)
				.AsEnumerable();

			task.SetResult(new int[] { 1, 2, 3 });

			(await result)
				.Should()
				.BeEquivalentTo(new[] { 10, 20, 30 });
		}
	}
}
