using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static partial class OptionExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This method always produces Some. If you need this behaviour, please use .Match() instead.")]
		public static Option<TValue> DefaultIfNone<TValue>(this Option<TValue> option, TValue defaultValue = default)
			=> option.TryGetValue(out var some) ? Option.Some(some) : Option.Some(defaultValue);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This method always produces Some. If you need this behaviour, please use .Match() instead.")]
		public static async Task<Option<TValue>> DefaultIfNone<TValue>(this Task<Option<TValue>> option, TValue defaultValue = default)
			=> (await option).DefaultIfNone(defaultValue);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNone() instead.")]
		public static Option<TValue> BindIfNone<TValue>(this Option<TValue> option, Func<Option<TValue>> bind)
			=> option.BindOnNone(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNone() instead.")]
		public static Task<Option<TValue>> BindIfNone<TValue>(this Task<Option<TValue>> option, Func<Option<TValue>> bind)
			=> option.BindOnNone(bind);
	}

	public static partial class OptionAsyncExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapAsync() instead.")]
		public static Task<Option<TResult>> SelectAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> map)
			=> option.MapAsync(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapAsync() instead.")]
		public static Task<Option<TResult>> SelectAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> map)
			=> option.MapAsync(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNoneAsync() instead.")]
		public static Task<Option<TValue>> BindIfNoneAsync<TValue>(this Option<TValue> option, Func<Task<Option<TValue>>> bind)
			=> option.BindOnNoneAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNoneAsync() instead.")]
		public static Task<Option<TValue>> BindIfNoneAsync<TValue>(this Task<Option<TValue>> option, Func<Task<Option<TValue>>> bind)
			=> option.BindOnNoneAsync(bind);
	}
}
