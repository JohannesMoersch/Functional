using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Functional.Primitives.AsyncEnumerables
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxGroupExtensions
	{
		public static IResultEnumerable<IGrouping<TKey, TSuccess>, TFailure> GroupBy<TKey, TSuccess, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TKey> keySelector)
		{
		}
	}
}
