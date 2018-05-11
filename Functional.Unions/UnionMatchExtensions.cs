using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionMatchExtensions
    {
		public static TResult Match<TUnionDefinition, TOne, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union, Func<TOne, TResult> one)
			where TUnionDefinition : IUnionDefinition
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (union is UnionValue<TUnionDefinition, TOne> storage)
				return one.Invoke(storage.One);

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union, Func<TOne, TResult> one)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Match(one);

		public static TResult Match<TUnionDefinition, TOne, TTwo, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two)
			where TUnionDefinition : IUnionDefinition
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (union is UnionValue<TUnionDefinition, TOne, TTwo> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TTwo, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two)
			where TUnionDefinition : IUnionDefinition
		=> (await union).Match(one, two);

		public static TResult Match<TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three)
			where TUnionDefinition : IUnionDefinition
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (three == null)
				throw new ArgumentNullException(nameof(three));

			if (union is UnionValue<TUnionDefinition, TOne, TTwo, TThree> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
					case 2:
						return three.Invoke(storage.Three);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Match(one, two, three);

		public static TResult Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four)
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

			if (union is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
					case 2:
						return three.Invoke(storage.Three);
					case 3:
						return four.Invoke(storage.Four);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Match(one, two, three, four);

		public static TResult Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five)
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

			if (union is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
					case 2:
						return three.Invoke(storage.Three);
					case 3:
						return four.Invoke(storage.Four);
					case 4:
						return five.Invoke(storage.Five);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Match(one, two, three, four, five);

		public static TResult Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six)
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

			if (union is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
					case 2:
						return three.Invoke(storage.Three);
					case 3:
						return four.Invoke(storage.Four);
					case 4:
						return five.Invoke(storage.Five);
					case 5:
						return six.Invoke(storage.Six);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Match(one, two, three, four, five, six);

		public static TResult Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven)
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

			if (union is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
					case 2:
						return three.Invoke(storage.Three);
					case 3:
						return four.Invoke(storage.Four);
					case 4:
						return five.Invoke(storage.Five);
					case 5:
						return six.Invoke(storage.Six);
					case 6:
						return seven.Invoke(storage.Seven);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven)
			where TUnionDefinition : IUnionDefinition
			=> (await union).Match(one, two, three, four, five, six, seven);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven, Func<TEight, TResult> eight)
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

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> storage)
			{
				switch (storage.State)
				{
					case 0:
						return one.Invoke(storage.One);
					case 1:
						return two.Invoke(storage.Two);
					case 2:
						return three.Invoke(storage.Three);
					case 3:
						return four.Invoke(storage.Four);
					case 4:
						return five.Invoke(storage.Five);
					case 5:
						return six.Invoke(storage.Six);
					case 6:
						return seven.Invoke(storage.Seven);
					case 7:
						return eight.Invoke(storage.Eight);
				}
			}

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven, Func<TEight, TResult> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> (await union).Match(one, two, three, four, five, six, seven, eight);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union, Func<TOne, Task<TResult>> one)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union, Func<TOne, Task<TResult>> one)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one, two);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one, two, three);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one, two, three, four);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four, five);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one, two, three, four, five);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four, five, six);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one, two, three, four, five, six);

		public static Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(one, two, three, four, five, six, seven);

		public static async Task<TResult> MatchAsync<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven)
			where TUnionDefinition : IUnionDefinition
			=> await (await union).Match(one, two, three, four, five, six, seven);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven, Func<TEight, Task<TResult>> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> union.Match(one, two, three, four, five, six, seven, eight);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven, Func<TEight, Task<TResult>> eight)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> await (await union).Match(one, two, three, four, five, six, seven, eight);
	}
}
