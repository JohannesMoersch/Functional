using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class CastTests
	{
		[Fact]
		public async Task CastWrongType()
			=> await Assert
				.ThrowsAsync<InvalidCastException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable().Cast<int, object>())
					.Cast<float>()
					.AsEnumerable()
				);

		[Fact]
		public async Task CastRightType()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable().Cast<int, object>())
					.Cast<int>()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });
	}
}
