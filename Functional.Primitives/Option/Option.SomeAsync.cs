namespace Functional;

public static partial class Option
{
	public static async Task<Option<T>> SomeAsync<T>(Task<T> value)
		where T : notnull
		=> Some(await value);
}
