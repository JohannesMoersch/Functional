using System;
using System.Threading.Tasks;

namespace Functional
{
	[Serializable]
	public struct Option<TValue> : IEquatable<Option<TValue>>
	{
		private readonly bool _hasValue;

		private readonly TValue _value;

		internal Option(bool hasValue, TValue value)
		{
			_hasValue = hasValue;

			_value = value;
		}

		public TResult Match<TResult>(Func<TValue, TResult> some, Func<TResult> none)
		{
			if (some == null)
				throw new ArgumentNullException(nameof(some));

			if (none == null)
				throw new ArgumentNullException(nameof(none));

			return _hasValue ? some.Invoke(_value) : none.Invoke();
		}

		public bool Equals(Option<TValue> other)
			=> _hasValue == other._hasValue && (!_hasValue || Equals(_value, other._value));

		public override int GetHashCode()
			=> _hasValue ? _value.GetHashCode() * 31 : 0;

		public override bool Equals(object obj)
			=> obj is Option<TValue> option && Equals(option);

		public override string ToString()
			=> _hasValue ? $"Some:{_value}" : "None";

		public static bool operator ==(Option<TValue> left, Option<TValue> right)
			=> left.Equals(right);

		public static bool operator !=(Option<TValue> left, Option<TValue> right)
			=> !left.Equals(right);
	}
}
