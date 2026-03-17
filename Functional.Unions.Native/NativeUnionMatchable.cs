using System;

namespace Functional
{
	/// <summary>
	/// Represents a matchable union of two cases produced by LINQ <c>select</c> /
	/// <c>from … select</c> query expressions over native union types.
	/// </summary>
	public interface IMatchableUnion<TOne, TTwo>
		where TOne : notnull
		where TTwo : notnull
	{
		TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two);
	}

	/// <summary>
	/// Represents a matchable union of three cases.
	/// </summary>
	public interface IMatchableUnion<TOne, TTwo, TThree>
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
	{
		TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three);
	}

	/// <summary>
	/// Concrete implementation holding the result of a projected (mapped) first case or
	/// a pass-through second case, used internally by <c>Select</c> and <c>SelectMany</c>.
	/// </summary>
	internal sealed class ProjectedMatchableUnion<TOne, TTwo> : IMatchableUnion<TOne, TTwo>
		where TOne : notnull
		where TTwo : notnull
	{
		private readonly TOne? _one;
		private readonly TTwo? _two;
		private readonly bool _isOne;

		public ProjectedMatchableUnion(TOne one)
		{
			_one = one;
			_isOne = true;
		}

		public ProjectedMatchableUnion(TTwo two)
		{
			_two = two;
			_isOne = false;
		}

		public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two)
			=> _isOne ? one(_one!) : two(_two!);
	}

	/// <summary>
	/// Concrete implementation for three-case projected unions.
	/// </summary>
	internal sealed class ProjectedMatchableUnion<TOne, TTwo, TThree> : IMatchableUnion<TOne, TTwo, TThree>
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
	{
		private readonly TOne? _one;
		private readonly TTwo? _two;
		private readonly TThree? _three;
		private readonly int _state; // 0 = one, 1 = two, 2 = three

		public ProjectedMatchableUnion(TOne one)   { _one   = one;   _state = 0; }
		public ProjectedMatchableUnion(TTwo two)   { _two   = two;   _state = 1; }
		public ProjectedMatchableUnion(TThree three) { _three = three; _state = 2; }

		public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three)
			=> _state switch { 0 => one(_one!), 1 => two(_two!), _ => three(_three!) };
	}
}
