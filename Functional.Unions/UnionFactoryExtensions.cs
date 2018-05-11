using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;namespace Functional
{
	public static class UnionFactoryExtensions
	{
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSeven seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSeven seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), default(TEight), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), default(TEight), CreateUnion));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TEight eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(7, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnion));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TEight> eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(7, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnion));

		private static Union<TUnionDefinition> CreateUnion<TUnionDefinition>(IUnionValue<TUnionDefinition> value)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(value);
	}
}
