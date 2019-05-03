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

	internal class TaskAsyncResultEnumerable<TSuccess, TFailure> : IAsyncResultEnumerable<TSuccess, TFailure>
	{
		private readonly Task<IEnumerable<Result<TSuccess, TFailure>>> _source;

		public TaskAsyncResultEnumerable(Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			=> _source = source ?? throw new ArgumentNullException(nameof(source));

		public IAsyncEnumerator<Result<TSuccess, TFailure>> GetEnumerator()
			=> new TaskAsyncResultEnumerator<TSuccess, TFailure>(GetTaskEnumerator());

		private async Task<IEnumerator<Result<TSuccess, TFailure>>> GetTaskEnumerator()
			=> (await _source).GetEnumerator();
	}

	internal class TaskAsyncResultEnumerator<TSuccess, TFailure> : IAsyncEnumerator<Result<TSuccess, TFailure>>
	{
		private readonly Task<IEnumerator<Result<TSuccess, TFailure>>> _source;

		public Result<TSuccess, TFailure> Current { get; private set; }

		public TaskAsyncResultEnumerator(Task<IEnumerator<Result<TSuccess, TFailure>>> source)
			=> _source = source;

		public async Task<bool> MoveNext()
		{
			var source = await _source;

			if (source.MoveNext())
			{
				Current = source.Current;
				return true;
			}

			Current = default;
			return false;
		}
	}

	internal static class AsyncResultEnumerable
	{
		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
			=> new AsyncResultEnumerable<TSuccess, TFailure>(source);

		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IResultEnumerable<TSuccess, TFailure>> source)
			=> new TaskAsyncResultEnumerable<TSuccess, TFailure>(ConvertEnumerable(source));

		public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			=> new TaskAsyncResultEnumerable<TSuccess, TFailure>(source);

		private static async Task<IEnumerable<Result<TSuccess, TFailure>>> ConvertEnumerable<TSuccess, TFailure>(Task<IResultEnumerable<TSuccess, TFailure>> source)
			=> await source;
	}
}
