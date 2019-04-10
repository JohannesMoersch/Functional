using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public struct UnionPartition<TOne, TTwo>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		internal UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos)
		{
			ones = Ones;
			twos = Twos;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		internal AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos)
		{
			ones = Ones;
			twos = Twos;
		}
	}

	public struct UnionPartition<TOne, TTwo, TThree>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		public IEnumerable<TThree> Threes { get; }

		public UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos, IEnumerable<TThree> threes)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos, out IEnumerable<TThree> threes)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo, TThree>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		public IAsyncEnumerable<TThree> Threes { get; }

		public AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos, IAsyncEnumerable<TThree> threes)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos, out IAsyncEnumerable<TThree> threes)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
		}
	}

	public struct UnionPartition<TOne, TTwo, TThree, TFour>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		public IEnumerable<TThree> Threes { get; }

		public IEnumerable<TFour> Fours { get; }

		public UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos, IEnumerable<TThree> threes, IEnumerable<TFour> fours)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos, out IEnumerable<TThree> threes, out IEnumerable<TFour> fours)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo, TThree, TFour>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		public IAsyncEnumerable<TThree> Threes { get; }

		public IAsyncEnumerable<TFour> Fours { get; }

		public AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos, IAsyncEnumerable<TThree> threes, IAsyncEnumerable<TFour> fours)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos, out IAsyncEnumerable<TThree> threes, out IAsyncEnumerable<TFour> fours)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
		}
	}

	public struct UnionPartition<TOne, TTwo, TThree, TFour, TFive>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		public IEnumerable<TThree> Threes { get; }

		public IEnumerable<TFour> Fours { get; }

		public IEnumerable<TFive> Fives { get; }

		public UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos, IEnumerable<TThree> threes, IEnumerable<TFour> fours, IEnumerable<TFive> fives)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos, out IEnumerable<TThree> threes, out IEnumerable<TFour> fours, out IEnumerable<TFive> fives)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		public IAsyncEnumerable<TThree> Threes { get; }

		public IAsyncEnumerable<TFour> Fours { get; }

		public IAsyncEnumerable<TFive> Fives { get; }

		public AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos, IAsyncEnumerable<TThree> threes, IAsyncEnumerable<TFour> fours, IAsyncEnumerable<TFive> fives)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos, out IAsyncEnumerable<TThree> threes, out IAsyncEnumerable<TFour> fours, out IAsyncEnumerable<TFive> fives)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
		}
	}

	public struct UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		public IEnumerable<TThree> Threes { get; }

		public IEnumerable<TFour> Fours { get; }

		public IEnumerable<TFive> Fives { get; }

		public IEnumerable<TSix> Sixes { get; }

		public UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos, IEnumerable<TThree> threes, IEnumerable<TFour> fours, IEnumerable<TFive> fives, IEnumerable<TSix> sixes)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
			Sixes = sixes ?? throw new ArgumentNullException(nameof(sixes));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos, out IEnumerable<TThree> threes, out IEnumerable<TFour> fours, out IEnumerable<TFive> fives, out IEnumerable<TSix> sixes)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
			sixes = Sixes;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		public IAsyncEnumerable<TThree> Threes { get; }

		public IAsyncEnumerable<TFour> Fours { get; }

		public IAsyncEnumerable<TFive> Fives { get; }

		public IAsyncEnumerable<TSix> Sixes { get; }

		public AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos, IAsyncEnumerable<TThree> threes, IAsyncEnumerable<TFour> fours, IAsyncEnumerable<TFive> fives, IAsyncEnumerable<TSix> sixes)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
			Sixes = sixes ?? throw new ArgumentNullException(nameof(sixes));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos, out IAsyncEnumerable<TThree> threes, out IAsyncEnumerable<TFour> fours, out IAsyncEnumerable<TFive> fives, out IAsyncEnumerable<TSix> sixes)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
			sixes = Sixes;
		}
	}

	public struct UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		public IEnumerable<TThree> Threes { get; }

		public IEnumerable<TFour> Fours { get; }

		public IEnumerable<TFive> Fives { get; }

		public IEnumerable<TSix> Sixes { get; }

		public IEnumerable<TSeven> Sevens { get; }

		public UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos, IEnumerable<TThree> threes, IEnumerable<TFour> fours, IEnumerable<TFive> fives, IEnumerable<TSix> sixes, IEnumerable<TSeven> sevens)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
			Sixes = sixes ?? throw new ArgumentNullException(nameof(sixes));
			Sevens = sevens ?? throw new ArgumentNullException(nameof(sevens));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos, out IEnumerable<TThree> threes, out IEnumerable<TFour> fours, out IEnumerable<TFive> fives, out IEnumerable<TSix> sixes, out IEnumerable<TSeven> sevens)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
			sixes = Sixes;
			sevens = Sevens;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		public IAsyncEnumerable<TThree> Threes { get; }

		public IAsyncEnumerable<TFour> Fours { get; }

		public IAsyncEnumerable<TFive> Fives { get; }

		public IAsyncEnumerable<TSix> Sixes { get; }

		public IAsyncEnumerable<TSeven> Sevens { get; }

		public AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos, IAsyncEnumerable<TThree> threes, IAsyncEnumerable<TFour> fours, IAsyncEnumerable<TFive> fives, IAsyncEnumerable<TSix> sixes, IAsyncEnumerable<TSeven> sevens)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
			Sixes = sixes ?? throw new ArgumentNullException(nameof(sixes));
			Sevens = sevens ?? throw new ArgumentNullException(nameof(sevens));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos, out IAsyncEnumerable<TThree> threes, out IAsyncEnumerable<TFour> fours, out IAsyncEnumerable<TFive> fives, out IAsyncEnumerable<TSix> sixes, out IAsyncEnumerable<TSeven> sevens)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
			sixes = Sixes;
			sevens = Sevens;
		}
	}

	public struct UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
		public IEnumerable<TOne> Ones { get; }

		public IEnumerable<TTwo> Twos { get; }

		public IEnumerable<TThree> Threes { get; } 

		public IEnumerable<TFour> Fours { get; }

		public IEnumerable<TFive> Fives { get; }

		public IEnumerable<TSix> Sixes { get; }

		public IEnumerable<TSeven> Sevens { get; }

		public IEnumerable<TEight> Eights { get; }

		public UnionPartition(IEnumerable<TOne> ones, IEnumerable<TTwo> twos, IEnumerable<TThree> threes, IEnumerable<TFour> fours, IEnumerable<TFive> fives, IEnumerable<TSix> sixes, IEnumerable<TSeven> sevens, IEnumerable<TEight> eights)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
			Sixes = sixes ?? throw new ArgumentNullException(nameof(sixes));
			Sevens = sevens ?? throw new ArgumentNullException(nameof(sevens));
			Eights = eights ?? throw new ArgumentNullException(nameof(eights));
		}

		public void Deconstruct(out IEnumerable<TOne> ones, out IEnumerable<TTwo> twos, out IEnumerable<TThree> threes, out IEnumerable<TFour> fours, out IEnumerable<TFive> fives, out IEnumerable<TSix> sixes, out IEnumerable<TSeven> sevens, out IEnumerable<TEight> eights)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
			sixes = Sixes;
			sevens = Sevens;
			eights = Eights;
		}
	}

	public struct AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
		public IAsyncEnumerable<TOne> Ones { get; }

		public IAsyncEnumerable<TTwo> Twos { get; }

		public IAsyncEnumerable<TThree> Threes { get; }

		public IAsyncEnumerable<TFour> Fours { get; }

		public IAsyncEnumerable<TFive> Fives { get; }

		public IAsyncEnumerable<TSix> Sixes { get; }

		public IAsyncEnumerable<TSeven> Sevens { get; }

		public IAsyncEnumerable<TEight> Eights { get; }

		public AsyncUnionPartition(IAsyncEnumerable<TOne> ones, IAsyncEnumerable<TTwo> twos, IAsyncEnumerable<TThree> threes, IAsyncEnumerable<TFour> fours, IAsyncEnumerable<TFive> fives, IAsyncEnumerable<TSix> sixes, IAsyncEnumerable<TSeven> sevens, IAsyncEnumerable<TEight> eights)
		{
			Ones = ones ?? throw new ArgumentNullException(nameof(ones));
			Twos = twos ?? throw new ArgumentNullException(nameof(twos));
			Threes = threes ?? throw new ArgumentNullException(nameof(threes));
			Fours = fours ?? throw new ArgumentNullException(nameof(fours));
			Fives = fives ?? throw new ArgumentNullException(nameof(fives));
			Sixes = sixes ?? throw new ArgumentNullException(nameof(sixes));
			Sevens = sevens ?? throw new ArgumentNullException(nameof(sevens));
			Eights = eights ?? throw new ArgumentNullException(nameof(eights));
		}

		public void Deconstruct(out IAsyncEnumerable<TOne> ones, out IAsyncEnumerable<TTwo> twos, out IAsyncEnumerable<TThree> threes, out IAsyncEnumerable<TFour> fours, out IAsyncEnumerable<TFive> fives, out IAsyncEnumerable<TSix> sixes, out IAsyncEnumerable<TSeven> sevens, out IAsyncEnumerable<TEight> eights)
		{
			ones = Ones;
			twos = Twos;
			threes = Threes;
			fours = Fours;
			fives = Fives;
			sixes = Sixes;
			sevens = Sevens;
			eights = Eights;
		}
	}
}
