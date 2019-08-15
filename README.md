# Functional

[![Build status](https://ci.appveyor.com/api/projects/status/72c9ie6jvv7vhvl5/branch/master?svg=true)](https://ci.appveyor.com/project/JohannesMoersch/functional/branch/master)

Functional is a set of libraries that support functional programming patterns in C#.

## Option Types
Option types can either have `Some` which is a typed value, or `None`. Option types should be used in any scenario where data can be null or empty, because unlike nullables, Options force the handling of the `None` case. Instead of using `null` or `-1` to present an empty id, use `Option<int>` with a value of `None`.
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
You cannot access the value of an Option type directly. Instead you work with Options functionally. Options only expose one function with the following signature:
```csharp
public TResult Match(Func<TValue, TResult> onSome, Func<TResult> onNone)
```
If the Option has a value, then the delegate in the first parameter is invoked and it's result is returned. If the Option has no value, then the delegate in the second parameter is invoked instead.
```csharp
var value = Option.Some(100).Match(v => $"Has value of {v}", () => "Has no value"); // Returns "Has value of 100"
var value = Option.None<int>().Match(v => $"Has value of {v}", () => "Has no value"); // Returns "Has no value"
```
