using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionFactoryExtensions
	{
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
			=> new Union<TUnionDefinition>(new UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> CreateAsync(factory, three);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> CreateAsync(factory, three);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> CreateAsync(factory, four);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> CreateAsync(factory, three);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> CreateAsync(factory, four);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> CreateAsync(factory, five);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> CreateAsync(factory, three);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> CreateAsync(factory, four);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> CreateAsync(factory, five);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueSix<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> CreateAsync(factory, six);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new Union<TUnionDefinition>(new UnionValueSix<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, three);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, four);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, five);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueSix<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, six);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueSix<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSeven seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueSeven<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> CreateAsync(factory, seven);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new Union<TUnionDefinition>(new UnionValueSeven<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TOne one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, one);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TOne> one)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueOne<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TTwo two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, two);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TTwo> two)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueTwo<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TThree three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, three);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TThree> three)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueThree<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFour four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, four);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFour> four)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueFour<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFive five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, five);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFive> five)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueFive<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSix six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueSix<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, six);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSix> six)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueSix<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSeven seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueSeven<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, seven);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSeven> seven)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueSeven<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnionFromDefinition));

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TEight eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueEight<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnionFromDefinition));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TEight> eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> CreateAsync(factory, eight);

		public static async Task<Union<TUnionDefinition>> CreateAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TEight> eight)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new Union<TUnionDefinition>(new UnionValueEight<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnionFromDefinition));

		public static Union<TOne, TTwo> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, TOne one)
			=> new Union<TOne, TTwo>(new UnionValueOne<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo>> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo>> CreateAsync<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, Task<TOne> one)
			=> new Union<TOne, TTwo>(new UnionValueOne<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, TTwo two)
			=> new Union<TOne, TTwo>(new UnionValueTwo<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo>> Create<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo>> CreateAsync<TOne, TTwo>(this IUnionFactory<TOne, TTwo> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo>(new UnionValueTwo<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, TOne one)
			=> new Union<TOne, TTwo, TThree>(new UnionValueOne<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree>> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo, TThree>> CreateAsync<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree>(new UnionValueOne<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree>(new UnionValueTwo<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree>> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo, TThree>> CreateAsync<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree>(new UnionValueTwo<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, TThree three)
			=> new Union<TOne, TTwo, TThree>(new UnionValueThree<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree>> Create<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TThree> three)
			=> CreateAsync(factory, three);

		public static async Task<Union<TOne, TTwo, TThree>> CreateAsync<TOne, TTwo, TThree>(this IUnionFactory<TOne, TTwo, TThree> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree>(new UnionValueThree<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo, TThree, TFour>> CreateAsync<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo, TThree, TFour>> CreateAsync<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TThree> three)
			=> CreateAsync(factory, three);

		public static async Task<Union<TOne, TTwo, TThree, TFour>> CreateAsync<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour>> Create<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TFour> four)
			=> CreateAsync(factory, four);

		public static async Task<Union<TOne, TTwo, TThree, TFour>> CreateAsync<TOne, TTwo, TThree, TFour>(this IUnionFactory<TOne, TTwo, TThree, TFour> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> CreateAsync<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> CreateAsync<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TThree> three)
			=> CreateAsync(factory, three);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> CreateAsync<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TFour> four)
			=> CreateAsync(factory, four);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> CreateAsync<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive>> Create<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TFive> five)
			=> CreateAsync(factory, five);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive>> CreateAsync<TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TThree> three)
			=> CreateAsync(factory, three);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TFour> four)
			=> CreateAsync(factory, four);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TFive> five)
			=> CreateAsync(factory, five);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueSix<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> Create<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TSix> six)
			=> CreateAsync(factory, six);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> factory, Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix>(new UnionValueSix<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TThree> three)
			=> CreateAsync(factory, three);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TFour> four)
			=> CreateAsync(factory, four);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TFive> five)
			=> CreateAsync(factory, five);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueSix<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TSix> six)
			=> CreateAsync(factory, six);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueSix<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, TSeven seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueSeven<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TSeven> seven)
			=> CreateAsync(factory, seven);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> factory, Task<TSeven> seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(new UnionValueSeven<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(one, nameof(one)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TOne> one)
			=> CreateAsync(factory, one);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueOne<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await one, nameof(one)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(two, nameof(two)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TTwo> two)
			=> CreateAsync(factory, two);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueTwo<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await two, nameof(two)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(three, nameof(three)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TThree> three)
			=> CreateAsync(factory, three);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueThree<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await three, nameof(three)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(four, nameof(four)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TFour> four)
			=> CreateAsync(factory, four);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueFour<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await four, nameof(four)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(five, nameof(five)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TFive> five)
			=> CreateAsync(factory, five);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueFive<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await five, nameof(five)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueSix<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(six, nameof(six)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TSix> six)
			=> CreateAsync(factory, six);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueSix<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await six, nameof(six)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TSeven seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueSeven<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(seven, nameof(seven)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TSeven> seven)
			=> CreateAsync(factory, seven);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TSeven> seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueSeven<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await seven, nameof(seven)), CreateUnionFromTypes));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, TEight eight)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueEight<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnionFromTypes));

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factory, Task<TEight> eight)
			=> CreateAsync(factory, eight);

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> CreateAsync<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> factoryAsync, Task<TEight> eight)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValueEight<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnionFromTypes));

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
