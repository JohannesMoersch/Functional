using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionMatchExtensions
    {
		public static TResult Match<TUnionType, TUnionDefinition, TOne, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Func<TOne, TResult> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne> storage)
				return one.Invoke(storage.One);

			throw new UnionInvalidMatchException();
		}

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Func<TOne, TResult> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> (await union).Match(one);

#pragma warning disable CS8604 // Possible null reference argument.
		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
		{
			if (one == null)
				throw new ArgumentNullException(nameof(one));

			if (two == null)
				throw new ArgumentNullException(nameof(two));

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo> storage)
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

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
		=> (await union).Match(one, two);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three)
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

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree> storage)
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

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> (await union).Match(one, two, three);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four)
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

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> storage)
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

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> (await union).Match(one, two, three, four);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five)
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

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> storage)
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

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> (await union).Match(one, two, three, four, five);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six)
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

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> storage)
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

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> (await union).Match(one, two, three, four, five, six);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven)
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

			if (union is UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> storage)
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

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> (await union).Match(one, two, three, four, five, six, seven);

		public static TResult Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven, Func<TEight, TResult> eight)
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
#pragma warning restore CS8604 // Possible null reference argument.

		public static async Task<TResult> Match<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, TResult> one, Func<TTwo, TResult> two, Func<TThree, TResult> three, Func<TFour, TResult> four, Func<TFive, TResult> five, Func<TSix, TResult> six, Func<TSeven, TResult> seven, Func<TEight, TResult> eight)
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
			=> (await union).Match(one, two, three, four, five, six, seven, eight);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union, Func<TOne, Task<TResult>> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> union.Match(one);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union, Func<TOne, Task<TResult>> one)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> await (await union).Match(one);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Match(one, two);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> await (await union).Match(one, two);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(one, two, three);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> await (await union).Match(one, two, three);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(one, two, three, four);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> await (await union).Match(one, two, three, four);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(one, two, three, four, five);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> await (await union).Match(one, two, three, four, five);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(one, two, three, four, five, six);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> await (await union).Match(one, two, three, four, five, six);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(one, two, three, four, five, six, seven);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> await (await union).Match(one, two, three, four, five, six, seven);

		public static Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven, Func<TEight, Task<TResult>> eight)
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
			=> union.Match(one, two, three, four, five, six, seven, eight);

		public static async Task<TResult> MatchAsync<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight, TResult>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union, Func<TOne, Task<TResult>> one, Func<TTwo, Task<TResult>> two, Func<TThree, Task<TResult>> three, Func<TFour, Task<TResult>> four, Func<TFive, Task<TResult>> five, Func<TSix, Task<TResult>> six, Func<TSeven, Task<TResult>> seven, Func<TEight, Task<TResult>> eight)
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
			=> await (await union).Match(one, two, three, four, five, six, seven, eight);
	}
}
