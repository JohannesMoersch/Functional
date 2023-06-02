namespace Functional.Tests;

public class EnumerableNullTestDataAttribute<TOne> : DataAttribute
{
	public EnumerableType Types { get; set; } = EnumerableType.AllTypes;

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in Array.Empty<TOne>().ToTestEnumerableVariants(Types)
		select new object[] { new NullTestInput.OneEnumerable<TOne>(one, new[] { true }) };
}

public class EnumerableNullTestDataAttribute<TOne, TTwo> : DataAttribute
{
	public EnumerableType TypesOne { get; set; } = EnumerableType.AllTypes;

	public EnumerableType TypesTwo { get; set; } = EnumerableType.AllTypes;

	public bool SkipSynchronous { get; set; } = false;

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in Array.Empty<TOne>().ToTestEnumerableVariants(TypesOne)
		from two in Array.Empty<TTwo>().ToTestEnumerableVariants(TypesTwo)
		where !SkipSynchronous || one.Type != EnumerableType.IEnumerable || two.Type != EnumerableType.IEnumerable
		select new object[] { new NullTestInput.TwoEnumerables<TOne, TTwo>(one, two, new[] { true, true }) };
}
