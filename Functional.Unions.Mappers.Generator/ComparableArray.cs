using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional.Unions.Mappers.Generator
{
	public struct ComparableArray : IReadOnlyList<int>, IEquatable<ComparableArray>
	{
		private readonly int[] _values;
		private readonly int _hashCode;

		public ComparableArray(IEnumerable<int> values)
		{
			_values = values?.ToArray() ?? throw new ArgumentNullException(nameof(values));
			_hashCode = values.Aggregate(0, (current, value) => HashCode.Combine(current, value));
			if (_hashCode == 0)
				_hashCode = 1;
		}

		public int this[int index] => _values?[index] ?? throw new ArgumentOutOfRangeException(nameof(index));

		public int Count => _values?.Length ?? 0;

		public bool Equals(ComparableArray other)
			=> other._hashCode == _hashCode && (_hashCode == 0 || other._values.SequenceEqual(_values));

		public override bool Equals(object obj)
			=> obj is ComparableArray arr && Equals(arr);

		public override int GetHashCode()
			=> _hashCode;

		public IEnumerator<int> GetEnumerator()
			=> (_values ?? Enumerable.Empty<int>()).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();
	}
}
