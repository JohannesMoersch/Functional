namespace Functional;

public static partial class Option
{
	public static async Task<Option<T>> CreateAsync<T>(bool isSome, Func<Task<T>> valueFactory)
		where T : notnull
	{
		if (valueFactory == null)
			throw new ArgumentNullException(nameof(valueFactory));

		return isSome
			? Some(await valueFactory.Invoke())
			: None<T>();
	}
}
