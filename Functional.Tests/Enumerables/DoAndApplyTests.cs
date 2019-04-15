using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class DoAndApplyTests
	{
		[Fact]
		public void EnumerableApply()
		{
			var list = new List<int>();

			new[] { 1, 2, 3 }.Apply(list.Add);

			list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
		}

		[Fact]
		public async Task TaskEnumerableApply()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsEnumerable()
				.Apply(list.Add);

			list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
		}

		[Fact]
		public async Task AsyncEnumerableApply()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsAsyncEnumerable()
				.Apply(list.Add);

			list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
		}

		[Fact]
		public async Task EnumerableApplyAsync()
		{
			var list = new List<int>();

			await new[] { 1, 2, 3 }.ApplyAsync(async i => { await Task.Delay(10); list.Add(i); });

			list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
		}

		[Fact]
		public async Task TaskEnumerableApplyAsync()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsEnumerable()
				.ApplyAsync(async i => { await Task.Delay(10); list.Add(i); });

			list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
		}

		[Fact]
		public async Task AsyncEnumerableApplyAsync()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsAsyncEnumerable()
				.ApplyAsync(async i => { await Task.Delay(10); list.Add(i); });

			list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
		}

		[Fact]
		public void EnumerableDo()
		{
			var list = new List<int>();

			new[] { 1, 2, 3 }
				.Do(list.Add)
				.Should()
				.BeEquivalentTo(list);
		}

		[Fact]
		public async Task TaskEnumerableDo()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsEnumerable()
				.Do(list.Add)
				.Should()
				.BeEquivalentTo(list);
		}

		[Fact]
		public async Task AsyncEnumerableDo()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsAsyncEnumerable()
				.Do(list.Add)
				.Should()
				.BeEquivalentTo(list);
		}

		[Fact]
		public async Task EnumerableDoAsync()
		{
			var list = new List<int>();

			await new[] { 1, 2, 3 }
				.DoAsync(async i => { await Task.Delay(10); list.Add(i); })
				.Should()
				.BeEquivalentTo(list);
		}

		[Fact]
		public async Task TaskEnumerableDoAsync()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsEnumerable()
				.DoAsync(async i => { await Task.Delay(10); list.Add(i); })
				.Should()
				.BeEquivalentTo(list);
		}

		[Fact]
		public async Task AsyncEnumerableDoAsync()
		{
			var list = new List<int>();

			await Task.FromResult(new[] { 1, 2, 3 })
				.AsAsyncEnumerable()
				.DoAsync(async i => { await Task.Delay(10); list.Add(i); })
				.Should()
				.BeEquivalentTo(list);
		}
	}
}
