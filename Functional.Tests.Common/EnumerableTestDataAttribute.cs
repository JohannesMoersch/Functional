namespace Functional.Tests;

public class EnumerableTestDataAttribute<TOne> : DataAttribute
{
	public EnumerableType Types { get; set; } = EnumerableType.AsyncTypes;

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in Types.ToIndividualEnumerableTypes()
		select new object[] { new TestInput.OneEnumerable<TOne>(one) };
}

public class EnumerableTestDataAttribute<TOne, TTwo> : DataAttribute
{
	public EnumerableType TypesOne { get; set; } = EnumerableType.AllTypes;
	 
	public EnumerableType TypesTwo { get; set; } = EnumerableType.AllTypes;

	public bool SkipSynchronous { get; set; } = true;

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		=>
		from one in TypesOne.ToIndividualEnumerableTypes()
		from two in TypesTwo.ToIndividualEnumerableTypes()
		where !SkipSynchronous || one != EnumerableType.IEnumerable || two != EnumerableType.IEnumerable
		select new object[] { new TestInput.TwoEnumerables<TOne, TTwo>(one, two) };
}
