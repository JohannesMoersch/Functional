namespace Functional.Tests;

public class EnumerableNullTestDataAttribute<TOne> : DataAttribute
{
	public EnumerableType Types { get; set; } = EnumerableType.AllTypes;

	public int AdditionalArgumentCount { get; set; }

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in Array.Empty<TOne>().ToTestEnumerableVariants(Types)
		from isNull in Enumerable
			.Range(0, AdditionalArgumentCount + 1)
			.Select(i =>  Enumerable.Range(0, AdditionalArgumentCount + 1).Select(o => o == i).ToArray())
		select new object[] { new NullTestInput.OneEnumerable<TOne>(one, isNull) };
}

public class EnumerableNullTestDataAttribute<TOne, TTwo> : DataAttribute
{
	public EnumerableType TypesOne { get; set; } = EnumerableType.AllTypes;

	public EnumerableType TypesTwo { get; set; } = EnumerableType.AllTypes;

	public int AdditionalArgumentCount { get; set; }

	public bool SkipSynchronous { get; set; } = false;

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in Array.Empty<TOne>().ToTestEnumerableVariants(TypesOne)
		from two in Array.Empty<TTwo>().ToTestEnumerableVariants(TypesTwo)
		where !SkipSynchronous || one.Type != EnumerableType.IEnumerable || two.Type != EnumerableType.IEnumerable
		from isNull in Enumerable
			.Range(0, AdditionalArgumentCount + 2)
			.Select(i => Enumerable.Range(0, AdditionalArgumentCount + 1).Select(o => o == i).ToArray())
		select new object[] { new NullTestInput.TwoEnumerables<TOne, TTwo>(one, two, isNull) };
}
