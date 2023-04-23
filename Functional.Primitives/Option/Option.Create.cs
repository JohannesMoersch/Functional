namespace Functional;

public static partial class Option
{
	public static Option<T> Create<T>(bool isSome, T value)
		where T : notnull
		=> isSome
			? Some(value)
			: None<T>();

	public static Option<T> Create<T>(bool isSome, Func<T> valueFactory)
		where T : notnull
	{
		if (valueFactory == null)
			throw new ArgumentNullException(nameof(valueFactory));

		return isSome
			? Some(valueFactory.Invoke())
			: None<T>();
	}
}
