using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class TryFirstTests
	{
		public class WhenEnumerable
		{
			private readonly IEnumerable<int> _empty = Enumerable.Empty<int>();
			private readonly IEnumerable<int> _notEmpty = new[] { 1, 2, 3, 4 };

			[Fact]
			public void TryFirstWhenEmpty()
				=> _empty
					.TryFirst()
					.AssertNone();

			[Fact]
			public void TryFirstWhenNotEmpty()
				=> _notEmpty
					.TryFirst()
					.AssertSome()
					.Should()
					.Be(1);

			[Fact]
			public void TryFirstWithPredicateWhenEmpty()
				=> _empty
					.TryFirst(_ => true)
					.AssertNone();

			[Fact]
			public void TryFirstWithPredicateWithNoMatch()
				=> _notEmpty
					.TryFirst(_ => false)
					.AssertNone();

			[Fact]
			public void TryFirstWithPredicateWithMatch()
				=> _notEmpty
					.TryFirst(i => i == 2 || i == 3)
					.AssertSome()
					.Should()
					.Be(2);

			[Fact]
			public Task TryFirstAsyncWithPredicateWhenEmpty()
				=> _empty
					.TryFirstAsync(_ => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task TryFirstAsyncWithPredicateWithNoMatch()
				=> _notEmpty
					.TryFirstAsync(_ => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task TryFirstAsyncWithPredicateWithMatch()
				=> _notEmpty
					.TryFirstAsync(i => Task.FromResult(i == 2 || i == 3))
					.AssertSome()
					.Should()
					.Be(2);
		}

		public class WhenTaskOfEnumerable
		{
			private readonly Task<IEnumerable<int>> _empty = Task.FromResult(Enumerable.Empty<int>());
			private readonly Task<IEnumerable<int>> _notEmpty = Task.FromResult(new[] { 1, 2, 3, 4 }.AsEnumerable());

			[Fact]
			public Task TryFirstWhenEmpty()
				=> _empty
					.TryFirst()
					.AssertNone();

			[Fact]
			public Task TryFirstWhenNotEmpty()
				=> _notEmpty
					.TryFirst()
					.AssertSome()
					.Should()
					.Be(1);

			[Fact]
			public Task TryFirstWithPredicateWhenEmpty()
				=> _empty
					.TryFirst(_ => true)
					.AssertNone();

			[Fact]
			public Task TryFirstWithPredicateWithNoMatch()
				=> _notEmpty
					.TryFirst(_ => false)
					.AssertNone();

			[Fact]
			public Task TryFirstWithPredicateWithMatch()
				=> _notEmpty
					.TryFirst(i => i == 2 || i == 3)
					.AssertSome()
					.Should()
					.Be(2);

			[Fact]
			public Task TryFirstAsyncWithPredicateWhenEmpty()
				=> _empty
					.TryFirstAsync(_ => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task TryFirstAsyncWithPredicateWithNoMatch()
				=> _notEmpty
					.TryFirstAsync(_ => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task TryFirstAsyncWithPredicateWithMatch()
				=> _notEmpty
					.TryFirstAsync(i => Task.FromResult(i == 2 || i == 3))
					.AssertSome()
					.Should()
					.Be(2);
		}

		public class WhenAsyncEnumerable
		{
			private readonly IAsyncEnumerable<int> _empty = Enumerable.Empty<int>().AsAsyncEnumerable();
			private readonly IAsyncEnumerable<int> _notEmpty = new[] { 1, 2, 3, 4 }.AsAsyncEnumerable();

			[Fact]
			public Task TryFirstWhenEmpty()
				=> _empty
					.TryFirst()
					.AssertNone();

			[Fact]
			public Task TryFirstWhenNotEmpty()
				=> _notEmpty
					.TryFirst()
					.AssertSome()
					.Should()
					.Be(1);

			[Fact]
			public Task TryFirstWithPredicateWhenEmpty()
				=> _empty
					.TryFirst(_ => true)
					.AssertNone();

			[Fact]
			public Task TryFirstWithPredicateWithNoMatch()
				=> _notEmpty
					.TryFirst(_ => false)
					.AssertNone();

			[Fact]
			public Task TryFirstWithPredicateWithMatch()
				=> _notEmpty
					.TryFirst(i => i == 2 || i == 3)
					.AssertSome()
					.Should()
					.Be(2);

			[Fact]
			public Task TryFirstAsyncWithPredicateWhenEmpty()
				=> _empty
					.TryFirstAsync(_ => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task TryFirstAsyncWithPredicateWithNoMatch()
				=> _notEmpty
					.TryFirstAsync(_ => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task TryFirstAsyncWithPredicateWithMatch()
				=> _notEmpty
					.TryFirstAsync(i => Task.FromResult(i == 2 || i == 3))
					.AssertSome()
					.Should()
					.Be(2);
		}
	}
}
