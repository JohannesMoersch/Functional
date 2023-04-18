namespace Functional;

public static partial class Result
{
	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2), TFailure[]> Zip<TSuccess1, TSuccess2, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess())
			return Success<(TSuccess1, TSuccess2), TFailure[]>((r1.SuccessUnsafe(), r2.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(2);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(3);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3, TSuccess4), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3,
		Result<TSuccess4, TFailure> r4
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TSuccess4 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess() && r4.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3, TSuccess4), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe(),
				r4.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(4);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());
		if (!r4.IsSuccess())
			errorCollection.Add(r4.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3, TSuccess4), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3,
		Result<TSuccess4, TFailure> r4,
		Result<TSuccess5, TFailure> r5
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TSuccess4 : notnull
		where TSuccess5 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess() && r4.IsSuccess() && r5.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe(),
				r4.SuccessUnsafe(),
				r5.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(5);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());
		if (!r4.IsSuccess())
			errorCollection.Add(r4.FailureUnsafe());
		if (!r5.IsSuccess())
			errorCollection.Add(r5.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3,
		Result<TSuccess4, TFailure> r4,
		Result<TSuccess5, TFailure> r5,
		Result<TSuccess6, TFailure> r6
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TSuccess4 : notnull
		where TSuccess5 : notnull
		where TSuccess6 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess() && r4.IsSuccess() && r5.IsSuccess() && r6.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe(),
				r4.SuccessUnsafe(),
				r5.SuccessUnsafe(),
				r6.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(6);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());
		if (!r4.IsSuccess())
			errorCollection.Add(r4.FailureUnsafe());
		if (!r5.IsSuccess())
			errorCollection.Add(r5.FailureUnsafe());
		if (!r6.IsSuccess())
			errorCollection.Add(r6.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3,
		Result<TSuccess4, TFailure> r4,
		Result<TSuccess5, TFailure> r5,
		Result<TSuccess6, TFailure> r6,
		Result<TSuccess7, TFailure> r7
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TSuccess4 : notnull
		where TSuccess5 : notnull
		where TSuccess6 : notnull
		where TSuccess7 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess() && r4.IsSuccess() && r5.IsSuccess() && r6.IsSuccess() && r7.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe(),
				r4.SuccessUnsafe(),
				r5.SuccessUnsafe(),
				r6.SuccessUnsafe(),
				r7.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(7);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());
		if (!r4.IsSuccess())
			errorCollection.Add(r4.FailureUnsafe());
		if (!r5.IsSuccess())
			errorCollection.Add(r5.FailureUnsafe());
		if (!r6.IsSuccess())
			errorCollection.Add(r6.FailureUnsafe());
		if (!r7.IsSuccess())
			errorCollection.Add(r7.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3,
		Result<TSuccess4, TFailure> r4,
		Result<TSuccess5, TFailure> r5,
		Result<TSuccess6, TFailure> r6,
		Result<TSuccess7, TFailure> r7,
		Result<TSuccess8, TFailure> r8
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TSuccess4 : notnull
		where TSuccess5 : notnull
		where TSuccess6 : notnull
		where TSuccess7 : notnull
		where TSuccess8 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess() && r4.IsSuccess() && r5.IsSuccess() && r6.IsSuccess() && r7.IsSuccess() && r8.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe(),
				r4.SuccessUnsafe(),
				r5.SuccessUnsafe(),
				r6.SuccessUnsafe(),
				r7.SuccessUnsafe(),
				r8.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(8);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());
		if (!r4.IsSuccess())
			errorCollection.Add(r4.FailureUnsafe());
		if (!r5.IsSuccess())
			errorCollection.Add(r5.FailureUnsafe());
		if (!r6.IsSuccess())
			errorCollection.Add(r6.FailureUnsafe());
		if (!r7.IsSuccess())
			errorCollection.Add(r7.FailureUnsafe());
		if (!r8.IsSuccess())
			errorCollection.Add(r8.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8), TFailure[]>(errorCollection.ToArray());
	}

	[AllowAllocations(allowNewObjTypes: typeof(List<>))]
	public static Result<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9), TFailure[]> Zip<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TFailure>
	(
		Result<TSuccess1, TFailure> r1,
		Result<TSuccess2, TFailure> r2,
		Result<TSuccess3, TFailure> r3,
		Result<TSuccess4, TFailure> r4,
		Result<TSuccess5, TFailure> r5,
		Result<TSuccess6, TFailure> r6,
		Result<TSuccess7, TFailure> r7,
		Result<TSuccess8, TFailure> r8,
		Result<TSuccess9, TFailure> r9
	)
		where TSuccess1 : notnull
		where TSuccess2 : notnull
		where TSuccess3 : notnull
		where TSuccess4 : notnull
		where TSuccess5 : notnull
		where TSuccess6 : notnull
		where TSuccess7 : notnull
		where TSuccess8 : notnull
		where TSuccess9 : notnull
		where TFailure : notnull
	{
		if (r1.IsSuccess() && r2.IsSuccess() && r3.IsSuccess() && r4.IsSuccess() && r5.IsSuccess() && r6.IsSuccess() && r7.IsSuccess() && r8.IsSuccess() && r9.IsSuccess())
			return Success<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9), TFailure[]>((
				r1.SuccessUnsafe(),
				r2.SuccessUnsafe(),
				r3.SuccessUnsafe(),
				r4.SuccessUnsafe(),
				r5.SuccessUnsafe(),
				r6.SuccessUnsafe(),
				r7.SuccessUnsafe(),
				r8.SuccessUnsafe(),
				r9.SuccessUnsafe()));

		var errorCollection = new List<TFailure>(9);
		if (!r1.IsSuccess())
			errorCollection.Add(r1.FailureUnsafe());
		if (!r2.IsSuccess())
			errorCollection.Add(r2.FailureUnsafe());
		if (!r3.IsSuccess())
			errorCollection.Add(r3.FailureUnsafe());
		if (!r4.IsSuccess())
			errorCollection.Add(r4.FailureUnsafe());
		if (!r5.IsSuccess())
			errorCollection.Add(r5.FailureUnsafe());
		if (!r6.IsSuccess())
			errorCollection.Add(r6.FailureUnsafe());
		if (!r7.IsSuccess())
			errorCollection.Add(r7.FailureUnsafe());
		if (!r8.IsSuccess())
			errorCollection.Add(r8.FailureUnsafe());
		if (!r9.IsSuccess())
			errorCollection.Add(r9.FailureUnsafe());

		return Failure<(TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9), TFailure[]>(errorCollection.ToArray());
	}

	private static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> source.Match(static _ => _, static _ => throw new InvalidOperationException("Not a successful result!"));

	private static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> source.Match(static _ => throw new InvalidOperationException("Not a faulted result!"), static _ => _);
}
