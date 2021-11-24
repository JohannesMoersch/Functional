using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false)]
	internal class AllowAllocationsAttribute : Attribute { }

	internal static class DelegateCache
	{
		public static readonly Func<bool> True = () => true;
		public static readonly Func<bool> False = () => false;
		public static readonly Action Void = () => { };
		public static readonly Func<Task> Task = () => System.Threading.Tasks.Task.CompletedTask;
	}

	internal static class DelegateCache<T>
	{
		public static readonly Func<T, bool> True = _ => true;
		public static readonly Func<T, bool> False = _ => false;
#pragma warning disable CS8603 // Possible null reference return.
		public static readonly Func<T> Default = () => default;
#pragma warning restore CS8603 // Possible null reference return.
		public static readonly Func<T, T> Passthrough = _ => _;
#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
		public static readonly Func<T, Option<T>> Some = _ => Option.Some(_);
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
		public static readonly Action<T> Void = _ => { };
		public static readonly Func<T, Task> Task = _ => System.Threading.Tasks.Task.CompletedTask;
	}

	internal static class DelegateCache<TIn, TOut>
	{
#pragma warning disable CS8603 // Possible null reference return.
		public static readonly Func<TIn, TOut> Default = _ => default;
#pragma warning restore CS8603 // Possible null reference return.
	}

	internal static class Helpers
	{
		public static bool TryGetValue<TValue>(this Option<TValue> option, out TValue some)
			where TValue : notnull
		{
			some = option.Match(DelegateCache<TValue>.Passthrough, DelegateCache<TValue>.Default);

			return option.Match(DelegateCache<TValue>.True, DelegateCache.False);
		}

		public static bool TryGetValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, out TSuccess success, out TFailure failure)
		{
			success = result.Match(DelegateCache<TSuccess>.Passthrough, DelegateCache<TFailure, TSuccess>.Default);

			failure = result.Match(DelegateCache<TSuccess, TFailure>.Default, DelegateCache<TFailure>.Passthrough);

			return result.Match(DelegateCache<TSuccess>.True, DelegateCache<TFailure>.False);
		}
	}
}
