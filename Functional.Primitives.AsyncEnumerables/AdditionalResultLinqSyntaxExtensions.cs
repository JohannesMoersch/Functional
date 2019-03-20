using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxGroupExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			=> source
				.Select(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				)
				.AsResultEnumerable();
	}
}
