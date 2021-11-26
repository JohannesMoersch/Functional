using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public struct FailureResult<TFailure> : IEquatable<FailureResult<TFailure>> 
		where TFailure : notnull
	{
		public TFailure Value { get; }

		internal FailureResult(TFailure value)
			=> Value = value;

		public override bool Equals(object? obj) 
			=> obj is FailureResult<TFailure> result && Equals(result);
		
		public bool Equals(FailureResult<TFailure> other) 
			=> EqualityComparer<TFailure>.Default.Equals(Value, other.Value);
		
		public override int GetHashCode() 
			=> -1937169414 + EqualityComparer<TFailure>.Default.GetHashCode(Value);
	}
}
