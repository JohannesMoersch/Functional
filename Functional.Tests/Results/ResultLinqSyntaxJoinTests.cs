using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultLinqSyntaxJoinTests
	{
		public class Standard : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>() 
			{
				new object[] { new[] { 0, 1 }, new[] { 4, 5, 6 }, new (int, int)?[] { (0, 4), (0, 6), (1, 5) } },
				new object[] { new[] { 7, 8, 9 }, new[] { 4, 5, 6 }, new (int, int)?[0] },
				new object[] { new int[0], new[] { 4, 5, 6 }, new (int, int)?[0] },
				new object[] { new[] { 0, 1 }, new int[0], new (int, int)?[0] }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class ResultStandard : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>()
			{
				new object[] { null, new[] { 4, 5, 6 }, new (int, int)?[] { null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class StandardResult : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>()
			{
				new object[] { new[] { 0, 1 }, null, new (int, int)?[] { null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class ResultResult : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>()
			{
				new object[] { null, null, new (int, int)?[] { null, null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		private static readonly Func<IEnumerable<int>, IEnumerable<int>> _source = values => values;

		private static readonly Func<IEnumerable<int>, Task<IEnumerable<int>>> _taskSource = values => Task.FromResult(values);

		private static readonly Func<IEnumerable<int>, IAsyncEnumerable<int>> _asyncSource = values => values.AsAsyncEnumerable();

		private static readonly Func<IEnumerable<int>, IResultEnumerable<int, string>> _resultSource = 
			values =>
				from value in Result.Create(values != null, () => values, () => "Failure")
				from result in value
				select result;

		private static readonly Func<IEnumerable<int>, IAsyncResultEnumerable<int, string>> _asyncResultSource =
			values => 
				from value in Result.CreateAsync(values != null, () => Task.FromResult(values), () => Task.FromResult("Failure"))
				from result in value
				select result;

		private static readonly Func<IEnumerable<int>, IEnumerable<int>> _join = values => values ?? Enumerable.Empty<int>();

		private static readonly Func<IEnumerable<int>, Task<IEnumerable<int>>> _taskJoin = values => Task.FromResult(values ?? Enumerable.Empty<int>());

		private static readonly Func<IEnumerable<int>, IAsyncEnumerable<int>> _asyncJoin = values => (values ?? Enumerable.Empty<int>()).AsAsyncEnumerable();

		private static readonly Func<IEnumerable<int>, Result<IEnumerable<int>, string>> _resultJoin = values => Result.Create(values != null, () => values, () => "Failure");

		private static readonly Func<IEnumerable<int>, Task<Result<IEnumerable<int>, string>>> _taskResultJoin = values => Result.CreateAsync(values != null, () => Task.FromResult(values), () => Task.FromResult("Failure"));

		private static readonly Func<IEnumerable<int>, Result<IAsyncEnumerable<int>, string>> _asyncResultJoin = values => Result.Create(values != null, () => values.AsAsyncEnumerable(), () => "Failure");

		private static readonly Func<IEnumerable<int>, Result<int[], string>> _resultJoinArray = values => Result.Create(values != null, () => values.ToArray(), () => "Failure");

		private static readonly Func<IEnumerable<int>, Task<Result<int[], string>>> _taskResultJoinArray = values => Result.CreateAsync(values != null, () => Task.FromResult(values.ToArray()), () => Task.FromResult("Failure"));

		private static readonly Func<IEnumerable<(int, int)?>, IEnumerable<(int, int)>> _output = values => values.OfType<(int, int)>();

		private static readonly Func<IEnumerable<(int, int)?>, IEnumerable<Result<(int, int), string>>> _resultOutput = values => values.Select(i => Option.FromNullable(i).ToResult(() => "Failure"));

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
		[ClassData(typeof(StandardResult))]
		public void EnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task EnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task EnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public void EnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task EnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
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
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
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
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public void ResultEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		public Task ResultEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		public Task ResultEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public void ResultEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task ResultEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task ResultEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public void ResultEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task ResultEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public Task AsyncResultEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public Task AsyncResultEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public Task AsyncResultEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
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
		[ClassData(typeof(StandardResult))]
		public void EnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task EnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task EnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public void EnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task EnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
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
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task TaskEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
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
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(StandardResult))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public void ResultEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		public Task ResultEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		public Task ResultEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public void ResultEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task ResultEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task ResultEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public void ResultEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
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
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task ResultEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public Task AsyncResultEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public Task AsyncResultEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		public Task AsyncResultEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(Standard))]
		[ClassData(typeof(ResultStandard))]
		[ClassData(typeof(StandardResult))]
		[ClassData(typeof(ResultResult))]
		public Task AsyncResultEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));
	}
}
