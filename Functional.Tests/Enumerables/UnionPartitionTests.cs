using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class UnionPartitionTests
	{
		private class OneDefinition : UnionDefinition<OneDefinition, sbyte, byte> { }

		private IEnumerable<Union<OneDefinition>> CreateDefinitionArray()
			=> new[]
			{
				Union.FromDefinition<OneDefinition>().Create((sbyte)1),
				Union.FromDefinition<OneDefinition>().Create((byte)1),
			};

		[Fact]
		public void DefinitionPartition()
		{
			var (ones, twos) = CreateTypesTwoArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
		}

		[Fact]
		public async Task TaskDefinitionPartition()
		{
			var (ones, twos) = Task.FromResult(CreateTypesTwoArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
		}

		[Fact]
		public async Task AsyncDefinitionPartition()
		{
			var (ones, twos) = Task.FromResult(CreateTypesTwoArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
		}

		private IEnumerable<Union<sbyte, byte>> CreateTypesTwoArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte>().Create((byte)1),
			};

		[Fact]
		public void TwoPartition()
		{
			var (ones, twos) = CreateTypesTwoArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
		}

		[Fact]
		public async Task TaskTwoPartition()
		{
			var (ones, twos) = Task.FromResult(CreateTypesTwoArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
		}

		[Fact]
		public async Task AsyncTwoPartition()
		{
			var (ones, twos) = Task.FromResult(CreateTypesTwoArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
		}

		private IEnumerable<Union<sbyte, byte, short>> CreateTypesThreeArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte, short>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte, short>().Create((byte)1),
				Union.FromTypes<sbyte, byte, short>().Create((short)1),
			};

		[Fact]
		public void ThreePartition()
		{
			var (ones, twos, threes) = CreateTypesThreeArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
			threes.Should().BeEquivalentTo(new[] { (short)1 });
		}

		[Fact]
		public async Task TaskThreePartition()
		{
			var (ones, twos, threes) = Task.FromResult(CreateTypesThreeArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
		}

		[Fact]
		public async Task AsyncThreePartition()
		{
			var (ones, twos, threes) = Task.FromResult(CreateTypesThreeArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
		}

		private IEnumerable<Union<sbyte, byte, short, ushort>> CreateTypesFourArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte, short, ushort>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte, short, ushort>().Create((byte)1),
				Union.FromTypes<sbyte, byte, short, ushort>().Create((short)1),
				Union.FromTypes<sbyte, byte, short, ushort>().Create((ushort)1),
			};

		[Fact]
		public void FourPartition()
		{
			var (ones, twos, threes, fours) = CreateTypesFourArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
			threes.Should().BeEquivalentTo(new[] { (short)1 });
			fours.Should().BeEquivalentTo(new[] { (ushort)1 });
		}

		[Fact]
		public async Task TaskFourPartition()
		{
			var (ones, twos, threes, fours) = Task.FromResult(CreateTypesFourArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
		}

		[Fact]
		public async Task AsyncFourPartition()
		{
			var (ones, twos, threes, fours) = Task.FromResult(CreateTypesFourArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
		}

		private IEnumerable<Union<sbyte, byte, short, ushort, int>> CreateTypesFiveArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte, short, ushort, int>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int>().Create((byte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int>().Create((short)1),
				Union.FromTypes<sbyte, byte, short, ushort, int>().Create((ushort)1),
				Union.FromTypes<sbyte, byte, short, ushort, int>().Create(1),
			};

		[Fact]
		public void FivePartition()
		{
			var (ones, twos, threes, fours, fives) = CreateTypesFiveArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
			threes.Should().BeEquivalentTo(new[] { (short)1 });
			fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			fives.Should().BeEquivalentTo(new[] { 1 });
		}

		[Fact]
		public async Task TaskFivePartition()
		{
			var (ones, twos, threes, fours, fives) = Task.FromResult(CreateTypesFiveArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
		}

		[Fact]
		public async Task AsyncFivePartition()
		{
			var (ones, twos, threes, fours, fives) = Task.FromResult(CreateTypesFiveArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
		}

		private IEnumerable<Union<sbyte, byte, short, ushort, int, uint>> CreateTypesSixArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((byte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((short)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((ushort)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create(1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((uint)1),
			};

		[Fact]
		public void SixPartition()
		{
			var (ones, twos, threes, fours, fives, sixes) = CreateTypesSixArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
			threes.Should().BeEquivalentTo(new[] { (short)1 });
			fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			fives.Should().BeEquivalentTo(new[] { 1 });
			sixes.Should().BeEquivalentTo(new[] { (uint)1 });
		}

		[Fact]
		public async Task TaskSixPartition()
		{
			var (ones, twos, threes, fours, fives, sixes) = Task.FromResult(CreateTypesSixArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
			await sixes.Should().BeEquivalentTo(new[] { (uint)1 });
		}

		[Fact]
		public async Task AsyncSixPartition()
		{
			var (ones, twos, threes, fours, fives, sixes) = Task.FromResult(CreateTypesSixArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
			await sixes.Should().BeEquivalentTo(new[] { (uint)1 });
		}

		private IEnumerable<Union<sbyte, byte, short, ushort, int, uint, long>> CreateTypesSevenArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((byte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((short)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((ushort)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create(1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((uint)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((long)1),
			};

		[Fact]
		public void SevenPartition()
		{
			var (ones, twos, threes, fours, fives, sixes, sevens) = CreateTypesSevenArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
			threes.Should().BeEquivalentTo(new[] { (short)1 });
			fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			fives.Should().BeEquivalentTo(new[] { 1 });
			sixes.Should().BeEquivalentTo(new[] { (uint)1 });
			sevens.Should().BeEquivalentTo(new[] { (long)1 });
		}

		[Fact]
		public async Task TaskSevenPartition()
		{
			var (ones, twos, threes, fours, fives, sixes, sevens) = Task.FromResult(CreateTypesSevenArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
			await sixes.Should().BeEquivalentTo(new[] { (uint)1 });
			await sevens.Should().BeEquivalentTo(new[] { (long)1 });
		}

		[Fact]
		public async Task AsyncSevenPartition()
		{
			var (ones, twos, threes, fours, fives, sixes, sevens) = Task.FromResult(CreateTypesSevenArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
			await sixes.Should().BeEquivalentTo(new[] { (uint)1 });
			await sevens.Should().BeEquivalentTo(new[] { (long)1 });
		}

		private IEnumerable<Union<sbyte, byte, short, ushort, int, uint, long, ulong>> CreateTypesEightArray()
			=> new[]
			{
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((sbyte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((byte)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((short)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((ushort)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create(1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((uint)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((long)1),
				Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((ulong)1)
			};

		[Fact]
		public void EightPartition()
		{
			var (ones, twos, threes, fours, fives, sixes, sevens, eights) = CreateTypesEightArray().Value().Partition();

			ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			twos.Should().BeEquivalentTo(new[] { (byte)1 });
			threes.Should().BeEquivalentTo(new[] { (short)1 });
			fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			fives.Should().BeEquivalentTo(new[] { 1 });
			sixes.Should().BeEquivalentTo(new[] { (uint)1 });
			sevens.Should().BeEquivalentTo(new[] { (long)1 });
			eights.Should().BeEquivalentTo(new[] { (ulong)1 });
		}

		[Fact]
		public async Task TaskEightPartition()
		{
			var (ones, twos, threes, fours, fives, sixes, sevens, eights) = Task.FromResult(CreateTypesEightArray()).Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
			await sixes.Should().BeEquivalentTo(new[] { (uint)1 });
			await sevens.Should().BeEquivalentTo(new[] { (long)1 });
			await eights.Should().BeEquivalentTo(new[] { (ulong)1 });
		}

		[Fact]
		public async Task AsyncEightPartition()
		{
			var (ones, twos, threes, fours, fives, sixes, sevens, eights) = Task.FromResult(CreateTypesEightArray()).AsAsyncEnumerable().Value().Partition();

			await ones.Should().BeEquivalentTo(new[] { (sbyte)1 });
			await twos.Should().BeEquivalentTo(new[] { (byte)1 });
			await threes.Should().BeEquivalentTo(new[] { (short)1 });
			await fours.Should().BeEquivalentTo(new[] { (ushort)1 });
			await fives.Should().BeEquivalentTo(new[] { 1 });
			await sixes.Should().BeEquivalentTo(new[] { (uint)1 });
			await sevens.Should().BeEquivalentTo(new[] { (long)1 });
			await eights.Should().BeEquivalentTo(new[] { (ulong)1 });
		}
	}
}
