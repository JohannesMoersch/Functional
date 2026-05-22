using System;
using System.Runtime.CompilerServices;

namespace Functional.Native
{
public union Union<TOne, TTwo>(TOne?, TTwo?)
	where TOne : notnull
	where TTwo : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two)
		=> this switch { TOne v => one(v), TTwo v => two(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; }
	}
}

public union Union<TOne, TTwo, TThree>(TOne?, TTwo?, TThree?)
	where TOne : notnull
	where TTwo : notnull
	where TThree : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three)
		=> this switch { TOne v => one(v), TTwo v => two(v), TThree v => three(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two, Action<TThree> three)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; case TThree v: three(v); break; }
	}
}

public union Union<TOne, TTwo, TThree, TFour>(TOne?, TTwo?, TThree?, TFour?)
	where TOne : notnull
	where TTwo : notnull
	where TThree : notnull
	where TFour : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four)
		=> this switch { TOne v => one(v), TTwo v => two(v), TThree v => three(v), TFour v => four(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; case TThree v: three(v); break; case TFour v: four(v); break; }
	}
}

public union Union<TOne, TTwo, TThree, TFour, TFive>(TOne?, TTwo?, TThree?, TFour?, TFive?)
	where TOne : notnull
	where TTwo : notnull
	where TThree : notnull
	where TFour : notnull
	where TFive : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five)
		=> this switch { TOne v => one(v), TTwo v => two(v), TThree v => three(v), TFour v => four(v), TFive v => five(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; case TThree v: three(v); break; case TFour v: four(v); break; case TFive v: five(v); break; }
	}
}

public union Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TOne?, TTwo?, TThree?, TFour?, TFive?, TSix?)
	where TOne : notnull
	where TTwo : notnull
	where TThree : notnull
	where TFour : notnull
	where TFive : notnull
	where TSix : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six)
		=> this switch { TOne v => one(v), TTwo v => two(v), TThree v => three(v), TFour v => four(v), TFive v => five(v), TSix v => six(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; case TThree v: three(v); break; case TFour v: four(v); break; case TFive v: five(v); break; case TSix v: six(v); break; }
	}
}

public union Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TOne?, TTwo?, TThree?, TFour?, TFive?, TSix?, TSeven?)
	where TOne : notnull
	where TTwo : notnull
	where TThree : notnull
	where TFour : notnull
	where TFive : notnull
	where TSix : notnull
	where TSeven : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven)
		=> this switch { TOne v => one(v), TTwo v => two(v), TThree v => three(v), TFour v => four(v), TFive v => five(v), TSix v => six(v), TSeven v => seven(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; case TThree v: three(v); break; case TFour v: four(v); break; case TFive v: five(v); break; case TSix v: six(v); break; case TSeven v: seven(v); break; }
	}
}

public union Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TOne?, TTwo?, TThree?, TFour?, TFive?, TSix?, TSeven?, TEight?)
	where TOne : notnull
	where TTwo : notnull
	where TThree : notnull
	where TFour : notnull
	where TFive : notnull
	where TSix : notnull
	where TSeven : notnull
	where TEight : notnull
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TResult Match<TResult>(Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven, Func<TEight, TResult> eight)
		=> this switch { TOne v => one(v), TTwo v => two(v), TThree v => three(v), TFour v => four(v), TFive v => five(v), TSix v => six(v), TSeven v => seven(v), TEight v => eight(v) };

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Match(Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
	{
		switch (this) { case TOne v: one(v); break; case TTwo v: two(v); break; case TThree v: three(v); break; case TFour v: four(v); break; case TFive v: five(v); break; case TSix v: six(v); break; case TSeven v: seven(v); break; case TEight v: eight(v); break; }
	}
}
}
