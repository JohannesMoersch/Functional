using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Functional;

namespace Functional.Native
{
	/// <summary>
	/// Extension methods on native C# 15 <c>union</c> types that mirror the full
	/// Functional API (Match, MatchAsync, Do, Apply, DoAsync, One/Two/Three, Select,
	/// SelectMany).
	///
	/// <para>
	/// Because the prototype Roslyn build does not yet support extension-method dispatch
	/// via an interface receiver on native union types, these overloads take
	/// <c>Union&lt;TOne, TTwo&gt;</c> directly as the receiver so dispatch is resolved
	/// without requiring any interface conversion.
	/// </para>
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class NativeUnionExtensions
	{
		// ── MatchAsync ───────────────────────────────────────────────────────────────

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TResult>(
			this Union<TOne, TTwo> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two)
			=> union.Match(one, two);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TThree, TResult>(
			this Union<TOne, TTwo, TThree> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two,
			Func<TThree, Task<TResult>> three)
			=> union.Match(one, two, three);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TThree, TFour, TResult>(
			this Union<TOne, TTwo, TThree, TFour> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two,
			Func<TThree, Task<TResult>> three,
			Func<TFour, Task<TResult>> four)
			=> union.Match(one, two, three, four);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TThree, TFour, TFive, TResult>(
			this Union<TOne, TTwo, TThree, TFour, TFive> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two,
			Func<TThree, Task<TResult>> three,
			Func<TFour, Task<TResult>> four,
			Func<TFive, Task<TResult>> five)
			=> union.Match(one, two, three, four, five);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(
			this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two,
			Func<TThree, Task<TResult>> three,
			Func<TFour, Task<TResult>> four,
			Func<TFive, Task<TResult>> five,
			Func<TSix, Task<TResult>> six)
			=> union.Match(one, two, three, four, five, six);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(
			this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two,
			Func<TThree, Task<TResult>> three,
			Func<TFour, Task<TResult>> four,
			Func<TFive, Task<TResult>> five,
			Func<TSix, Task<TResult>> six,
			Func<TSeven, Task<TResult>> seven)
			=> union.Match(one, two, three, four, five, six, seven);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<TResult> MatchAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(
			this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union,
			Func<TOne, Task<TResult>> one,
			Func<TTwo, Task<TResult>> two,
			Func<TThree, Task<TResult>> three,
			Func<TFour, Task<TResult>> four,
			Func<TFive, Task<TResult>> five,
			Func<TSix, Task<TResult>> six,
			Func<TSeven, Task<TResult>> seven,
			Func<TEight, Task<TResult>> eight)
			=> union.Match(one, two, three, four, five, six, seven, eight);

		// ── Do ───────────────────────────────────────────────────────────────────────

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Union<TOne, TTwo> Do<TOne, TTwo>(
			this Union<TOne, TTwo> union,
			Action<TOne> one, Action<TTwo> two)
		{
			union.Match(one, two);
			return union;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Union<TOne, TTwo, TThree> Do<TOne, TTwo, TThree>(
			this Union<TOne, TTwo, TThree> union,
			Action<TOne> one, Action<TTwo> two, Action<TThree> three)
		{
			union.Match(one, two, three);
			return union;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Union<TOne, TTwo, TThree, TFour> Do<TOne, TTwo, TThree, TFour>(
			this Union<TOne, TTwo, TThree, TFour> union,
			Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
		{
			union.Match(one, two, three, four);
			return union;
		}

		// ── Apply ────────────────────────────────────────────────────────────────────

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Apply<TOne, TTwo>(
			this Union<TOne, TTwo> union,
			Action<TOne> one, Action<TTwo> two)
			=> union.Match(one, two);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Apply<TOne, TTwo, TThree>(
			this Union<TOne, TTwo, TThree> union,
			Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			=> union.Match(one, two, three);

		// ── DoAsync ──────────────────────────────────────────────────────────────────

		public static async Task<Union<TOne, TTwo>> DoAsync<TOne, TTwo>(
			this Union<TOne, TTwo> union,
			Func<TOne, Task> one, Func<TTwo, Task> two)
		{
			await union.Match(one, two);
			return union;
		}

		public static async Task<Union<TOne, TTwo, TThree>> DoAsync<TOne, TTwo, TThree>(
			this Union<TOne, TTwo, TThree> union,
			Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
		{
			await union.Match(one, two, three);
			return union;
		}

		// ── One / Two / Three (case extraction) ──────────────────────────────────────

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Option<TOne> One<TOne, TTwo>(this Union<TOne, TTwo> union)
			=> union.Match(Option.Some, _ => Option.None<TOne>());

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Option<TTwo> Two<TOne, TTwo>(this Union<TOne, TTwo> union)
			=> union.Match(_ => Option.None<TTwo>(), Option.Some);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Option<TOne> One<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>());

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Option<TTwo> Two<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>());

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Option<TThree> Three<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some);

		// ── Select / SelectMany ──────────────────────────────────────────────────────
		//
		// Mirrors Result<TSuccess, TFailure> LINQ query-expression support:
		//   • select maps the first (success) case
		//   • from … from … select chains, short-circuiting on the first failure
		// Returns Union<TResult, TFailure> directly — zero allocation, no wrapper type.

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Union<TResult, TFailure> Select<TSuccess, TFailure, TResult>(
			this Union<TSuccess, TFailure> union,
			Func<TSuccess, TResult> selector)
			=> union.Match<Union<TResult, TFailure>>(
				v => selector(v),
				err => err);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Union<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(
			this Union<TSuccess, TFailure> union,
			Func<TSuccess, Union<TBind, TFailure>> selector,
			Func<TSuccess, TBind, TResult> resultSelector)
			=> union.Match<Union<TResult, TFailure>>(
				v => selector(v).Match<Union<TResult, TFailure>>(
					b => resultSelector(v, b),
					err => err),
				err => err);
	}
}
