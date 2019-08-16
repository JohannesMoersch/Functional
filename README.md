# Functional
[![Build status](https://ci.appveyor.com/api/projects/status/72c9ie6jvv7vhvl5/branch/master?svg=true)](https://ci.appveyor.com/project/JohannesMoersch/functional/branch/master)

Functional is a set of libraries that support functional programming patterns in C#.

## Option Types
Options are immutable types that can either have `Some` which is a typed value, or `None`. Option types should be used in any scenario where data can be null or empty, because unlike nullables, Options force the handling of the `None` case. Instead of using `null` or `-1` to present an empty id, use `Option<int>` with a value of `None`.
### Creating an Option Type
##### With a value
```csharp
Option<int> some = Option.Some(100);
```
##### With no value
```csharp
Option<int> none = Option.None<int>();
```
##### Conditionally
```csharp
Option<int> some = Option.Create(true, () => 100);
Option<int> none = Option.Create(false, () => 100);
```
##### From a nullable where null become `None`
```csharp
Option<int> some = Option.FromNullable((int?)100);
Option<int> none = Option.FromNullable((int?)null);
```
### Working with Option Types
#### Match
You cannot access the value of an Option type directly. Instead you work with Options functionally. Options only expose one function with the following signature:
```csharp
public TResult Match(Func<TValue, TResult> onSome, Func<TResult> onNone)
```
If the Option has a value, then the delegate in the first parameter is invoked and it's result is returned. If the Option has no value, then the delegate in the second parameter is invoked instead.
```csharp
string value = Option.Some(100).Match(v => $"Has value of {v}", () => "Has no value"); // Returns "Has value of 100"
string value = Option.None<int>().Match(v => $"Has value of {v}", () => "Has no value"); // Returns "Has no value"
```
Working with `Match` can be tedious, but there are many extension methods that make it easy and very powerful.
#### Select
If `Some`, this extension will return an Option with the value produced by the delegate parameter, and if `None` it will return `None`.
```csharp
Option<string> option = Option.Some(100).Select(v => $"{v}"); // Returns Option<string> with a value of "100"
Option<string> option = Option.None<int>().Select(v => $"{v}"); // Returns Option<string> with no value
```
#### Bind
If `Some`, this extension will return the Option returned by the delegate parameter, and if `None` it will return `None`.
```csharp
Option<string> option = Option.Some(100).Bind(v => Option.Some($"{v}")); // Returns Option<string> with a value of "100"
Option<string> option = Option.Some(100).Bind(v => Option.None<string>()); // Returns Option<string> with no value
Option<string> option = Option.None<int>().Bind(v => Option.Some($"{v}")); // Returns Option<string> with no value
```
#### HasValue
If `Some`, this extension will return `true`, and if `None` it will return `false`.
```csharp
bool value = Option.Some(100).HasValue(); // Returns true
bool value = Option.None<int>().HasValue(); // Returns false
```
#### ValueOrDefault
If `Some`, this extension will return the value, and if `None` it will return a specified default.
```csharp
int value = Option.Some(100).ValueOrDefault(50); // Returns 100
int value = Option.None<int>().ValueOrDefault(50); // Returns 50
```
#### ToNullable
This extension only works on value types. If `Some`, this extension will return the value, and if `None` it will return null.
```csharp
int? value = Option.Some<int>(100).ValueOrNull(); // Returns 100
int? value = Option.None<int>().ValueOrNull(); // Returns null
```
#### OfType
This extension only works on `Option<object>`. If `Some` and the value is of the specified type, then a typed Option is returned. Otherwise `None` is returned.
```csharp
Option<int> option = Option.Some<object>(100).OfType<int>(); // Returns Option<int> with a value of 100
Option<int> option = Option.Some<object>("100").OfType<int>(); // Returns Option<int> with no value
Option<int> option = Option.None<object>().OfType<int>(); // Returns Option<int> with no value
```
#### Where
If `Some`, this extension will invoke the delegate parameter and if true is returned it will return `Some` of the input value. Otherwise `None` is returned.
```csharp
Option<int> option = Option.Some(100).Where(v => true); // Returns Option<int> with a value of 100
Option<int> option = Option.Some(100).Where(v => false); // Returns Option<int> with no value
Option<int> option = Option.None<int>().Where(v => true); // Returns Option<int> with no value
```
#### Do
This extension returns the input Option and is meant only to create side effects. If `Some`, this extension will invoke the delegate parameter, and if `None` it will not. There are overloads that also accept a delegate parameter to execute when `None`.
```csharp
Option<int> option = Option.Some(100).Do(v => Console.WriteLine(v)); // Outputs 100 to the console and returns Option<int> with a value of 100
Option<int> option = Option.None<int>().Do(v => Console.WriteLine(v)); // Returns Option<int> with no value
```
#### Apply
This extension returns void and is meant only to create side effects. If `Some`, this extension will invoke the delegate parameter, and if `None` it will not. There are overloads that also accept a delegate parameter to execute when `None`.
```csharp
Option.Some(100).Apply(v => Console.WriteLine(v)); // Outputs 100 to the console
Option.None<int>().Apply(v => Console.WriteLine(v)); // Does nothing
```
#### ToResult
If `Some`, this extension will return a `Success` result with the value, and if `None` it will a `Failure` result contains the failure produced by the delegate parameter.
```csharp
Result<int, string> result = Option.Some<int>(100).ToResult(() => "Failure Message"); // Returns Result<int, string> with a success value of 100
Result<int, string> result = Option.None<int>().ToResult(() => "Failure Message"); // Returns Result<int, string> with a failure value of "Failure Message"
```

## Result Types
Results are immutable types that can either have a `Success` value, or a `Failure` value. Result types should be used in any scenario where code can produce an error, Results are particularly suitable for expected error cases, but can also be used to all error handling. Results force the handling of failures. Instead of throw exceptions or returning a null value, return a `Failure` result.
### Creating a Result Type
##### With a success value
```csharp
Result<int, string> success = Result.Success<int, string>(100);
```
##### With a failure value
```csharp
Result<int, string> failure = Result.Failure<int, string>("Failure");
```
##### Conditionally
```csharp
Result<int, string> success = Result.Create(true, () => 100, () => "Failure");
Result<int, string> failure = Result.Create(false, () => 100, () => "Failure");
```
##### With exception handling
```csharp
Result<int, Exception> success = Result.Try(() => 100));
Result<int, Exception> failure = Result.Try<int>(() => throw new Exception("Exception Message")));
Result<int, string> failure = Result.Try<int, string>(() => throw new Exception("Exception Message"), ex => ex.Message));
```
### Working with Result Types
#### Match
You cannot access the values of a Result type directly. Instead you work with Results functionally. Results only expose one function with the following signature:
```csharp
public TResult Match(Func<TSuccess, TResult> onSuccess, Func<TFailure, TResult> onFailure)
```
If the Result is a `Success`, then the delegate in the first parameter is invoked and it's result is returned. If the Result is a `Failure`, then the delegate in the second parameter is invoked instead.
```csharp
string value = Result.Success<int, string>(100).Match(s => $"Has success value of {s}", f => "Has failure value of {f}"); // Returns "Has success value of 100"
string value = Result.Success<int, string>("Failure").Match(s => $"Has success value of {s}", f => "Has failure value of {f}"); // Returns "Has failure value of Failure"
```
Working with `Match` can be tedious, but there are many extension methods that make it easy and very powerful.
#### Select
If `Success`, this extension will return a `Success` Result with the value produced by the delegate parameter, and if `Failure` it will return a `Failure` Result with the existing failure value.
```csharp
Result<int, string> result = Result.Success<float, string>(1.5).Select(v => (int)v); // Returns Result<int, string> with a success value of 1
Result<int, string> result = Result.Failure<float, string>("Failure").Select(v => (int)v); // Returns Result<int, string> with a failure value of "Failure"
```
#### TrySelect
If `Success`, this extension will execute the first delegate parameter. If an exception is thrown, it will execute the second delegate parameter (if provided), and return a `Failure` Result with the value produced by the second delegate parameter. If no exception is thrown, it will return a `Success` Result with the value produced by the first delegate parameter. If the input Result is a `Failure` it will return a `Failure` Result with the existing failure value.
```csharp
Result<int, string> result = Result.Success<float, string>(1.5).TrySelect(v => (int)v); // Returns Result<int, string> with a success value of 1
Result<int, string> result = Result.Success<float, string>(1.5).TrySelect(v => throw new Exception("Exception Message"), ex => ex.Message); // Returns Result<int, Exception> with a failure value of "Exception Message"
Result<int, string> result = Result.Failure<float, string>("Failure").Select(v => throw new Exception("Exception Message")); // Returns Result<int, string> with a failure value of "Failure"
```
#### Bind
If `Success`, this extension will return the Result returned by the delegate parameter, and if `Failure` it will return a `Failure` Result with the existing failure value.
```csharp
Result<int, string> result = Result.Success<float, string>(1.5).Bind(v => Result.Success<int, string>((int)v)); // Returns Result<int, string> with a success value of 1
Result<int, string> result = Result.Success<float, string>(1.5).Bind(v => Result.Failure<int, string>("Failure")); // Returns Result<int, string> with a failure value of "Failure"
Result<int, string> result = Result.Failure<float, string>("Failure").Bind(v => Result.Success<int, string>((int)v)); // Returns Result<int, string> with a failure value of "Failure"
```
#### IsSuccess
If `Success`, this extension will return `true`, and if `Failure` it will return `false`.
```csharp
bool value = Result.Success<int, string>(100).IsSuccess(); // Returns true
bool value = Result.Failure<int, string>("Failure").IsSuccess(); // Returns false
```
#### Success
If `Success`, this extension will return an Option containing the success value, and if `Failure` it will return `None`.
```csharp
Option<int> option = Result.Success<int, string>(100).Success(); // Returns Option<int> with a value of 100
Option<int> option = Result.Failure<int, string>("Failure").Success(); // Returns Option<int> with no value
```
#### Failure
If `Success`, this extension will return `None`, and if `Failure` it will return an Option containing the failure value.
```csharp
Option<string> option = Result.Success<int, string>(100).Failure(); // Returns Option<string> with no value
Option<string> option = Result.Failure<int, string>("Failure").Failure(); // Returns Option<string> with a value of "Failure"
```
