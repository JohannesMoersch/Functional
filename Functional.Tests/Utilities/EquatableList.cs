using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Tests.Utilities;

public class EquatableList<T> : IReadOnlyList<T>, IEquatable<EquatableList<T>?>
{
	private readonly IReadOnlyList<T> _list;

	public T this[int index] => _list[index];

	public int Count => _list.Count;

	public EquatableList(IReadOnlyList<T> list) 
		=> _list = list ?? throw new ArgumentNullException(nameof(list));

	public IEnumerator<T> GetEnumerator()
		=> _list.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> _list.GetEnumerator();

	public override bool Equals(object? obj) 
		=> Equals(obj as EquatableList<T>);

	public bool Equals(EquatableList<T>? other) 
		=> other is not null && _list.SequenceEqual(other._list, EqualityComparer<T>.Default);

	public override int GetHashCode()
		=> _list.Aggregate(1326741473, HashCode.Combine);

	public static bool operator ==(EquatableList<T>? left, EquatableList<T>? right) 
		=> EqualityComparer<EquatableList<T>>.Default.Equals(left, right);

	public static bool operator !=(EquatableList<T>? left, EquatableList<T>? right) 
		=> !(left == right);
}
