namespace Functional;

public static partial class Option
{
	public static Option<T> FromNullable<T>(T? value)
		where T : class
		=> value != null
			? Some(value)
			: None<T>();

	public static Option<T> FromNullable<T>(T? value)
		where T : struct
		=> value.HasValue
			? Some(value.Value)
			: None<T>();
}
