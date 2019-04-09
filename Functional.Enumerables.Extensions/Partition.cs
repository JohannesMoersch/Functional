using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public struct Partition<T>
	{
		public IEnumerable<T> Matches { get; }

		public IEnumerable<T> NonMatches { get; }

		internal Partition(IEnumerable<T> matches, IEnumerable<T> nonMatches)
		{
			Matches = matches ?? throw new ArgumentNullException(nameof(matches));
			NonMatches = nonMatches ?? throw new ArgumentNullException(nameof(nonMatches));
		}

		public void Deconstruct(out IEnumerable<T> matches, out IEnumerable<T> nonMatches)
		{
			matches = Matches;
			nonMatches = NonMatches;
		}
	}
}
