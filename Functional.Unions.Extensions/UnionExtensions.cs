using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionExtensions
    {
		public static TUnionType Do<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			union.Match(value => { one.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> (await union).Do(one);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> (await union).Do(one, two);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; }, value => { three.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> (await union).Do(one, two, three);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			if (four == null)
				throw new ArgumentNullException(nameof(four));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; }, value => { three.Invoke(value); return false; }, value => { four.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> (await union).Do(one, two, three, four);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			if (four == null)
				throw new ArgumentNullException(nameof(four));

			if (five == null)
				throw new ArgumentNullException(nameof(five));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; }, value => { three.Invoke(value); return false; }, value => { four.Invoke(value); return false; }, value => { five.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await union).Do(one, two, three, four, five);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			if (four == null)
				throw new ArgumentNullException(nameof(four));

			if (five == null)
				throw new ArgumentNullException(nameof(five));

			if (six == null)
				throw new ArgumentNullException(nameof(six));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; }, value => { three.Invoke(value); return false; }, value => { four.Invoke(value); return false; }, value => { five.Invoke(value); return false; }, value => { six.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await union).Do(one, two, three, four, five, six);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
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
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			if (four == null)
				throw new ArgumentNullException(nameof(four));

			if (five == null)
				throw new ArgumentNullException(nameof(five));

			if (six == null)
				throw new ArgumentNullException(nameof(six));

			if (seven == null)
				throw new ArgumentNullException(nameof(seven));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; }, value => { three.Invoke(value); return false; }, value => { four.Invoke(value); return false; }, value => { five.Invoke(value); return false; }, value => { six.Invoke(value); return false; }, value => { seven.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await union).Do(one, two, three, four, five, six, seven);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
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
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			if (four == null)
				throw new ArgumentNullException(nameof(four));

			if (five == null)
				throw new ArgumentNullException(nameof(five));

			if (six == null)
				throw new ArgumentNullException(nameof(six));

			if (seven == null)
				throw new ArgumentNullException(nameof(seven));

			if (eight == null)
				throw new ArgumentNullException(nameof(eight));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; }, value => { three.Invoke(value); return false; }, value => { four.Invoke(value); return false; }, value => { five.Invoke(value); return false; }, value => { six.Invoke(value); return false; }, value => { seven.Invoke(value); return false; }, value => { eight.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
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
			=> (await union).Do(one, two, three, four, five, six, seven, eight);

		public static void Apply<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> union.Do(one);

		public static Task Apply<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> union.Do(one);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Do(one, two);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Do(one, two);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Do(one, two, three);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Do(one, two, three);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Do(one, two, three, four);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Do(one, two, three, four);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Do(one, two, three, four, five);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Do(one, two, three, four, five);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Do(one, two, three, four, five, six);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Do(one, two, three, four, five, six);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Do(one, two, three, four, five, six, seven);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Do(one, two, three, four, five, six, seven);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
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
			=> union.Do(one, two, three, four, five, six, seven, eight);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
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
			=> union.Do(one, two, three, four, five, six, seven, eight);
	}
}
