using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionAsyncExtensions
    {
		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union, Func<TOne, Task> one)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union, Func<TOne, Task> one)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one);


		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one, two);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one, two);

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one, two, three);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one, two, three);

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one, two, three, four);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one, two, three, four);

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one, two, three, four, five);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one, two, three, four, five);

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one, two, three, four, five, six);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one, two, three, four, five, six);

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionDefinition : IUnionDefinition
		{
			await union.Match(one, two, three, four, five, six, seven);

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> DoAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).DoAsync(one, two, three, four, five, six, seven);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		{
			await union.Match(one, two, three, four, five, six, seven, eight);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> await (await union).DoAsync(one, two, three, four, five, six, seven, eight);

		public static Task ApplyAsync<TUnionDefinition, TOne>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union, Func<TOne, Task> one)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one);

		public static async Task ApplyAsync<TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union, Func<TOne, Task> one)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one);

		public static Task ApplyAsync<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two);

		public static async Task ApplyAsync<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one, two);

		public static Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three);

		public static async Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one, two, three);

		public static Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four);

		public static async Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one, two, three, four);

		public static Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four, five);

		public static async Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one, two, three, four, five);

		public static Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four, five, six);

		public static async Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one, two, three, four, five, six);

		public static Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four, five, six, seven);

		public static async Task ApplyAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).ApplyAsync(one, two, three, four, five, six, seven);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Match(one, two, three, four, five, six, seven, eight);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> await (await union).ApplyAsync(one, two, three, four, five, six, seven, eight);
	}
}
