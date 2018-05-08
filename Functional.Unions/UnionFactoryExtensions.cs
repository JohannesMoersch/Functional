using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;namespace Functional
{
	public static class UnionFactoryExtensions
	{
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne>.Create(one);

		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne>.Create(one);

		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>.Create(three);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>.Create(three);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(three);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(three);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(four);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>.Create(four);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(three);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(three);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(four);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(four);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(five);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>.Create(five);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(three);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(three);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(four);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(four);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(five);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(five);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, TSix six)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(six);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> factory, Task<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>.Create(six);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(three);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(three);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(four);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(four);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(five);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(five);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSix six)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(six);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(six);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, TSeven seven)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(seven);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> factory, Task<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Create(seven);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TOne one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(one);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TOne> one)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(one);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TTwo two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(two);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TTwo> two)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(two);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TThree three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(three);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TThree> three)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(three);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFour four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(four);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFour> four)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(four);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TFive five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(five);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TFive> five)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(five);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSix six)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(six);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSix> six)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(six);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TSeven seven)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(seven);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TSeven> seven)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(seven);
	
		public static Union<TUnionDefinition> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, TEight eight)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(eight);
	
		public static Task<Union<TUnionDefinition>> Create<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionFactory<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> factory, Task<TEight> eight)
			where TUnionDefinition : IUnionDefinition
			=> UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Create(eight);
		}
}
