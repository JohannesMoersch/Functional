using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	internal static class Helpers
	{
		[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false)]
		public class AllowAllocationsAttribute : Attribute { }

		public static class ValueToValue<T>
		{
			public static readonly Func<T, T> Value = _ => _;
		}

		public static class ValueToTrue<T>
		{
			public static readonly Func<T, bool> Value = _ => true;
		}

		public static class ValueToFalse<T>
		{
			public static readonly Func<T, bool> Value = _ => false;
		}

		public static class Default<T>
		{
			public static readonly Func<T> Value = () => default;
		}

		public static class False
		{
			public static readonly Func<bool> Value = () => false;
		}

		public static class ValueToDefault<TIn, TOut>
		{
			public static readonly Func<TIn, TOut> Value = _ => default;
		}

		public static class Some<T>
		{
			public static readonly Func<T, Option<T>> Value = _ => Option.Some(_);
		}

		public static bool TryGetValue<TValue>(this Option<TValue> option, out TValue some)
		{
			some = option.Match(ValueToValue<TValue>.Value, Default<TValue>.Value);

			return option.Match(ValueToTrue<TValue>.Value, False.Value);
		}

		public static bool TryGetValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, out TSuccess success, out TFailure failure)
		{
			success = result.Match(ValueToValue<TSuccess>.Value, ValueToDefault<TFailure, TSuccess>.Value);

			failure = result.Match(ValueToDefault<TSuccess, TFailure>.Value, ValueToValue<TFailure>.Value);

			return result.Match(ValueToTrue<TSuccess>.Value, ValueToFalse<TFailure>.Value);
		}
	}
}
