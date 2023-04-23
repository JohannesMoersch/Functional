namespace Functional;

public static partial class ResultExtensions
{
	public static Result<T2, T1> Transpose<T1, T2>(this Result<T1, T2> source)
		where T1 : notnull
		where T2 : notnull
		=> source.TryGetValue(out var success, out var failure) ? Result.Failure<T2, T1>(success) : Result.Success<T2, T1>(failure);

	public static async Task<Result<T2, T1>> Transpose<T1, T2>(this Task<Result<T1, T2>> source)
		where T1 : notnull
		where T2 : notnull
		=> (await source).Transpose();
}
