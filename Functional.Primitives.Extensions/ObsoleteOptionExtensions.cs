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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please also handle none explicitly.")]
		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> apply)
			=> option.Do(apply);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please also handle none explicitly.")]
		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> apply)
			=> option.Do(apply);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .ToNullable() instead.")]
		public static TValue? ValueOrNull<TValue>(this Option<TValue> option)
			where TValue : struct
			=> option.TryGetValue(out var some) ? (TValue?)some : null;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .ToNullable() instead.")]
		public static async Task<TValue?> ValueOrNull<TValue>(this Task<Option<TValue>> option)
			where TValue : struct
			=> (await option).ValueOrNull();
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please also handle none explicitly.")]
		public static Task ApplyAsync<TValue>(this Option<TValue> option, Func<TValue, Task> apply)
			=> option.DoAsync(apply);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please also handle none explicitly.")]
		public static Task ApplyAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> apply)
			=> option.DoAsync(apply);
	}
}
