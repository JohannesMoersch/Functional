using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class StackExtensions
    {
		public static Option<T> TryPeek<T>(this Stack<T> source)
			where T : notnull
			=> source.Count > 0 ? Option.Some(source.Peek()) : Option.None<T>();

		public static Option<T> TryPeek<T>(this ConcurrentStack<T> source)
			where T : notnull
			=> source.TryPeek(out var value) ? Option.Some(value) : Option.None<T>();

		public static Option<T> TryPop<T>(this Stack<T> source)
			where T : notnull
			=> source.Count > 0 ? Option.Some(source.Pop()) : Option.None<T>();

		public static Option<T> TryPop<T>(this ConcurrentStack<T> source)
			where T : notnull
			=> source.TryPop(out var value) ? Option.Some(value) : Option.None<T>();
	}
}
