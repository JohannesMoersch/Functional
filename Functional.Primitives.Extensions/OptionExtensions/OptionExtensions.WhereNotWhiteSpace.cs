namespace Functional;

public static partial class OptionExtensions
{
	private static readonly Func<string, bool> _whereNonWhiteSpaceFunc = s => !string.IsNullOrWhiteSpace(s);

	public static Option<string> WhereNotWhiteSpace(this Option<string> option)
		=> option.Where(_whereNonWhiteSpaceFunc);

	public static async Task<Option<string>> WhereNotWhiteSpace(this Task<Option<string>> option)
		=> (await option).WhereNotWhiteSpace();
}
