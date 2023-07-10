namespace Functional.Unions.Tests;

/*
internal interface DiscriminatedUnion<TOne, TTwo, TThree> { }

public class GetStuffFailure<TValue> 
	: DiscriminatedUnion<
		GetStuffFailure<TValue>.NetworkPartition, 
		GetStuffFailure<TValue>.DeserializationFailure, 
		Other
	>
{
	public record NetworkPartition;
	public record DeserializationFailure;
}

public class NewTestUnion<TValue> : DiscriminatedUnion<NewTestUnion<TValue>.One, TValue, bool>
{
	public record One;

	public record Success;
}
public class TestTestAttribute : Attribute
{
	public TestTestAttribute(Type type)
	{
	}

}

public class BlahBlah<T>
{
	public class NestedAttribute : Attribute
	{
		public class T { }
	}
}
*/

public class UnitTest1
{
	[Fact]
	public void Test1()
	{
		TestUnion union = new Blah(10);

		Blah value = union switch
		{
			TestUnion.Blah blah => blah,
			_ => throw new Exception()
		};

		var num = value.number;

		var a = GeneratedTestUnion.Create(new Blah());
	}
}

public record struct Blah(int number);
public record struct Other;
public record struct Thing;

//[DiscriminatedUnion<DU.FromGeneric.TValue, Other, Thing, DU.New.NewThing>]
public partial record GeneratedTestUnion : DiscriminatedUnion<Blah, Thing>
{
	internal static class DU
	{
		internal static class FromGeneric
		{
			internal record TValue;
		}

		internal static class New
		{
			internal record NewThing;
		}
	}
}

public partial record TestUnion;

public abstract partial record TestUnion
{
	private TestUnion() { }

	public sealed record Blah : TestUnion
	{
		private readonly global::Functional.Unions.Tests.Blah _blah;

		public Blah(global::Functional.Unions.Tests.Blah blah) 
			=> _blah = blah;

		public override T Match<T>(Func<Tests.Blah, T> onBlah, Func<Tests.Other, T> onOther, Func<Tests.Thing, T> onThing)
			=> onBlah.Invoke(_blah);

		public global::Functional.Unions.Tests.Blah Unwrap()
			=> _blah;

		public static implicit operator global::Functional.Unions.Tests.Blah(Blah blah)
			=> blah.Unwrap();
	}

	public sealed record Other : TestUnion
	{
		private readonly global::Functional.Unions.Tests.Other _other;

		public Other(global::Functional.Unions.Tests.Other other)
			=> _other = other;

		public override T Match<T>(Func<Tests.Blah, T> onBlah, Func<Tests.Other, T> onOther, Func<Tests.Thing, T> onThing)
			=> onOther.Invoke(_other);

		public global::Functional.Unions.Tests.Other Unwrap()
			=> _other;

		public static implicit operator global::Functional.Unions.Tests.Other(Other other)
			=> other.Unwrap();
	}

	public sealed record Thing : TestUnion
	{
		private readonly global::Functional.Unions.Tests.Thing _thing;

		public Thing(global::Functional.Unions.Tests.Thing thing)
			=> _thing = thing;

		public override T Match<T>(Func<Tests.Blah, T> onBlah, Func<Tests.Other, T> onOther, Func<Tests.Thing, T> onThing)
			=> onThing.Invoke(_thing);

		public global::Functional.Unions.Tests.Thing Unwrap()
			=> _thing;

		public static implicit operator global::Functional.Unions.Tests.Thing(Thing thing)
			=> thing.Unwrap();
	}

	public abstract T Match<T>(Func<global::Functional.Unions.Tests.Blah, T> onBlah, Func<global::Functional.Unions.Tests.Other, T> onOther, Func<global::Functional.Unions.Tests.Thing, T> onThing);

	public static TestUnion Create(global::Functional.Unions.Tests.Blah blah)
		=> new Blah(blah);

	public static TestUnion Create(global::Functional.Unions.Tests.Other other)
		=> new Other(other);

	public static TestUnion Create(global::Functional.Unions.Tests.Thing thing)
		=> new Thing(thing);

	public static implicit operator TestUnion(global::Functional.Unions.Tests.Blah blah)
		=> TestUnion.Create(blah);

	public static implicit operator TestUnion(global::Functional.Unions.Tests.Other other)
		=> TestUnion.Create(other);

	public static implicit operator TestUnion(global::Functional.Unions.Tests.Thing thing)
		=> TestUnion.Create(thing);
}