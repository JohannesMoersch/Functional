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
	}
}
