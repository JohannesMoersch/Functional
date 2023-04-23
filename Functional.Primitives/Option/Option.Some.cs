namespace Functional;

public static partial class Option
{
	public static Option<T> Some<T>(T value)
		where T : notnull
	{
		if (value == null)
			throw new ArgumentNullException(nameof(value));

		return new Option<T>(true, value);
	}
}
