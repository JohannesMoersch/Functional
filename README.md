# Functional

[![Build status](https://ci.appveyor.com/api/projects/status/72c9ie6jvv7vhvl5/branch/master?svg=true)](https://ci.appveyor.com/project/JohannesMoersch/functional/branch/master)

Functional is a set of libraries that support functional programming patterns in C#.

## Option Types
Options are immutable types that can either have `Some` which is a typed value, or `None`. Option types should be used in any scenario where data can be null or empty, because unlike nullables, Options force the handling of the `None` case. Instead of using `null` or `-1` to present an empty id, use `Option<int>` with a value of `None`.
### Creating an Option Type
##### With a value
```csharp
Option<int> option = Option.Some(100);
```
##### With no value
```csharp
Option<int> option = Option.None<int>();
```
##### Conditionally
```csharp
Option<int> option = Option.Create(true, () => 100);
Option<int> option = Option.Create(false, () => 100);
```
##### From a nullable where null become `None`
```csharp
Option<int> option = Option.FromNullable((int?)100);
Option<int> option = Option.FromNullable((int?)null);
```
### Working with Option Types
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
bool value = Option.Some(100).HasValue(); // Returns `true`
bool value = Option.None<int>().HasValue(); // Returns `false`
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
