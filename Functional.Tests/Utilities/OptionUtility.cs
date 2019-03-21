using System.Threading.Tasks;

namespace Functional
{
	public static class OptionUtility
	{
		public static TValue AssertSome<TValue>(this Option<TValue> Option)
			=> Option.Match(s => s, () => throw new System.Exception("Option should be success."));

		public static async Task<TValue> AssertSome<TValue>(this Task<Option<TValue>> Option)
			=> (await Option).Match(s => s, () => throw new System.Exception("Option should be success."));

		public static void AssertNone<TValue>(this Option<TValue> Option)
			=> Option.Match(s => throw new System.Exception("Option should be failure."), () => 0);

		public static async Task AssertNone<TValue>(this Task<Option<TValue>> Option)
			=> (await Option).Match(s => throw new System.Exception("Option should be failure."), () => 0);
	}
}
