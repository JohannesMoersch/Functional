using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionAsyncExtensions
    {
		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
		{
			await union.Match(one);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> await (await union).DoAsync(one);


		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
		{
			await union.Match(one, two);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> await (await union).DoAsync(one, two);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
		{
			await union.Match(one, two, three);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> await (await union).DoAsync(one, two, three);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
		{
			await union.Match(one, two, three, four);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> await (await union).DoAsync(one, two, three, four);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
		{
			await union.Match(one, two, three, four, five);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> await (await union).DoAsync(one, two, three, four, five);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
		{
			await union.Match(one, two, three, four, five, six);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> await (await union).DoAsync(one, two, three, four, five, six);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
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
			await union.Match(one, two, three, four, five, six, seven);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> await (await union).DoAsync(one, two, three, four, five, six, seven);

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
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
			await union.Match(one, two, three, four, five, six, seven, eight);

			return union.AsUnion();
		}

		public static async Task<TUnionType> DoAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
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
			=> await (await union).DoAsync(one, two, three, four, five, six, seven, eight);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> union.Match(one);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Func<TOne, Task> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> await (await union).ApplyAsync(one);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Match(one, two);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task> one, Func<TTwo, Task> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> await (await union).ApplyAsync(one, two);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(one, two, three);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> await (await union).ApplyAsync(one, two, three);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(one, two, three, four);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> await (await union).ApplyAsync(one, two, three, four);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(one, two, three, four, five);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> await (await union).ApplyAsync(one, two, three, four, five);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(one, two, three, four, five, six);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> await (await union).ApplyAsync(one, two, three, four, five, six);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(one, two, three, four, five, six, seven);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> await (await union).ApplyAsync(one, two, three, four, five, six, seven);

		public static Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
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
			=> union.Match(one, two, three, four, five, six, seven, eight);

		public static async Task ApplyAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task> one, Func<TTwo, Task> two, Func<TThree, Task> three, Func<TFour, Task> four, Func<TFive, Task> five, Func<TSix, Task> six, Func<TSeven, Task> seven, Func<TEight, Task> eight)
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
			=> await (await union).ApplyAsync(one, two, three, four, five, six, seven, eight);
	}
}
