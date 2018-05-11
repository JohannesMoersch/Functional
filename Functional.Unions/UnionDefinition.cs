using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public abstract class UnionDefinition<TUnionDefinition, TOne> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne>(UnionHelpers.CheckForNull(one, nameof(one))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne>(UnionHelpers.CheckForNull(await one, nameof(one))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo)));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree)));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree)));

		public static Union<TUnionDefinition> Create(TThree three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TThree> three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour)));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour)));

		public static Union<TUnionDefinition> Create(TThree three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TThree> three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour)));

		public static Union<TUnionDefinition> Create(TFour four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFour> four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive)));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive)));

		public static Union<TUnionDefinition> Create(TThree three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TThree> three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive)));

		public static Union<TUnionDefinition> Create(TFour four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFour> four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive)));

		public static Union<TUnionDefinition> Create(TFive five)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFive> five)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create(TThree three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TThree> three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create(TFour four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFour> four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create(TFive five)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFive> five)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix)));

		public static Union<TUnionDefinition> Create(TSix six)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TSix> six)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create(TThree three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TThree> three)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create(TFour four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFour> four)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create(TFive five)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFive> five)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create(TSix six)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create(Task<TSix> six)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven)));

		public static Union<TUnionDefinition> Create(TSeven seven)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven))));

		public static async Task<Union<TUnionDefinition>> Create(Task<TSeven> seven)
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven))));
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
		public static Union<TUnionDefinition> Create(TOne one)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TOne> one)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TTwo two)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TTwo> two)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TThree three)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TThree> three)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TFour four)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFour> four)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TFive five)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TFive> five)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TSix six)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TSix> six)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TSeven seven)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TSeven> seven)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create(TEight eight)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create(Task<TEight> eight)
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnion));

		private static Union<TUnionDefinition> CreateUnion(IUnionValue<TUnionDefinition> value)
			=> new Union<TUnionDefinition>(value);
	}
}
