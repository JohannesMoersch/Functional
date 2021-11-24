using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	public interface IAsyncOptionEnumerable<TValue> : IAsyncEnumerable<Option<TValue>>
		where TValue : notnull
	{
	}

	internal class AsyncOptionEnumerable<TValue> : IAsyncOptionEnumerable<TValue>
		where TValue : notnull
	{
		private readonly IAsyncEnumerable<Option<TValue>> _source;

		public AsyncOptionEnumerable(IAsyncEnumerable<Option<TValue>> source) 
			=> _source = source ?? throw new ArgumentNullException(nameof(source));

		public IAsyncEnumerator<Option<TValue>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
			=> _source.GetAsyncEnumerator(cancellationToken);
	}

	internal static class AsyncOptionEnumerable
	{
		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this IAsyncEnumerable<Option<TValue>> source)
			where TValue : notnull
			=> new AsyncOptionEnumerable<TValue>(source);

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IEnumerable<Option<TValue>>> source)
			where TValue : notnull
			=> source
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IOptionEnumerable<TValue>> source)
			where TValue : notnull
			=> ConvertEnumerable(source)
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IAsyncEnumerable<Option<TValue>>> source)
			where TValue : notnull
			=> source
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		public static IAsyncOptionEnumerable<TValue> AsAsyncOptionEnumerable<TValue>(this Task<IAsyncOptionEnumerable<TValue>> source)
			where TValue : notnull
			=> ConvertAsyncEnumerable(source)
				.AsAsyncEnumerable()
				.AsAsyncOptionEnumerable();

		private static async Task<IEnumerable<Option<TValue>>> ConvertEnumerable<TValue>(Task<IOptionEnumerable<TValue>> source)
			where TValue : notnull
			=> await source;

		private static async Task<IAsyncEnumerable<Option<TValue>>> ConvertAsyncEnumerable<TValue>(Task<IAsyncOptionEnumerable<TValue>> source)
			where TValue : notnull
			=> await source;
	}
}
