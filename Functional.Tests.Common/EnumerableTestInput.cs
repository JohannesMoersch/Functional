namespace Functional.Tests;

public record EnumerableTestInput<TOne>(TestEnumerable<TOne> One)
{
	public override string ToString()
		=> $"{One.Type}({(One.Reference != null ? String.Join(", ", One.Reference) : "null")})";
}

public record EnumerableTestInput<TOne, TTwo>(TestEnumerable<TOne> One, TestEnumerable<TTwo> Two)
{
	public override string ToString()
		=> $"{One.Type}({(One.Reference != null ? String.Join(", ", One.Reference) : "null")}), {Two.Type}({(Two.Reference != null ? String.Join(", ", Two.Reference) : "null")})";
}
