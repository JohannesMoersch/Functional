namespace Functional.Tests;

public static class TestInput
{
	public record OneEnumerable<TOne>(TestEnumerable<TOne> One)
	{
		public override string ToString()
			=> $"{One.Type}({(One.Reference != null ? String.Join(", ", One.Reference) : "null")})";
	}

	public record TwoEnumerables<TOne, TTwo>(TestEnumerable<TOne> One, TestEnumerable<TTwo> Two)
	{
		public override string ToString()
			=> $"{One.Type}({(One.Reference != null ? String.Join(", ", One.Reference) : "null")}), {Two.Type}({(Two.Reference != null ? String.Join(", ", Two.Reference) : "null")})";
	}
}
