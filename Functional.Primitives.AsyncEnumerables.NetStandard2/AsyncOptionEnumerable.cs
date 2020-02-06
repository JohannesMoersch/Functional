using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public interface IAsyncOptionEnumerable<TValue> : IAsyncEnumerable<Option<TValue>>
	{
	}

	internal class AsyncOptionEnumerable<TValue> : IAsyncOptionEnumerable<TValue>
	{
		private readonly IAsyncEnumerable<Option<TValue>> _source;

		public AsyncOptionEnumerable(IAsyncEnumerable<Option<TValue>> source) 
			=> _source = source ?? throw new ArgumentNullException(nameof(source));

		public IAsyncEnumerator<Option<TValue>> GetEnumerator()
			=> _source.GetEnumerator();
	}

	internal static class AsyncOptionEnumerable
	{
		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this IAsyncEnumerable<Option<TValue>> source)
			=> new AsyncOptionEnumerable<TValue>(source);

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IEnumerable<Option<TValue>>> source)
			=> source
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IOptionEnumerable<TValue>> source)
			=> ConvertEnumerable(source)
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IAsyncEnumerable<Option<TValue>>> source)
			=> source
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IAsyncOptionEnumerable<TValue>> source)
			=> ConvertAsyncEnumerable(source)
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		private static async Task<IEnumerable<Option<TValue>>> ConvertEnumerable<TValue>(Task<IOptionEnumerable<TValue>> source)
			=> await source;

		private static async Task<IAsyncEnumerable<Option<TValue>>> ConvertAsyncEnumerable<TValue>(Task<IAsyncOptionEnumerable<TValue>> source)
			=> await source;
	}
}
