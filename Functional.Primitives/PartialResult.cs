namespace Functional;

public static class PartialResult
{
	public struct Success<TSuccess> : IEquatable<Success<TSuccess>>
		where TSuccess : notnull
	{
		public TSuccess Value { get; }

		internal Success(TSuccess value)
			=> Value = value;

		public override bool Equals(object? obj)
			=> obj is Success<TSuccess> result && Equals(result);

		public bool Equals(Success<TSuccess> other)
			=> EqualityComparer<TSuccess>.Default.Equals(Value, other.Value);

		public override int GetHashCode()
			=> -1937169414 + EqualityComparer<TSuccess>.Default.GetHashCode(Value);
	}

	public struct Failure<TFailure> : IEquatable<Failure<TFailure>>
		where TFailure : notnull
	{
		public TFailure Value { get; }

		internal Failure(TFailure value)
			=> Value = value;

		public override bool Equals(object? obj)
			=> obj is Failure<TFailure> result && Equals(result);

		public bool Equals(Failure<TFailure> other)
			=> EqualityComparer<TFailure>.Default.Equals(Value, other.Value);

		public override int GetHashCode()
			=> -1937169414 + EqualityComparer<TFailure>.Default.GetHashCode(Value);
	}
}
