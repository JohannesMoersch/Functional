using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	public static class OptionOfStringExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<string> WhereNonEmpty(this Option<string> option)
			=> option.Where(s => !string.IsNullOrEmpty(s));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<string> WhereNonWhiteSpace(this Option<string> option)
			=> option.Where(s => !string.IsNullOrWhiteSpace(s));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<string>> WhereNonEmpty(this Task<Option<string>> option)
			=> (await option).WhereNonEmpty();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<string>> WhereNonWhiteSpace(this Task<Option<string>> option)
			=> (await option).WhereNonWhiteSpace();
	}
}