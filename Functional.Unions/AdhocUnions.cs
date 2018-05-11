using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>
    {
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> value)
			=> _value = value;

		public bool Equals(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> right)
			=> !left.Equals(right);

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TOne one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TOne> one)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, UnionHelpers.CheckForNull(await one, nameof(one)), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TTwo two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), UnionHelpers.CheckForNull(two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TTwo> two)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), UnionHelpers.CheckForNull(await two, nameof(two)), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TThree three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TThree> three)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), UnionHelpers.CheckForNull(await three, nameof(three)), default(TFour), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TFour four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TFour> four)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), UnionHelpers.CheckForNull(await four, nameof(four)), default(TFive), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TFive five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TFive> five)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), UnionHelpers.CheckForNull(await five, nameof(five)), default(TSix), default(TSeven), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TSix six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(six, nameof(six)), default(TSeven), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TSix> six)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), UnionHelpers.CheckForNull(await six, nameof(six)), default(TSeven), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TSeven seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(seven, nameof(seven)), default(TEight), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TSeven> seven)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), UnionHelpers.CheckForNull(await seven, nameof(seven)), default(TEight), CreateUnion));

		public static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Create(TEight eight)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(eight, nameof(eight)), CreateUnion));

		public static async Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Create(Task<TEight> eight)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(new UnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(0, default(TOne), default(TTwo), default(TThree), default(TFour), default(TFive), default(TSix), default(TSeven), UnionHelpers.CheckForNull(await eight, nameof(eight)), CreateUnion));

		private static Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> CreateUnion(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> value)
			=> new Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(value);
	}
}
