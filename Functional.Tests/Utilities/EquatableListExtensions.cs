using System.Collections.Generic;
using System.Linq;

namespace Functional.Tests.Utilities;

public static class EquatableListExtensions
{
	public static EquatableList<T> ToEquatableList<T>(this IEnumerable<T> list)
		=> list is EquatableList<T> equatableList
			? equatableList
			: new EquatableList<T>(list as IReadOnlyList<T> ?? list.ToList());
}
