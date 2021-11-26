using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public struct NoneOption : IEquatable<NoneOption>
	{
		public bool Equals(NoneOption other) 
			=> true;
		
		public override bool Equals(object obj) 
			=> obj is NoneOption;
		
		public override int GetHashCode() 
			=> -1937169414;
	}
}
