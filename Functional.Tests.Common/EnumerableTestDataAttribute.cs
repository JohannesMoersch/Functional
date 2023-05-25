namespace Functional.Tests;

public class EnumerableTestDataAttribute<TOne> : DataAttribute
{
	private readonly TOne[]? _one;

	public EnumerableType Types { get; set; } = EnumerableType.AllTypes;

	public EnumerableTestDataAttribute(TOne[]? one)
		=> _one = one;

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in _one.ToTestEnumerableVariants(Types)
		select new object[] { new EnumerableTestInput<TOne>(one) };
}

public class EnumerableTestDataAttribute<TOne, TTwo> : DataAttribute
{
	private readonly TOne[]? _one;
	private readonly TTwo[]? _two;

	public EnumerableType TypesOne { get; set; } = EnumerableType.AllTypes;

	public EnumerableType TypesTwo { get; set; } = EnumerableType.AllTypes;

	public bool SkipSynchronous { get; set; } = false;

	public EnumerableTestDataAttribute(TOne[]? one, TTwo[]? two)
	{
		_one = one;
		_two = two;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in _one.ToTestEnumerableVariants(TypesOne)
		from two in _two.ToTestEnumerableVariants(TypesTwo)
		where !SkipSynchronous || one.Type != EnumerableType.IEnumerable || two.Type != EnumerableType.IEnumerable
		select new object[] { new EnumerableTestInput<TOne, TTwo>(one, two) };
}
