using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public interface IAsyncResultEnumerable<TSuccess, TFailure> : IAsyncEnumerable<Result<TSuccess, TFailure>>
	{
	}

	internal class AsyncResultEnumerable<TSuccess, TFailure> : IAsyncResultEnumerable<TSuccess, TFailure>
	{
		private readonly IAsyncEnumerable<Result<TSuccess, TFailure>> _source;

		public AsyncResultEnumerable(IAsyncEnumerable<Result<TSuccess, TFailure>> source) 
			=> _source = source ?? throw new ArgumentNullException(nameof(source));

		public IAsyncEnumerator<Result<TSuccess, TFailure>> GetEnumerator()
			=> _source.GetEnumerator();
	}

	internal static class AsyncResultEnumerable
	{
		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
			=> new AsyncResultEnumerable<TSuccess, TFailure>(source);

		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IResultEnumerable<TSuccess, TFailure>> source)
			=> ConvertEnumerable(source)
				.AsAsyncEnumerable()
				.AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			=> source
				.AsAsyncEnumerable()
				.AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IAsyncResultEnumerable<TSuccess, TFailure>> source)
			=> ConvertAsyncEnumerable(source)
				.AsAsyncEnumerable()
				.AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IAsyncEnumerable<Result<TSuccess, TFailure>>> source)
			=> source
				.AsAsyncEnumerable()
				.AsAsyncResultEnumerable();

		private static async Task<IEnumerable<Result<TSuccess, TFailure>>> ConvertEnumerable<TSuccess, TFailure>(Task<IResultEnumerable<TSuccess, TFailure>> source)
			=> await source;

		private static async Task<IAsyncEnumerable<Result<TSuccess, TFailure>>> ConvertAsyncEnumerable<TSuccess, TFailure>(Task<IAsyncResultEnumerable<TSuccess, TFailure>> source)
			=> await source;
	}
}
