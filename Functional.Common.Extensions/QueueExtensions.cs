using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    public static class QueueExtensions
    {
		public static Option<T> TryPeek<T>(this Queue<T> source)
			=> source.Count > 0 ? Option.Some(source.Peek()) : Option.None<T>();

		public static Option<T> TryPeek<T>(this ConcurrentQueue<T> source)
			=> source.TryPeek(out var value) ? Option.Some(value) : Option.None<T>();

		public static Option<T> TryDequeue<T>(this Queue<T> source)
			=> source.Count > 0 ? Option.Some(source.Dequeue()) : Option.None<T>();

		public static Option<T> TryDequeue<T>(this ConcurrentQueue<T> source)
			=> source.TryDequeue(out var value) ? Option.Some(value) : Option.None<T>();
	}
}
