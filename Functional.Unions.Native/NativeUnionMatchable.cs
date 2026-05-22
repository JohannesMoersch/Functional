// This file is intentionally empty.
// Select/SelectMany on native Union<TSuccess, TFailure> return Union<TResult, TFailure>
// directly — the same zero-allocation pattern used by Result<TSuccess, TFailure> LINQ
// query expressions.  No wrapper types are needed.

