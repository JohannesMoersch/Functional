using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    public static class StackExtensions
    {
		public static Option<T> TryPeek<T>(this Stack<T> source)
			=> source.Count > 0 ? Option.Some(source.Peek()) : Option.None<T>();

		public static Option<T> TryPeek<T>(this ConcurrentStack<T> source)
			=> source.TryPeek(out var value) ? Option.Some(value) : Option.None<T>();

		public static Option<T> TryPop<T>(this Stack<T> source)
			=> source.Count > 0 ? Option.Some(source.Pop()) : Option.None<T>();

		public static Option<T> TryPop<T>(this ConcurrentStack<T> source)
			=> source.TryPop(out var value) ? Option.Some(value) : Option.None<T>();
	}
}
