﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Functional
{
	internal interface IUnionValue
	{
		int State { get; }

		object Value { get; }
	}

	public interface IUnionValue<out TUnionDefinition>
		where TUnionDefinition : IUnionDefinition
	{
	}

	[Serializable]
	internal class UnionValue<TUnionType, TUnionDefinition, TOne> : IUnionValue<TUnionDefinition>, IEquatable<UnionValue<TUnionType, TUnionDefinition, TOne>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
	{
		public int State => 0;

		public TOne One { get; }

		object IUnionValue.Value => One;

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
		{
			One = one;
			_unionFactory = unionFactory;
		}

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);

		public bool Equals(UnionValue<TUnionType, TUnionDefinition, TOne> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionType, TUnionDefinition, TOne> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory) 
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory) 
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		public abstract TThree? Three { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		public override TThree? Three => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		public override TThree? Three => default;

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
	{
		public override int State => 2;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree Three { get; }

		object IUnionValue.Value => Three;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		public abstract TThree? Three { get; }

		public abstract TFour? Four { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		public override TThree? Three => default;

		public override TFour? Four => default;

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
	{
		public override int State => 2;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree Three { get; }

		public override TFour? Four => default;

		object IUnionValue.Value => Three;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
	{
		public override int State => 3;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour Four { get; }

		object IUnionValue.Value => Four;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		public abstract TThree? Three { get; }

		public abstract TFour? Four { get; }

		public abstract TFive? Five { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
	{
		public override int State => 2;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree Three { get; }

		public override TFour? Four => default;

		public override TFive? Five => default;

		object IUnionValue.Value => Three;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
	{
		public override int State => 3;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour Four { get; }

		public override TFive? Five => default;

		object IUnionValue.Value => Four;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
	{
		public override int State => 4;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive Five { get; }

		object IUnionValue.Value => Five;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		public abstract TThree? Three { get; }

		public abstract TFour? Four { get; }

		public abstract TFive? Five { get; }

		public abstract TSix? Six { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public override int State => 2;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree Three { get; }

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		object IUnionValue.Value => Three;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public override int State => 3;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour Four { get; }

		public override TFive? Five => default;

		public override TSix? Six => default;

		object IUnionValue.Value => Four;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public override int State => 4;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive Five { get; }

		public override TSix? Six => default;

		object IUnionValue.Value => Five;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal class UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
	{
		public override int State => 5;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix Six { get; }

		object IUnionValue.Value => Six;

		public UnionValueSix(TSix six, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Six = six;

		public bool Equals(UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Six, other.Six);

		public override int GetHashCode()
			=> Six.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Six:{Six}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		public abstract TThree? Three { get; }

		public abstract TFour? Four { get; }

		public abstract TFive? Five { get; }

		public abstract TSix? Six { get; }

		public abstract TSeven? Seven { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 2;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree Three { get; }

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		object IUnionValue.Value => Three;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 3;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour Four { get; }

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		object IUnionValue.Value => Four;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 4;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive Five { get; }

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		object IUnionValue.Value => Five;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal class UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 5;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix Six { get; }

		public override TSeven? Seven => default;

		object IUnionValue.Value => Six;

		public UnionValueSix(TSix six, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Six = six;

		public bool Equals(UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Six, other.Six);

		public override int GetHashCode()
			=> Six.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Six:{Six}";
	}

	[Serializable]
	internal class UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
	{
		public override int State => 6;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven Seven { get; }

		object IUnionValue.Value => Seven;

		public UnionValueSeven(TSeven seven, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Seven = seven;

		public bool Equals(UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Seven, other.Seven);

		public override int GetHashCode()
			=> Seven.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Seven:{Seven}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public abstract int State { get; }

		public abstract TOne? One { get; }

		public abstract TTwo? Two { get; }

		public abstract TThree? Three { get; }

		public abstract TFour? Four { get; }

		public abstract TFive? Five { get; }

		public abstract TSix? Six { get; }

		public abstract TSeven? Seven { get; }

		public abstract TEight? Eight { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		public override TEight? Eight => default;

		object IUnionValue.Value => One;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 1;

		public override TOne? One => default;

		public override TTwo Two { get; }

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		public override TEight? Eight => default;

		object IUnionValue.Value => Two;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 2;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree Three { get; }

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		public override TEight? Eight => default;

		object IUnionValue.Value => Three;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 3;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour Four { get; }

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		public override TEight? Eight => default;

		object IUnionValue.Value => Four;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 4;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive Five { get; }

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		public override TEight? Eight => default;

		object IUnionValue.Value => Five;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal class UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 5;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix Six { get; }

		public override TSeven? Seven => default;

		public override TEight? Eight => default;

		object IUnionValue.Value => Six;

		public UnionValueSix(TSix six, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Six = six;

		public bool Equals(UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Six, other.Six);

		public override int GetHashCode()
			=> Six.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Six:{Six}";
	}

	[Serializable]
	internal class UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 6;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven Seven { get; }

		public override TEight? Eight => default;

		object IUnionValue.Value => Seven;

		public UnionValueSeven(TSeven seven, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Seven = seven;

		public bool Equals(UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Seven, other.Seven);

		public override int GetHashCode()
			=> Seven.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Seven:{Seven}";
	}

	[Serializable]
	internal class UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, IUnionValue
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
		where TOne : notnull
		where TTwo : notnull
		where TThree : notnull
		where TFour : notnull
		where TFive : notnull
		where TSix : notnull
		where TSeven : notnull
		where TEight : notnull
	{
		public override int State => 7;

		public override TOne? One => default;

		public override TTwo? Two => default;

		public override TThree? Three => default;

		public override TFour? Four => default;

		public override TFive? Five => default;

		public override TSix? Six => default;

		public override TSeven? Seven => default;

		public override TEight Eight { get; }

		object IUnionValue.Value => Eight;

		public UnionValueEight(TEight eight, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Eight = eight;

		public bool Equals(UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Eight, other.Eight);

		public override int GetHashCode()
			=> Eight.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Eight:{Eight}";
	}
}
