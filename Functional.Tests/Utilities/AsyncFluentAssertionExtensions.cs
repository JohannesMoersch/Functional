using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Primitives;

namespace Functional
{
	public static class AsyncFluentAssertionExtensions
	{
		public static async Task<ObjectAssertions> Should<T>(this Task<T> source)
			=> (await source).Should();

		public static async Task<AndConstraint<ObjectAssertions>> Be(this Task<ObjectAssertions> source, object expected)
			=> (await source).Be(expected);

		public static async Task<AndConstraint<ObjectAssertions>> BeOfType<T>(this Task<ObjectAssertions> source)
			=> (await source).BeOfType<T>();

			public static async Task<AndConstraint<ObjectAssertions>> BeNull(this Task<ObjectAssertions> source)
			=> (await source).BeNull();

		public static async Task<StringAssertions> Should(this Task<string> source)
			=> (await source).Should();

		public static async Task<AndConstraint<StringAssertions>> Be(this Task<StringAssertions> source, string expected)
			=> (await source).Be(expected);

		public static async Task<BooleanAssertions> Should(this Task<bool> source)
			=> (await source).Should();

		public static async Task<AndConstraint<BooleanAssertions>> BeTrue(this Task<BooleanAssertions> source)
			=> (await source).BeTrue();

		public static async Task<AndConstraint<BooleanAssertions>> BeFalse(this Task<BooleanAssertions> source)
			=> (await source).BeFalse();

		public static async Task<GenericCollectionAssertions<T>> Should<T>(this Task<IEnumerable<T>> source)
			=> (await source).Should();

		public static async Task<GenericCollectionAssertions<T>> Should<T>(this IAsyncEnumerable<T> source)
			=> (await source.AsEnumerable()).Should();

		public static async Task<GenericCollectionAssertions<T>> Should<T>(this Task<T[]> source)
		   => (await source).Should();

		public static async Task<GenericCollectionAssertions<T>> Should<T>(this Task<List<T>> source)
		   => (await source).Should();

		public static async Task<AndConstraint<GenericCollectionAssertions<T>>> BeEquivalentTo<T>(this Task<GenericCollectionAssertions<T>> source, params T[] expectations)
		   => (await source).BeEquivalentTo(expectations);

		public static async Task<AndConstraint<GenericCollectionAssertions<T>>> BeEquivalentTo<T>(this Task<GenericCollectionAssertions<T>> source, IEnumerable<T> expectations)
		   => (await source).BeEquivalentTo(expectations);

		public static async Task<StringCollectionAssertions> Should<T>(this Task<IEnumerable<string>> source)
		   => (await source).Should();

		public static async Task<StringCollectionAssertions> Should<T>(this IAsyncEnumerable<string> source)
		   => (await source.AsEnumerable()).Should();

		public static async Task<StringCollectionAssertions> Should<T>(this Task<string[]> source)
		   => (await source).Should();
		public static async Task<StringCollectionAssertions> Should<T>(this Task<List<string>> source)
		   => (await source).Should();

		public static async Task<AndConstraint<StringCollectionAssertions>> BeEquivalentTo(this Task<StringCollectionAssertions> source, params string[] expectations)
		   => (await source).BeEquivalentTo(expectations);

		public static async Task<AndConstraint<StringCollectionAssertions>> BeEquivalentTo(this Task<StringCollectionAssertions> source, IEnumerable<string> expectations)
		   => (await source).BeEquivalentTo(expectations);
	}
}
