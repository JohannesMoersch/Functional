using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[Serializable]
	public struct Result<TSuccess, TFailure> : IEquatable<Result<TSuccess, TFailure>>, ISerializable
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

#pragma warning disable CS8618, CS8601 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable. Possible null reference assignment.
		private Result(SerializationInfo info, StreamingContext context)
		{
			var isSuccess = info.GetBoolean(nameof(_isSuccess));

			if (isSuccess)
			{
				_isSuccess = true;
				_success = (TSuccess)info.GetValue(nameof(_success), typeof(TSuccess));
				_failure = default;
			}
			else
			{
				_isSuccess = false;
				_success = default;
				_failure = (TFailure)info.GetValue(nameof(_failure), typeof(TFailure));
			}
		}
#pragma warning restore CS8618, CS8601 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable. Possible null reference assignment.

		[AllowAllocations]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			var isSuccess = IsSuccess();

			info.AddValue(nameof(_isSuccess), isSuccess);
			if (isSuccess)
				info.AddValue(nameof(_success), _success);
			else
				info.AddValue(nameof(_failure), _failure);
		}

		internal bool IsSuccess()
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
			=> IsSuccess() == other.IsSuccess()
				&& (IsSuccess() ? EqualityComparer<TSuccess>.Default.Equals(_success, other._success) : EqualityComparer<TFailure>.Default.Equals(_failure, other._failure));

#pragma warning disable CS8602 // Dereference of a possibly null reference.
		public override int GetHashCode()
			=> IsSuccess() ? _success.GetHashCode() * 31 : _failure.GetHashCode() * 31;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

		public override bool Equals(object obj)
			=> obj is Result<TSuccess, TFailure> result && Equals(result);

		[AllowAllocations]
		public override string ToString()
			=> IsSuccess() ? $"Success:{_success}" : $"Failure:{_failure}";

		public static bool operator ==(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
			=> left.Equals(right);

		public static bool operator !=(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
			=> !left.Equals(right);
	}
}
