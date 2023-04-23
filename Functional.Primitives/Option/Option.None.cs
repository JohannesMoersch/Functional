namespace Functional;

public static partial class Option
{
	public static PartialOption.None None()
		=> new PartialOption.None();

	public static Option<T> None<T>()
		where T : notnull
#pragma warning disable CS8604 // Possible null reference argument.
		=> new Option<T>(false, default);
#pragma warning restore CS8604 // Possible null reference argument.
}
