using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public static class PartialOption
	{
		public struct None : IEquatable<None>
		{
			public bool Equals(None other)
				=> true;

			public override bool Equals(object? obj)
				=> obj is None;

			public override int GetHashCode()
				=> -1937169414;
		}
	}
}
