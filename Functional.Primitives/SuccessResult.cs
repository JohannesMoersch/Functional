using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public struct SuccessResult<TSuccess> : IEquatable<SuccessResult<TSuccess>>
		where TSuccess : notnull
	{
		public TSuccess Value { get; }

		internal SuccessResult(TSuccess value)
			=> Value = value;

		public override bool Equals(object? obj) 
			=> obj is SuccessResult<TSuccess> result && Equals(result);
		
		public bool Equals(SuccessResult<TSuccess> other) 
			=> EqualityComparer<TSuccess>.Default.Equals(Value, other.Value);
		
		public override int GetHashCode() 
			=> -1937169414 + EqualityComparer<TSuccess>.Default.GetHashCode(Value);
	}
}
