namespace Functional.Tests;

public class EnumerableTestDataAttribute<TOne> : TheoryDataAttribute
{
	public EnumerableType Types { get; set; } = EnumerableType.AsyncTypes;

	public bool SkipNullTests { get; set; } = false;

	public int AdditionalArgumentCount { get; set; }

	public override IEnumerable<object[]> GetData()
		=>
		from one in Types.ToIndividualEnumerableTypes()
		let argumentCount = 1 + AdditionalArgumentCount
		let testCount = argumentCount + 1
		from isNull in Enumerable
			.Range(-1, SkipNullTests ? 1 : testCount)
			.Select(i => Enumerable.Range(0, argumentCount).Select(o => o == i).ToArray())
		select new object[] { new TestInput.OneEnumerable<TOne>(one, isNull) };
}

public class EnumerableTestDataAttribute<TOne, TTwo> : TheoryDataAttribute
{
	public EnumerableType TypesOne { get; set; } = EnumerableType.AllTypes;
	 
	public EnumerableType TypesTwo { get; set; } = EnumerableType.AllTypes;

	public bool SkipSynchronous { get; set; } = true;

	public bool SkipNullTests { get; set; } = false;

	public int AdditionalArgumentCount { get; set; }

	public override IEnumerable<object[]> GetData()
		=>
		from one in TypesOne.ToIndividualEnumerableTypes()
		from two in TypesTwo.ToIndividualEnumerableTypes()
		where !SkipSynchronous || one != EnumerableType.IEnumerable || two != EnumerableType.IEnumerable
		let argumentCount = 2 + AdditionalArgumentCount
		let testCount = argumentCount + 1
		from isNull in Enumerable
			.Range(-1, SkipNullTests ? 1 : testCount)
			.Select(i => Enumerable.Range(0, argumentCount).Select(o => o == i).ToArray())
		select new object[] { new TestInput.TwoEnumerables<TOne, TTwo>(one, two, isNull) };
}
