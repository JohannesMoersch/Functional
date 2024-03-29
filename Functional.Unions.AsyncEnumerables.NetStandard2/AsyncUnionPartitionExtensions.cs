﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncUnionPartitionExtensions
	{
		public static AsyncUnionPartition<TOne, TTwo> Partition<TUnionType, TUnionDefinition, TOne, TTwo>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>(source);

			return new AsyncUnionPartition<TOne, TTwo>
			(
				values.WhereOne(),
				values.WhereTwo()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix(),
				values.WhereSeven()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix(),
				values.WhereSeven(),
				values.WhereEight()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo> AsAsync<TOne, TTwo>(this Task<UnionPartition<TOne, TTwo>> partition)
			where TOne : notnull
			where TTwo : notnull
			=> new AsyncUnionPartition<TOne, TTwo>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo>(this Task<UnionPartition<TOne, TTwo>> source)
			where TOne : notnull
			where TTwo : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo>(this Task<UnionPartition<TOne, TTwo>> source)
			where TOne : notnull
			where TTwo : notnull
			=> (await source).Twos;

		public static AsyncUnionPartition<TOne, TTwo, TThree> AsAsync<TOne, TTwo, TThree>(this Task<UnionPartition<TOne, TTwo, TThree>> partition)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> new AsyncUnionPartition<TOne, TTwo, TThree>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable(),
				GetThrees(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo, TThree>(this Task<UnionPartition<TOne, TTwo, TThree>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo, TThree>(this Task<UnionPartition<TOne, TTwo, TThree>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> (await source).Twos;

		private static async Task<IEnumerable<TThree>> GetThrees<TOne, TTwo, TThree>(this Task<UnionPartition<TOne, TTwo, TThree>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> (await source).Threes;

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour> AsAsync<TOne, TTwo, TThree, TFour>(this Task<UnionPartition<TOne, TTwo, TThree, TFour>> partition)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> new AsyncUnionPartition<TOne, TTwo, TThree, TFour>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable(),
				GetThrees(partition).AsAsyncEnumerable(),
				GetFours(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo, TThree, TFour>(this Task<UnionPartition<TOne, TTwo, TThree, TFour>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo, TThree, TFour>(this Task<UnionPartition<TOne, TTwo, TThree, TFour>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> (await source).Twos;

		private static async Task<IEnumerable<TThree>> GetThrees<TOne, TTwo, TThree, TFour>(this Task<UnionPartition<TOne, TTwo, TThree, TFour>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> (await source).Threes;

		private static async Task<IEnumerable<TFour>> GetFours<TOne, TTwo, TThree, TFour>(this Task<UnionPartition<TOne, TTwo, TThree, TFour>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> (await source).Fours;

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive> AsAsync<TOne, TTwo, TThree, TFour, TFive>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> partition)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable(),
				GetThrees(partition).AsAsyncEnumerable(),
				GetFours(partition).AsAsyncEnumerable(),
				GetFives(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo, TThree, TFour, TFive>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo, TThree, TFour, TFive>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await source).Twos;

		private static async Task<IEnumerable<TThree>> GetThrees<TOne, TTwo, TThree, TFour, TFive>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await source).Threes;

		private static async Task<IEnumerable<TFour>> GetFours<TOne, TTwo, TThree, TFour, TFive>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await source).Fours;

		private static async Task<IEnumerable<TFive>> GetFives<TOne, TTwo, TThree, TFour, TFive>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await source).Fives;

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix> AsAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> partition)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable(),
				GetThrees(partition).AsAsyncEnumerable(),
				GetFours(partition).AsAsyncEnumerable(),
				GetFives(partition).AsAsyncEnumerable(),
				GetSixes(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await source).Twos;

		private static async Task<IEnumerable<TThree>> GetThrees<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await source).Threes;

		private static async Task<IEnumerable<TFour>> GetFours<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await source).Fours;

		private static async Task<IEnumerable<TFive>> GetFives<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await source).Fives;

		private static async Task<IEnumerable<TSix>> GetSixes<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await source).Sixes;

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> AsAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> partition)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable(),
				GetThrees(partition).AsAsyncEnumerable(),
				GetFours(partition).AsAsyncEnumerable(),
				GetFives(partition).AsAsyncEnumerable(),
				GetSixes(partition).AsAsyncEnumerable(),
				GetSevens(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Twos;

		private static async Task<IEnumerable<TThree>> GetThrees<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Threes;

		private static async Task<IEnumerable<TFour>> GetFours<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Fours;

		private static async Task<IEnumerable<TFive>> GetFives<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Fives;

		private static async Task<IEnumerable<TSix>> GetSixes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Sixes;

		private static async Task<IEnumerable<TSeven>> GetSevens<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await source).Sevens;

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> AsAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> partition)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			(
				GetOnes(partition).AsAsyncEnumerable(),
				GetTwos(partition).AsAsyncEnumerable(),
				GetThrees(partition).AsAsyncEnumerable(),
				GetFours(partition).AsAsyncEnumerable(),
				GetFives(partition).AsAsyncEnumerable(),
				GetSixes(partition).AsAsyncEnumerable(),
				GetSevens(partition).AsAsyncEnumerable(),
				GetEights(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<TOne>> GetOnes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Ones;

		private static async Task<IEnumerable<TTwo>> GetTwos<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Twos;

		private static async Task<IEnumerable<TThree>> GetThrees<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Threes;

		private static async Task<IEnumerable<TFour>> GetFours<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Fours;

		private static async Task<IEnumerable<TFive>> GetFives<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Fives;

		private static async Task<IEnumerable<TSix>> GetSixes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Sixes;

		private static async Task<IEnumerable<TSeven>> GetSevens<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Sevens;

		private static async Task<IEnumerable<TEight>> GetEights<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> (await source).Eights;
	}
}