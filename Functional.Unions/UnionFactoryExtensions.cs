using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class UnionFactoryExtensions
	{
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, CheckForNull(one, nameof(one)), default(TTwo)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, CheckForNull(await one, nameof(one)), default(TTwo)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition 
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, default(TOne), CheckForNull(two, nameof(two))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo>(0, default(TOne), CheckForNull(await two, nameof(two))));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, CheckForNull(one, nameof(one)), default(TTwo), default(TThree)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, CheckForNull(await one, nameof(one)), default(TTwo), default(TThree)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), CheckForNull(two, nameof(two)), default(TThree)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), CheckForNull(await two, nameof(two)), default(TThree)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), default(TTwo), CheckForNull(three, nameof(three))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree>(0, default(TOne), default(TTwo), CheckForNull(await three, nameof(three))));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), CheckForNull(two, nameof(two)), default(TThree), default(TFour)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), CheckForNull(await two, nameof(two)), default(TThree), default(TFour)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), CheckForNull(three, nameof(three)), default(TFour)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), CheckForNull(await three, nameof(three)), default(TFour)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(four, nameof(four))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(await four, nameof(four))));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), CheckForNull(three, nameof(three)), default(TFour), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), CheckForNull(await three, nameof(three)), default(TFour), default(TFive)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(four, nameof(four)), default(TFive)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(await four, nameof(four)), default(TFive)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(five, nameof(five))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(await five, nameof(five))));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(four, nameof(four)), default(TFive), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(await four, nameof(four)), default(TFive), default(TSix)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(five, nameof(five)), default(TSix)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(await five, nameof(five)), default(TSix)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TSix six)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), CheckForNull(six, nameof(six))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), CheckForNull(await six, nameof(six))));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(five, nameof(five)), default(TSix), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(await five, nameof(five)), default(TSix), default(TSeven)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSix six)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), CheckForNull(six, nameof(six)), default(TSeven)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), CheckForNull(await six, nameof(six)), default(TSeven)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSeven seven)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CheckForNull(seven, nameof(seven))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CheckForNull(await seven, nameof(seven))));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(five, nameof(five)), default(TSix), default(TSeven), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSix six)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), CheckForNull(six, nameof(six)), default(TSeven), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), CheckForNull(await six, nameof(six)), default(TSeven), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSeven seven)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CheckForNull(seven, nameof(seven)), default(TEight)));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CheckForNull(await seven, nameof(seven)), default(TEight)));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TEight eight)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CheckForNull(eight, nameof(eight))));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TEight> eight)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(new UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CheckForNull(await eight, nameof(eight))));

		private static T CheckForNull<T>(T value, string argumentName)
		{
			if (value == null)
				throw new ArgumentNullException(argumentName);

			return value;
		}
	}
}
