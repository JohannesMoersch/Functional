namespace Functional;

public static partial class OptionExtensions
{
	private static readonly Func<string, bool> _whereNonEmptyFunc = s => !string.IsNullOrEmpty(s);

	public static Option<string> WhereNotEmpty(this Option<string> option)
		=> option.Where(_whereNonEmptyFunc);

	public static async Task<Option<string>> WhereNotEmpty(this Task<Option<string>> option)
	=> (await option).WhereNotEmpty();
}
