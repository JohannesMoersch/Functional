using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionAsyncExtensions
    {
		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
		{
			await union.Match(one);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> await (await union).DoAsync(one);


		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
		{
			await union.Match(one, two);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> await (await union).DoAsync(one, two);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
		{
			await union.Match(one, two, three);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> await (await union).DoAsync(one, two, three);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
		{
			await union.Match(one, two, three, four);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> await (await union).DoAsync(one, two, three, four);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
		{
			await union.Match(one, two, three, four, five);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> await (await union).DoAsync(one, two, three, four, five);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
		{
			await union.Match(one, two, three, four, five, six);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> await (await union).DoAsync(one, two, three, four, five, six);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
		{
			await union.Match(one, two, three, four, five, six, seven);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> await (await union).DoAsync(one, two, three, four, five, six, seven);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		{
			await union.Match(one, two, three, four, five, six, seven, eight);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> await (await union).DoAsync(one, two, three, four, five, six, seven, eight);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> union.Match(one);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> await (await union).ApplyAsync(one);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> union.Match(one, two);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> await (await union).ApplyAsync(one, two);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> union.Match(one, two, three);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> await (await union).ApplyAsync(one, two, three);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> union.Match(one, two, three, four);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> await (await union).ApplyAsync(one, two, three, four);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> union.Match(one, two, three, four, five);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> await (await union).ApplyAsync(one, two, three, four, five);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> union.Match(one, two, three, four, five, six);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> await (await union).ApplyAsync(one, two, three, four, five, six);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> union.Match(one, two, three, four, five, six, seven);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> await (await union).ApplyAsync(one, two, three, four, five, six, seven);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Match(one, two, three, four, five, six, seven, eight);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> await (await union).ApplyAsync(one, two, three, four, five, six, seven, eight);
	}
}
