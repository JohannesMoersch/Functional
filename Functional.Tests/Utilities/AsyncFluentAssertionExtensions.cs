using FluentAssertions;
using FluentAssertions.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class AsyncFluentAssertionExtensions
	{
		public static async Task<GenericCollectionAssertions<T>> Should<T>(this Task<IEnumerable<T>> source)
			=> (await source).Should();

		public static async Task<GenericCollectionAssertions<T>> Should<T>(this Task<T[]> source)
			=> (await source).Should();

		public static async Task<AndConstraint<GenericCollectionAssertions<T>>> BeEquivalentTo<T>(this Task<GenericCollectionAssertions<T>> source, params T[] expectations)
			=> (await source).BeEquivalentTo(expectations);

		public static async Task<StringCollectionAssertions> Should<T>(this Task<IEnumerable<string>> source)
			=> (await source).Should();

		public static async Task<StringCollectionAssertions> Should<T>(this Task<string[]> source)
			=> (await source).Should();

		public static async Task<AndConstraint<StringCollectionAssertions>> BeEquivalentTo(this Task<StringCollectionAssertions> source, params string[] expectations)
			=> (await source).BeEquivalentTo(expectations);
	}
}
