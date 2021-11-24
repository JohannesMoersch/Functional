using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionMatchExtensions
    {
		public static async Task<TResult> Match<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> some, Func<TResult> none)
		where TValue : notnull
			=> (await option).Match(some, none);

		public static Task<TResult> MatchAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> some, Func<Task<TResult>> none)
		where TValue : notnull
			=> option.Match(some, none);

		public static async Task<TResult> MatchAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> some, Func<Task<TResult>> none)
		where TValue : notnull
			=> await (await option).Match(some, none);
	}
}
