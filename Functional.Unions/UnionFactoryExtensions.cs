using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;namespace Functional
{
	public static class UnionFactoryExtensions
	{
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSeven seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSeven seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), default(TEight), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), default(TEight), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TEight eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(7, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnionFromDefinition));

		public static async Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TEight> eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(7, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnionFromDefinition));

		public static Union<TOne, TTwo> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, TOne one)
			=> new Union<TOne, TTwo>(new UnionValue<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo>> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, Task<TOne> one)
			=> new Union<TOne, TTwo>(new UnionValue<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), CreateUnionFromTypes));

		public static Union<TOne, TTwo> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, TTwo two)
			=> new Union<TOne, TTwo>(new UnionValue<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo>> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo>(new UnionValue<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, TOne one)
			=> new Union<TOne, TTwo, TThree>(new UnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree>> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree>(new UnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree>(new UnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree>> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree>(new UnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, TThree three)
			=> new Union<TOne, TTwo, TThree>(new UnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree>> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree>(new UnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TSeven seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TSeven> seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(1, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(1, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(2, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(3, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(4, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(5, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TSeven seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), default(TEight), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TSeven> seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(6, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), default(TEight), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TEight eight)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(7, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnionFromTypes));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TEight> eight)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(7, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnionFromTypes));

		internal static Union<TUnionDefinition> CreateUnionFromDefinition<TUnionDefinition>(IUnionValue<TUnionDefinition> value)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>(value);

		internal static Union<TOne, TTwo> CreateUnionFromTypes<TOne, TTwo>(IUnionValue<AdhocUnionDefinition<TOne, TTwo>> value)
			=> new Union<TOne, TTwo>(value);

		internal static Union<TOne, TTwo, TThree> CreateUnionFromTypes<TOne, TTwo, TThree>(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> value)
			=> new Union<TOne, TTwo, TThree>(value);

		internal static Union<TOne, TTwo, TThree, TFour> CreateUnionFromTypes<TOne, TTwo, TThree, TFour>(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> value)
			=> new Union<TOne, TTwo, TThree, TFour>(value);

		internal static Union<TOne, TTwo, TThree, TFour, TFive> CreateUnionFromTypes<TOne, TTwo, TThree, TFour, TFive>(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> value)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(value);

		internal static Union<TOne, TTwo, TThree, TFour, TFive, TSix> CreateUnionFromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> value)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(value);

		internal static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> CreateUnionFromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> value)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(value);

		internal static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> CreateUnionFromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> value)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(value);
	}
}
