namespace Functional.Unions;

public static partial class Code
{
	public static partial class DiscriminatedUnion
	{
		public const string Namespace = "Functional";
		public const string Name = "DiscriminatedUnion";

		public static int MaxSupportedTypes => _numbers.Count;

		private static readonly IReadOnlyList<string> _numbers = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
	}
}
