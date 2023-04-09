using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class QueueExtensions
    {
		public static Option<T> TryPeek<T>(this Queue<T> source)
			where T : notnull
			=> source.Count > 0 ? Option.Some(source.Peek()) : Option.None<T>();

		public static Option<T> TryPeek<T>(this ConcurrentQueue<T> source)
			where T : notnull
			=> source.TryPeek(out var value) ? Option.Some(value) : Option.None<T>();

		public static Option<T> TryDequeue<T>(this Queue<T> source)
			where T : notnull
			=> source.Count > 0 ? Option.Some(source.Dequeue()) : Option.None<T>();

		public static Option<T> TryDequeue<T>(this ConcurrentQueue<T> source)
			where T : notnull
			=> source.TryDequeue(out var value) ? Option.Some(value) : Option.None<T>();
	}
}
