using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionExtensions
    {
		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union, Action<TOne> one)
			where TUnionDefinition : IUnionDefinition
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			union.Match(value => { one.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union, Action<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one);

		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionDefinition : IUnionDefinition
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			union.Match(value => { one.Invoke(value); return false; }, value => { two.Invoke(value); return false; });

			return union.AsUnion();
		}

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one, two);

		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionDefinition : IUnionDefinition
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

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one, two, three);

		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionDefinition : IUnionDefinition
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

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one, two, three, four);

		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionDefinition : IUnionDefinition
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

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one, two, three, four, five);

		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionDefinition : IUnionDefinition
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

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one, two, three, four, five, six);

		public static Union<TUnionDefinition> Do<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
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

		public static async Task<Union<TUnionDefinition>> Do<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Do(one, two, three, four, five, six, seven);

		public static TUnionType Do<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
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
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> (await union).Do(one, two, three, four, five, six, seven, eight);

		public static void Apply<TUnionDefinition, TOne>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union, Action<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one);

		public static Task Apply<TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union, Action<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one);

		public static void Apply<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two);

		public static Task Apply<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union, Action<TOne> one, Action<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two);

		public static void Apply<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three);

		public static Task Apply<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three);

		public static void Apply<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four);

		public static Task Apply<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four);

		public static void Apply<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four, five);

		public static Task Apply<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four, five);

		public static void Apply<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four, five, six);

		public static Task Apply<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four, five, six);

		public static void Apply<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four, five, six, seven);

		public static Task Apply<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> union.Do(one, two, three, four, five, six, seven);

		public static void Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Do(one, two, three, four, five, six, seven, eight);

		public static Task Apply<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Action<TOne> one, Action<TTwo> two, Action<TThree> three, Action<TFour> four, Action<TFive> five, Action<TSix> six, Action<TSeven> seven, Action<TEight> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Do(one, two, three, four, five, six, seven, eight);
	}
}
