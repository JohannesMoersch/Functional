using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionExtensions
    {
		public static TUnionType Do<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			union.Match(value => { one.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<TUnionType> Do<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> (await union).Do(one);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> (await union).Do(one, two);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> (await union).Do(one, two, three);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> (await union).Do(one, two, three, four);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> (await union).Do(one, two, three, four, five);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> (await union).Do(one, two, three, four, five, six);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await union).Do(one, two, three, four, five, six, seven);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> (await union).Do(one, two, three, four, five, six, seven, eight);

		public static void Apply<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> union.Do(one);

		public static Task Apply<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Action<TOne> one)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> union.Do(one);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> union.Do(one, two);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> union.Do(one, two);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> union.Do(one, two, three);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> union.Do(one, two, three);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> union.Do(one, two, three, four);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> union.Do(one, two, three, four);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> union.Do(one, two, three, four, five);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> union.Do(one, two, three, four, five);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> union.Do(one, two, three, four, five, six);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> union.Do(one, two, three, four, five, six);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> union.Do(one, two, three, four, five, six, seven);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> union.Do(one, two, three, four, five, six, seven);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Do(one, two, three, four, five, six, seven, eight);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Do(one, two, three, four, five, six, seven, eight);
	}
}
