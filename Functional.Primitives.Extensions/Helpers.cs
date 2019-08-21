using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	internal static class Helpers
	{
		[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false)]
		public class AllowAllocationsAttribute : Attribute { }	

		private class DelegateCache<T>
		{
			public static readonly Func<T, T> Passthrough = _ => _;

			public static readonly Func<T, bool> True = _ => true;
		}

		private class OptionDelegateCache<T>
		{
			public static readonly Func<T> Default = () => default;

			public static readonly Func<bool> False = () => false;
		}

		private class ResultDelegateCache<TIn, TOut>
		{
			public static readonly Func<TIn, TOut> Default = _ => default;

			public static readonly Func<TIn, bool> False = _ => false;
		}

		public static bool TryGetValue<TValue>(this Option<TValue> option, out TValue some)
		{
			some = option.Match(DelegateCache<TValue>.Passthrough, OptionDelegateCache<TValue>.Default);

			return option.Match(DelegateCache<TValue>.True, OptionDelegateCache<TValue>.False);
		}

		public static bool TryGetValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, out TSuccess success, out TFailure failure)
		{
			success = result.Match(DelegateCache<TSuccess>.Passthrough, ResultDelegateCache<TFailure, TSuccess>.Default);

			failure = result.Match(ResultDelegateCache<TSuccess, TFailure>.Default, DelegateCache<TFailure>.Passthrough);

			return result.Match(DelegateCache<TSuccess>.True, ResultDelegateCache<TFailure, TFailure>.False);
		}
	}
}
