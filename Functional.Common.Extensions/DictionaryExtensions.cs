﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class DictionaryExtensions
    {
		public static Option<TValue> TryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key)
			where TValue : notnull
		{
			if (source.TryGetValue(key, out var value) && value != null)
				return Option.Some(value);

			return Option.None<TValue>();
		}

		public static Option<TValue> TryGetValue<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> source, TKey key)
			where TValue : notnull
		{
			if (source.TryGetValue(key, out var value) && value != null)
				return Option.Some(value);

			return Option.None<TValue>();
		}

		public static Option<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
			where TValue : notnull
		{
			if (source.TryGetValue(key, out var value) && value != null)
				return Option.Some(value);

			return Option.None<TValue>();
		}

		public static Option<TValue> TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, TKey key)
			where TValue : notnull
		{
			if (source.TryGetValue(key, out var value) && value != null)
				return Option.Some(value);

			return Option.None<TValue>();
		}

		public static Option<TValue> TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> source, TKey key)
			where TValue : notnull
		{
			if (source.TryRemove(key, out var value) && value != null)
				return Option.Some(value);

			return Option.None<TValue>();
		}

		public static Option<TValue> TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue?> source, TKey key)
			where TValue : struct
		{
			if (source.TryRemove(key, out var value) && value is TValue v)
				return Option.Some(v);

			return Option.None<TValue>();
		}
	}
}
