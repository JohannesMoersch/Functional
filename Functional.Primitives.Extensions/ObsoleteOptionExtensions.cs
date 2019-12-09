using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Primitives.Extensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ObsoleteOptionExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Map() instead.")]
		public static Option<TResult> Select<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> map)
			=> option.Map(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Map() instead.")]
		public static Task<Option<TResult>> Select<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> map)
			=> option.Map(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This method always produces Some. If you need this behaviour, please use .Match() instead.")]
		public static Option<TValue> DefaultIfNone<TValue>(this Option<TValue> option, TValue defaultValue = default)
			=> option.TryGetValue(out var some) ? Option.Some(some) : Option.Some(defaultValue);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This method always produces Some. If you need this behaviour, please use .Match() instead.")]
		public static async Task<Option<TValue>> DefaultIfNone<TValue>(this Task<Option<TValue>> option, TValue defaultValue = default)
			=> (await option).DefaultIfNone(defaultValue);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapAsync() instead.")]
		public static Task<Option<TResult>> SelectAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> map)
			=> option.MapAsync(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapAsync() instead.")]
		public static Task<Option<TResult>> SelectAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> map)
			=> option.MapAsync(map);
	}
}
