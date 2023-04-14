using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using static Functional.PartialResult;

namespace Functional
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
	internal class AllowAllocationsAttribute : Attribute { }

	public static class TryGetValueExtensions
	{
#pragma warning disable CS8603 // Possible null reference return.
		private static class DelegateCache
		{
			public static readonly Func<bool> False = () => false;
		}

		private static class DelegateCache<T>
		{
			public static readonly Func<T, bool> True = _ => true;
			public static readonly Func<T, bool> False = _ => false;
			public static readonly Func<T> Default = () => default;
			public static readonly Func<T, T> Passthrough = _ => _;
		}

		private static class DelegateCache<TIn, TOut>
		{
			public static readonly Func<TIn, TOut> Default = _ => default;
		}

		public static bool TryGetValue<TValue>(this Option<TValue> option, [MaybeNullWhen(false)] out TValue some)
			where TValue : notnull
		{
			some = option.Match(DelegateCache<TValue>.Passthrough, DelegateCache<TValue>.Default);

			return option.Match(DelegateCache<TValue>.True, DelegateCache.False);
		}

		public static bool TryGetValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, [MaybeNullWhen(false)] out TSuccess success, [MaybeNullWhen(true)] out TFailure failure)
			where TSuccess : notnull
			where TFailure : notnull
		{
			success = result.Match(DelegateCache<TSuccess>.Passthrough, DelegateCache<TFailure, TSuccess>.Default);

			failure = result.Match(DelegateCache<TSuccess, TFailure>.Default, DelegateCache<TFailure>.Passthrough);

			return result.Match(DelegateCache<TSuccess>.True, DelegateCache<TFailure>.False);
		}
#pragma warning restore CS8603 // Possible null reference return.
	}
}
