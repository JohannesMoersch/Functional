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
	}
}
