using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	public static class OptionOfStringExtensions
	{
		private static readonly Func<string, bool> _whereNonEmptyFunc = s => !string.IsNullOrEmpty(s);
		private static readonly Func<string, bool> _whereNonWhiteSpaceFunc = s => !string.IsNullOrWhiteSpace(s);


		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<string> WhereNonEmpty(this Option<string> option)
			=> option.Where(_whereNonEmptyFunc);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<string> WhereNonWhiteSpace(this Option<string> option)
			=> option.Where(_whereNonWhiteSpaceFunc);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<string>> WhereNonEmpty(this Task<Option<string>> option)
			=> (await option).WhereNonEmpty();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<string>> WhereNonWhiteSpace(this Task<Option<string>> option)
			=> (await option).WhereNonWhiteSpace();
	}
}