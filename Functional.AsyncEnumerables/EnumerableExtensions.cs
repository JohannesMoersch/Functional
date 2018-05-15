using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class EnumerableExtensions
    {
		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
			=> AsyncEnumerable.Create(source);

		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<IEnumerable<TSource>> source)
			=> AsyncEnumerable.Create(source);
    }
}
