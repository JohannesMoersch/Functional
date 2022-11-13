# `Result<TSuccess, TFailure>` Collections

## TakeUntilFailure

This extension method will iterate over all `Result`.  If all `Result` are `Success`, this extension method returns a `Success` Result with all success values.  If any `Result` are `Failure`, this extension method will return a `Failure` Result with the first `Failure`.

``` csharp
var result1 = Result.Success<int, string>(1);
var result2 = Result.Success<int, string>(2);
var result3 = Result.Success<int, string>(3);
var resultCollection = new[] { result1, result2, result3 };

// Returns Result<int[], string> with a success value of { 1, 2, 3 }
var finalResult = resultCollection.TakeUntilFailure();
```

``` csharp
var result1 = Result.Success<int, string>(1);
var result2 = Result.Failure<int, string>("ERROR 1");
var result3 = Result.Failure<int, string>("ERROR 2");
var resultCollection = new[] { result1, result2, result3 };

// Returns Result<int[], string> with a failure value of "ERROR 1"
var finalResult = resultCollection.TakeUntilFailure();
```

## TakeAll

This extension method will iterate over all `Result`.  If all `Result` are `Success`, this extension method returns a `Success` Result with all success values.  If any `Result` are `Failure`, this extension method will return a `Failure` Result with all failure values.

``` csharp
var result1 = Result.Success<int, string>(1);
var result2 = Result.Success<int, string>(2);
var result3 = Result.Success<int, string>(3);
var resultCollection = new[] { result1, result2, result3 };

// Returns Result<int[], string[]> with a success value of { 1, 2, 3 }
var finalResult = resultCollection.TakeAll();
```

``` csharp
var result1 = Result.Success<int, string>(1);
var result2 = Result.Failure<int, string>("ERROR 1");
var result3 = Result.Failure<int, string>("ERROR 2");
var resultCollection = new[] { result1, result2, result3 };

// Returns Result<int[], string[]> with a failure value of { "ERROR 1", "ERROR 2" }
var finalResult = resultCollection.TakeAll();
```

## Partition

This extension method a `ResultPartition` that holds an enumerable of all `Success` and an enumerable of all `Failure`. Execution of the `Successes` and `Failures` enumerables is deferred and cached so it will only be evaluated once.

``` csharp
var result1 = Result.Success<int, string>(1);
var result2 = Result.Success<int, string>(2);
var result3 = Result.Success<int, string>(3);
var resultCollection = new[] { result1, result2, result3 };

// Returns ResultPartition<int, string> with Successes of { 1, 2, 3 } and empty Failures
var resultPartition = resultCollection.Partition();
```

``` csharp
var result1 = Result.Success<int, string>(1);
var result2 = Result.Failure<int, string>("ERROR 1");
var result3 = Result.Failure<int, string>("ERROR 2");
var resultCollection = new[] { result1, result2, result3 };

// Returns ResultPartition<int, string> with Successes of { 1 } and Failures of { "ERROR 1", "ERROR 2" }
var resultPartition = resultCollection.Partition();
```
