namespace Functional;

public static partial class OptionExtensions
{
	private static readonly Func<string, bool> _whereNonEmptyFunc = s => !string.IsNullOrEmpty(s);
	private static readonly Func<string, bool> _whereNonWhiteSpaceFunc = s => !string.IsNullOrWhiteSpace(s);


	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Option<string> WhereNotEmpty(this Option<string> option)
		=> option.Where(_whereNonEmptyFunc);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Option<string> WhereNotWhiteSpace(this Option<string> option)
		=> option.Where(_whereNonWhiteSpaceFunc);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Option<string>> WhereNotEmpty(this Task<Option<string>> option)
		=> (await option).WhereNotEmpty();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Option<string>> WhereNotWhiteSpace(this Task<Option<string>> option)
		=> (await option).WhereNotWhiteSpace();
}