using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class OfTypeTests
    {
		[Fact]
		public async Task OfTypeWrongType()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable().Cast<int, object>())
					.OfType<float>()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new int[0]);

		[Fact]
		public async Task OfTypeRightType()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable().Cast<int, object>())
					.OfType<int>()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public async Task OfTypeMixedType()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new object[] { 1, 2.0, 3 }).AsEnumerable())
					.OfType<int>()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 3 });
	}
}
