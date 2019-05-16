using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class AppendTests
	{
		[Fact]
		public Task AppendToEmpty()
			=> new string[0]
				.AsAsyncEnumerable()
				.Append("Hello")
				.Should()
				.BeEquivalentTo(new[] { "Hello" });

		[Fact]
		public Task AppendToNonEmpty()
			=> new[] { "A", "B", "C" }
				.AsAsyncEnumerable()
				.Append("Hello")
				.Should()
				.BeEquivalentTo(new[] { "A", "B", "C", "Hello" });

		[Fact]
		public Task AppendNull()
			=> new[] { "A", "B", "C" }
				.AsAsyncEnumerable()
				.Append(null)
				.Should()
				.BeEquivalentTo(new[] { "A", "B", "C", null });

		[Fact]
		public Task AppendTask()
			=> new[] { "A", "B", "C" }
				.AsAsyncEnumerable()
				.AppendAsync(Task.FromResult("D"))
				.Should()
				.BeEquivalentTo(new[] { "A", "B", "C", "D" });
	}
}
