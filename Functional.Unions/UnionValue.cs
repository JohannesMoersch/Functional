using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IUnionValue<out TUnionDefinition>
	{
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo> : IUnionValue<TUnionDefinition>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public UnionValue(byte state, TOne one, TTwo two)
		{
			State = state;
			One = one;
			Two = two;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				default:
					return String.Empty;
			}
		}
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo, TThree> : IUnionValue<TUnionDefinition>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public TThree Three { get; }

		public UnionValue(byte state, TOne one, TTwo two, TThree three)
		{
			State = state;
			One = one;
			Two = two;
			Three = three;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo, TThree> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				case 2:
					return Equals(Three, other.Three);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				case 2:
					return Three.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				case 2:
					return $"One:{Three}";
				default:
					return String.Empty;
			}
		}
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour> : IUnionValue<TUnionDefinition>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public TThree Three { get; }

		public TFour Four { get; }

		public UnionValue(byte state, TOne one, TTwo two, TThree three, TFour four)
		{
			State = state;
			One = one;
			Two = two;
			Three = three;
			Four = four;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				case 2:
					return Equals(Three, other.Three);
				case 3:
					return Equals(Four, other.Four);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				case 2:
					return Three.GetHashCode() * 31 + 7;
				case 3:
					return Four.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				case 2:
					return $"One:{Three}";
				case 3:
					return $"One:{Four}";
				default:
					return String.Empty;
			}
		}
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : IUnionValue<TUnionDefinition>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public TThree Three { get; }

		public TFour Four { get; }

		public TFive Five { get; }

		public UnionValue(byte state, TOne one, TTwo two, TThree three, TFour four, TFive five)
		{
			State = state;
			One = one;
			Two = two;
			Three = three;
			Four = four;
			Five = five;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				case 2:
					return Equals(Three, other.Three);
				case 3:
					return Equals(Four, other.Four);
				case 4:
					return Equals(Five, other.Five);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				case 2:
					return Three.GetHashCode() * 31 + 7;
				case 3:
					return Four.GetHashCode() * 31 + 7;
				case 4:
					return Five.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				case 2:
					return $"One:{Three}";
				case 3:
					return $"One:{Four}";
				case 4:
					return $"One:{Five}";
				default:
					return String.Empty;
			}
		}
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionValue<TUnionDefinition>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public TThree Three { get; }

		public TFour Four { get; }

		public TFive Five { get; }

		public TSix Six { get; }

		public UnionValue(byte state, TOne one, TTwo two, TThree three, TFour four, TFive five, TSix six)
		{
			State = state;
			One = one;
			Two = two;
			Three = three;
			Four = four;
			Five = five;
			Six = six;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				case 2:
					return Equals(Three, other.Three);
				case 3:
					return Equals(Four, other.Four);
				case 4:
					return Equals(Five, other.Five);
				case 5:
					return Equals(Six, other.Six);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				case 2:
					return Three.GetHashCode() * 31 + 7;
				case 3:
					return Four.GetHashCode() * 31 + 7;
				case 4:
					return Five.GetHashCode() * 31 + 7;
				case 5:
					return Six.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				case 2:
					return $"One:{Three}";
				case 3:
					return $"One:{Four}";
				case 4:
					return $"One:{Five}";
				case 5:
					return $"One:{Six}";
				default:
					return String.Empty;
			}
		}
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionValue<TUnionDefinition>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public TThree Three { get; }

		public TFour Four { get; }

		public TFive Five { get; }

		public TSix Six { get; }

		public TSeven Seven { get; }

		public UnionValue(byte state, TOne one, TTwo two, TThree three, TFour four, TFive five, TSix six, TSeven seven)
		{
			State = state;
			One = one;
			Two = two;
			Three = three;
			Four = four;
			Five = five;
			Six = six;
			Seven = seven;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				case 2:
					return Equals(Three, other.Three);
				case 3:
					return Equals(Four, other.Four);
				case 4:
					return Equals(Five, other.Five);
				case 5:
					return Equals(Six, other.Six);
				case 6:
					return Equals(Seven, other.Seven);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				case 2:
					return Three.GetHashCode() * 31 + 7;
				case 3:
					return Four.GetHashCode() * 31 + 7;
				case 4:
					return Five.GetHashCode() * 31 + 7;
				case 5:
					return Six.GetHashCode() * 31 + 7;
				case 6:
					return Seven.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				case 2:
					return $"One:{Three}";
				case 3:
					return $"One:{Four}";
				case 4:
					return $"One:{Five}";
				case 5:
					return $"One:{Six}";
				case 6:
					return $"One:{Seven}";
				default:
					return String.Empty;
			}
		}
	}

	internal class UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionValue<TUnionDefinition>, IEquatable<UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>
	{
		public byte State { get; }

		public TOne One { get; }

		public TTwo Two { get; }

		public TThree Three { get; }

		public TFour Four { get; }

		public TFive Five { get; }

		public TSix Six { get; }

		public TSeven Seven { get; }

		public TEight Eight { get; }

		public UnionValue(byte state, TOne one, TTwo two, TThree three, TFour four, TFive five, TSix six, TSeven seven, TEight eight)
		{
			State = state;
			One = one;
			Two = two;
			Three = three;
			Four = four;
			Five = five;
			Six = six;
			Seven = seven;
			Eight = eight;
		}

		public bool Equals(UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
		{
			if (State != other.State)
				return false;

			switch (State)
			{
				case 0:
					return Equals(One, other.One);
				case 1:
					return Equals(Two, other.Two);
				case 2:
					return Equals(Three, other.Three);
				case 3:
					return Equals(Four, other.Four);
				case 4:
					return Equals(Five, other.Five);
				case 5:
					return Equals(Six, other.Six);
				case 6:
					return Equals(Seven, other.Seven);
				case 7:
					return Equals(Eight, other.Eight);
				default:
					return false;
			}
		}

		public override int GetHashCode()
		{
			switch (State)
			{
				case 0:
					return One.GetHashCode() * 31 + 7;
				case 1:
					return Two.GetHashCode() * 31 + 7;
				case 2:
					return Three.GetHashCode() * 31 + 7;
				case 3:
					return Four.GetHashCode() * 31 + 7;
				case 4:
					return Five.GetHashCode() * 31 + 7;
				case 5:
					return Six.GetHashCode() * 31 + 7;
				case 6:
					return Seven.GetHashCode() * 31 + 7;
				case 7:
					return Eight.GetHashCode() * 31 + 7;
				default:
					return 0;
			}
		}

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
		{
			switch (State)
			{
				case 0:
					return $"One:{One}";
				case 1:
					return $"One:{Two}";
				case 2:
					return $"One:{Three}";
				case 3:
					return $"One:{Four}";
				case 4:
					return $"One:{Five}";
				case 5:
					return $"One:{Six}";
				case 6:
					return $"One:{Seven}";
				case 7:
					return $"One:{Eight}";
				default:
					return String.Empty;
			}
		}
	}
}
