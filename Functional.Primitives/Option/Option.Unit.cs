namespace Functional;

public static partial class Option
{
	public static Option<Unit> Unit()
		=> Some(Functional.Unit.Value);
}
