namespace Functional;

public static partial class Option
{
	public static async Task<Option<T>> FromNullableAsync<T>(Task<T?> value)
		where T : class
		=> FromNullable(await value);

	public static async Task<Option<T>> FromNullableAsync<T>(Task<T?> value)
		where T : struct
		=> FromNullable(await value);
}
