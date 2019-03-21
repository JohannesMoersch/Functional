using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionLinqSyntaxWhereExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<TValue> Where<TValue>(this Option<TValue> source, Func<TValue, Option<Unit>> failurePredicate)
			=> source
				.Bind(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> source, Func<TValue, Option<Unit>> failurePredicate)
			=> source
				.Bind(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TValue>> Where<TValue>(this Option<TValue> source, Func<TValue, Task<Option<Unit>>> failurePredicate)
			=> source
				.BindAsync(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> source, Func<TValue, Task<Option<Unit>>> failurePredicate)
			=> source
				.BindAsync(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);
	}
}
