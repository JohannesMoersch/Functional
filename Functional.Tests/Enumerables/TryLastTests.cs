using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class TryLastTests
	{
		public class WhenEnumerable
		{
			private readonly IEnumerable<int> _empty = Enumerable.Empty<int>();
			private readonly IEnumerable<int> _notEmpty = new[] { 1, 2, 3, 4 };

			[Fact]
			public void TryLastWhenEmpty()
				=> _empty
					.TryLast()
					.AssertNone();

			[Fact]
			public void TryLastWhenNotEmpty()
				=> _notEmpty
					.TryLast()
					.AssertSome()
					.Should()
					.Be(4);

			[Fact]
			public void TryLastWithPredicateWhenEmpty()
				=> _empty
					.TryLast(_ => true)
					.AssertNone();

			[Fact]
			public void TryLastWithPredicateWithNoMatch()
				=> _notEmpty
					.TryLast(_ => false)
					.AssertNone();

			[Fact]
			public void TryLastWithPredicateWithMatch()
				=> _notEmpty
					.TryLast(i => i == 2 || i == 3)
					.AssertSome()
					.Should()
					.Be(3);

			[Fact]
			public Task TryLastAsyncWithPredicateWhenEmpty()
				=> _empty
					.TryLastAsync(_ => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task TryLastAsyncWithPredicateWithNoMatch()
				=> _notEmpty
					.TryLastAsync(_ => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task TryLastAsyncWithPredicateWithMatch()
				=> _notEmpty
					.TryLastAsync(i => Task.FromResult(i == 2 || i == 3))
					.AssertSome()
					.Should()
					.Be(3);
		}

		public class WhenTaskOfEnumerable
		{
			private readonly Task<IEnumerable<int>> _empty = Task.FromResult(Enumerable.Empty<int>());
			private readonly Task<IEnumerable<int>> _notEmpty = Task.FromResult(new[] { 1, 2, 3, 4 }.AsEnumerable());

			[Fact]
			public Task TryLastWhenEmpty()
				=> _empty
					.TryLast()
					.AssertNone();

			[Fact]
			public Task TryLastWhenNotEmpty()
				=> _notEmpty
					.TryLast()
					.AssertSome()
					.Should()
					.Be(4);

			[Fact]
			public Task TryLastWithPredicateWhenEmpty()
				=> _empty
					.TryLast(_ => true)
					.AssertNone();

			[Fact]
			public Task TryLastWithPredicateWithNoMatch()
				=> _notEmpty
					.TryLast(_ => false)
					.AssertNone();

			[Fact]
			public Task TryLastWithPredicateWithMatch()
				=> _notEmpty
					.TryLast(i => i == 2 || i == 3)
					.AssertSome()
					.Should()
					.Be(3);

			[Fact]
			public Task TryLastAsyncWithPredicateWhenEmpty()
				=> _empty
					.TryLastAsync(_ => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task TryLastAsyncWithPredicateWithNoMatch()
				=> _notEmpty
					.TryLastAsync(_ => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task TryLastAsyncWithPredicateWithMatch()
				=> _notEmpty
					.TryLastAsync(i => Task.FromResult(i == 2 || i == 3))
					.AssertSome()
					.Should()
					.Be(3);
		}

		public class WhenAsyncEnumerable
		{
			private readonly IAsyncEnumerable<int> _empty = Enumerable.Empty<int>().AsAsyncEnumerable();
			private readonly IAsyncEnumerable<int> _notEmpty = new[] { 1, 2, 3, 4 }.AsAsyncEnumerable();

			[Fact]
			public Task TryLastWhenEmpty()
				=> _empty
					.TryLast()
					.AssertNone();

			[Fact]
			public Task TryLastWhenNotEmpty()
				=> _notEmpty
					.TryLast()
					.AssertSome()
					.Should()
					.Be(4);

			[Fact]
			public Task TryLastWithPredicateWhenEmpty()
				=> _empty
					.TryLast(_ => true)
					.AssertNone();

			[Fact]
			public Task TryLastWithPredicateWithNoMatch()
				=> _notEmpty
					.TryLast(_ => false)
					.AssertNone();

			[Fact]
			public Task TryLastWithPredicateWithMatch()
				=> _notEmpty
					.TryLast(i => i == 2 || i == 3)
					.AssertSome()
					.Should()
					.Be(3);

			[Fact]
			public Task TryLastAsyncWithPredicateWhenEmpty()
				=> _empty
					.TryLastAsync(_ => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task TryLastAsyncWithPredicateWithNoMatch()
				=> _notEmpty
					.TryLastAsync(_ => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task TryLastAsyncWithPredicateWithMatch()
				=> _notEmpty
					.TryLastAsync(i => Task.FromResult(i == 2 || i == 3))
					.AssertSome()
					.Should()
					.Be(3);
		}
	}
}
