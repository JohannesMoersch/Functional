namespace Functional;

public static partial class Option
{
	public static Option<Unit> Where(bool isSuccess)
		=> Create(isSuccess, Functional.Unit.Value);
}
