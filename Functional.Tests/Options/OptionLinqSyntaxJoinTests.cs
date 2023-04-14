using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionLinqSyntaxJoinTests
	{
		public class Standard : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>()
			{
				new object[] { new[] { 0, 1 }, new[] { 4, 5, 6 }, new (int, int)?[] { (0, 4), (0, 6), (1, 5) } },
				new object[] { new[] { 7, 8, 9 }, new[] { 4, 5, 6 }, Array.Empty<(int, int)?>() },
				new object[] { Array.Empty<int>(), new[] { 4, 5, 6 }, Array.Empty<(int, int)?>() },
				new object[] { new[] { 0, 1 }, Array.Empty<int>(), Array.Empty<(int, int)?>() }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class OptionStandard : IEnumerable<object?[]>
		{
			public IEnumerator<object?[]> GetEnumerator() => new List<object?[]>()
			{
				new object?[] { null, new[] { 4, 5, 6 }, new (int, int)?[] { null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class StandardOption : IEnumerable<object?[]>
		{
			public IEnumerator<object?[]> GetEnumerator() => new List<object?[]>()
			{
				new object?[] { new[] { 0, 1 }, null, new (int, int)?[] { null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class OptionOption : IEnumerable<object?[]>
		{
			public IEnumerator<object?[]> GetEnumerator() => new List<object?[]>()
			{
				new object?[] { null, null, new (int, int)?[] { null, null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		private static readonly Func<IEnumerable<int>, IEnumerable<int>> _source = values => values;

		private static readonly Func<IEnumerable<int>, Task<IEnumerable<int>>> _taskSource = values => Task.FromResult(values);

		private static readonly Func<IEnumerable<int>, IAsyncEnumerable<int>> _asyncSource = values => values.AsAsyncEnumerable();

		private static readonly Func<IEnumerable<int>?, IOptionEnumerable<int>> _resultSource =
			values =>
				from value in Option.FromNullable(values)
				from result in value
				select result;

		private static readonly Func<IEnumerable<int>?, IAsyncOptionEnumerable<int>> _asyncOptionSource =
			values =>
				from value in Option.FromNullableAsync(Task.FromResult(values))
				from result in value
				select result;

		private static readonly Func<IEnumerable<int>?, IEnumerable<int>> _join = values => values ?? Enumerable.Empty<int>();

		private static readonly Func<IEnumerable<int>?, Task<IEnumerable<int>>> _taskJoin = values => Task.FromResult(values ?? Enumerable.Empty<int>());

		private static readonly Func<IEnumerable<int>?, IAsyncEnumerable<int>> _asyncJoin = values => (values ?? Enumerable.Empty<int>()).AsAsyncEnumerable();

		private static readonly Func<IEnumerable<int>?, Option<IEnumerable<int>>> _resultJoin = values => Option.FromNullable(values);

		private static readonly Func<IEnumerable<int>?, Task<Option<IEnumerable<int>>>> _taskOptionJoin = values => Option.FromNullableAsync(Task.FromResult(values));

		private static readonly Func<IEnumerable<int>?, Option<IAsyncEnumerable<int>>> _asyncOptionJoin = values => Option.FromNullable(values?.AsAsyncEnumerable());

		private static readonly Func<IEnumerable<int>?, Option<int[]>> _resultJoinArray = values => Option.FromNullable(values?.ToArray());

		private static readonly Func<IEnumerable<int>?, Task<Option<int[]>>> _taskOptionJoinArray = values => Option.FromNullableAsync(Task.FromResult(values?.ToArray()));

		private static readonly Func<IEnumerable<(int, int)?>, IEnumerable<(int, int)>> _output = values => values.OfType<(int, int)>();

		private static readonly Func<IEnumerable<(int, int)?>, IEnumerable<Option<(int, int)>>> _resultOutput = values => values.Select(i => Option.FromNullable(i));

		[Theory]
		[ClassData(typeof(Standard))]
		public void EnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task EnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task EnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public void EnumerableJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task EnumerableJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task EnumerableJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public void EnumerableJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task EnumerableJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task TaskEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task TaskEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task TaskEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task AsyncEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task AsyncEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task AsyncEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public void OptionEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task OptionEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task OptionEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public void OptionEnumerableJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task OptionEnumerableJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task OptionEnumerableJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public void OptionEnumerableJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task OptionEnumerableJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task AsyncOptionEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task AsyncOptionEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task AsyncOptionEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public void EnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task EnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task EnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public void EnumerableGroupJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task EnumerableGroupJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task EnumerableGroupJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public void EnumerableGroupJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task EnumerableGroupJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task TaskEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task TaskEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task TaskEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableGroupJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableGroupJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableGroupJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableGroupJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task TaskEnumerableGroupJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task AsyncEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		public Task AsyncEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableGroupJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableGroupJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableGroupJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardOption))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public void OptionEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task OptionEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task OptionEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public void OptionEnumerableGroupJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task OptionEnumerableGroupJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task OptionEnumerableGroupJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public void OptionEnumerableGroupJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task OptionEnumerableGroupJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstTaskOptionOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _taskOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstOptionOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _asyncOptionJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(OptionStandard))]
		[ClassData(typeof(StandardOption))]
		[ClassData(typeof(OptionOption))]
		public Task AsyncOptionEnumerableGroupJoinedAgainstTaskOptionOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncOptionSource.Invoke(source)
				join joinValue in _taskOptionJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));
	}
}
