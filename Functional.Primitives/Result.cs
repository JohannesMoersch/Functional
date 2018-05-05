using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public struct Result<TSuccess, TFailure> : IEquatable<Result<TSuccess, TFailure>>
	{
		private readonly bool? _isSuccess;

		private readonly TSuccess _success;

		private readonly TFailure _failure;

		internal Result(bool isSuccess, TSuccess success, TFailure failure)
		{
			_isSuccess = isSuccess;
			_success = success;
			_failure = failure;
		}

		private bool IsSuccess()
			=> _isSuccess ?? throw new ResultNotInitializedException();

		public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
		{
			if (success == null)
				throw new ArgumentNullException(nameof(success));

			if (failure == null)
				throw new ArgumentNullException(nameof(failure));

			return IsSuccess() ? success.Invoke(_success) : failure.Invoke(_failure);
		}

		public bool Equals(Result<TSuccess, TFailure> other)
			=> IsSuccess() ? Equals(_success, other._success) : Equals(_failure, other._failure);

		public override int GetHashCode()
			=> IsSuccess() ? _success.GetHashCode() * 31 : _failure.GetHashCode() * 31;

		public override bool Equals(object obj)
			=> obj is Result<TSuccess, TFailure> result && Equals(result);

		public override string ToString()
			=> IsSuccess() ? $"Success:{_success}" : $"Failure:{_failure}";

		public static bool operator ==(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
			=> left.Equals(right);

		public static bool operator !=(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
			=> !left.Equals(right);
	}
}
