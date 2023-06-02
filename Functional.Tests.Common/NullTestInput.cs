namespace Functional.Tests;

public static class NullTestInput
{
	public record OneEnumerable<TOne>(TestEnumerable<TOne> One, bool[] IsNull)
	{
		public override string ToString()
			=> $"{One.Type}({(One.Reference != null ? String.Join(", ", One.Reference) : "null")})";
	}

	public record TwoEnumerables<TOne, TTwo>(TestEnumerable<TOne> One, TestEnumerable<TTwo> Two, bool[] IsNull)
	{
		public override string ToString()
			=> $"{One.Type}({(One.Reference != null ? String.Join(", ", One.Reference) : "null")}), {Two.Type}({(Two.Reference != null ? String.Join(", ", Two.Reference) : "null")})";
	}
}
