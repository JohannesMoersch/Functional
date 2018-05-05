using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    public struct Unit : IEquatable<Unit>
	{
		public static Unit Default { get; } = new Unit();

		public bool Equals(Unit other)
			=> true;

		public override int GetHashCode()
			=> 0;

		public override bool Equals(object obj)
			=> obj is Unit;

		public override string ToString()
			=> "Unit";
	}
}
