using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public interface IResultEnumerable<TSuccess, TFailure> : IEnumerable<Result<TSuccess, TFailure>>
	{
	}

	internal class ResultEnumerable<TSuccess, TFailure> : IResultEnumerable<TSuccess, TFailure>
	{
		private readonly IEnumerable<Result<TSuccess, TFailure>> _results;

		internal ResultEnumerable(IEnumerable<Result<TSuccess, TFailure>> results)
			=> _results = results;

		public IEnumerator<Result<TSuccess, TFailure>> GetEnumerator()
			=> _results.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> _results.GetEnumerator();
	}

	public static class ResultEnumerable
    {
		public static IResultEnumerable<TSuccess, TFailure> Create<TSuccess, TFailure>(IEnumerable<Result<TSuccess, TFailure>> results)
			=> new ResultEnumerable<TSuccess, TFailure>(results);

		public static async Task<IResultEnumerable<TSuccess, TFailure>> Create<TSuccess, TFailure>(Task<IEnumerable<Result<TSuccess, TFailure>>> results)
			=> new ResultEnumerable<TSuccess, TFailure>(await results);
	}
}
