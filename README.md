# Functional
[![Build status](https://ci.appveyor.com/api/projects/status/72c9ie6jvv7vhvl5/branch/master?svg=true)](https://ci.appveyor.com/project/JohannesMoersch/functional/branch/master)
[![nuget](https://img.shields.io/nuget/v/Functional.All.svg)](https://www.nuget.org/packages/Functional.All/)

Functional is a set of libraries that support functional programming patterns in C#.

## Sections
[Option Types](#option-types)

[Result Types](#result-types)

[Query Expressions](#query-expressions)

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
#### BindIfNone
If `Some`, this extension will return the original Option.  If `None`, it will return the Option returned by the delegate parameter.
```csharp
Option<int> value = Option.Some(100).BindIfNone(() => Option.Some(50)); // Returns Option<int> with a value of 100
Option<int> value = Option.None<int>().BindIfNone(() => Option.Some(50)); // Returns Option<int> with a value of 50
Option<int> value = Option.None<int>().BindIfNone(() => Option.None<int>()); // Returns Option<int> with no value
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
If `Some`, this extension will invoke the delegate parameter and if `true` is returned it will return `Some` of the input value. Otherwise `None` is returned.
```csharp
Option<int> option = Option.Some(100).Where(v => true); // Returns Option<int> with a value of 100
Option<int> option = Option.Some(100).Where(v => false); // Returns Option<int> with no value
Option<int> option = Option.None<int>().Where(v => true); // Returns Option<int> with no value
```
#### Do
This extension returns the input Option and is meant only to create side effects. If `Some`, this extension will invoke the first delegate parameter, and if `None` it will invoke the second delegate parameter (if provided).
```csharp
Option<int> option = Option.Some(100).Do(v => Console.WriteLine(v)); // Outputs "100" to the console and returns Option<int> with a value of 100
Option<int> option = Option.None<int>().Do(v => Console.WriteLine(v)); // Returns Option<int> with no value
Option<int> option = Option.None<int>().Do(v => Console.WriteLine(v), () => Console.WriteLine("None")); // Outputs "None" to the console and returns Option<int> with no value
```
#### Apply
This extension returns void and is meant only to create side effects. If `Some`, this extension will invoke the first delegate parameter, and if `None` it will invoke the second delegate parameter (if provided).
```csharp
Option.Some(100).Apply(v => Console.WriteLine(v)); // Outputs "100" to the console
Option.None<int>().Apply(v => Console.WriteLine(v)); // Does nothing
Option.None<int>().Apply(v => Console.WriteLine(v), () => Console.WriteLine("None")); // Outputs "None" to the console
```
#### ToResult
If `Some`, this extension will return a `Success` result with the value, and if `None` it will a `Failure` result contains the failure produced by the delegate parameter.
```csharp
Result<int, string> result = Option.Some<int>(100).ToResult(() => "Failure Message"); // Returns Result<int, string> with a success value of 100
Result<int, string> result = Option.None<int>().ToResult(() => "Failure Message"); // Returns Result<int, string> with a failure value of "Failure Message"
```

## Result Types
Results are immutable types that can either have a `Success` value, or a `Failure` value. Result types should be used in any scenario where code can produce an error, Results are particularly suitable for expected error cases, but can also be used for all error handling. Results force the handling of failures. Instead of throwing exceptions or returning a null value, return a `Failure` result.
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
Result<int, string> result = Result.Success<float, string>(1.5).Select(s => (int)s); // Returns Result<int, string> with a success value of 1
Result<int, string> result = Result.Failure<float, string>("Failure").Select(s => (int)s); // Returns Result<int, string> with a failure value of "Failure"
```
#### TrySelect
If `Success`, this extension will execute the first delegate parameter. If an exception is thrown, it will execute the second delegate parameter (if provided), and return a `Failure` Result with the value produced by the second delegate parameter. If no exception is thrown, it will return a `Success` Result with the value produced by the first delegate parameter. If the input Result is a `Failure` it will return a `Failure` Result with the existing failure value.
```csharp
Result<int, string> result = Result.Success<float, string>(1.5).TrySelect(s => (int)s); // Returns Result<int, string> with a success value of 1
Result<int, string> result = Result.Success<float, string>(1.5).TrySelect(s => throw new Exception("Exception Message"), ex => ex.Message); // Returns Result<int, Exception> with a failure value of "Exception Message"
Result<int, string> result = Result.Failure<float, string>("Failure").Select(s => throw new Exception("Exception Message"), ex => ex.Message); // Returns Result<int, string> with a failure value of "Failure"
```
#### Bind
If `Success`, this extension will return the Result returned by the delegate parameter, and if `Failure` it will return a `Failure` Result with the existing failure value.
```csharp
Result<int, string> result = Result.Success<float, string>(1.5).Bind(s => Result.Success<int, string>((int)s)); // Returns Result<int, string> with a success value of 1
Result<int, string> result = Result.Success<float, string>(1.5).Bind(s => Result.Failure<int, string>("Failure")); // Returns Result<int, string> with a failure value of "Failure"
Result<int, string> result = Result.Failure<float, string>("Failure").Bind(s => Result.Success<int, string>((int)s)); // Returns Result<int, string> with a failure value of "Failure"
```
#### BindIfFailure
If `Success`, this extension will return the original Result.  If `Failure`, it will return the Result returned by the delegate parameter.
```csharp
Result<float, string> result = Result.Success<float, string>(1.5).BindIfFailure(f => Result.Success<float, string>(s * 2)); // Returns Result<float, string> with a success value of 1.5
Result<float, string> result = Result.Failure<float, string>("Failure").BindIfFailure(f => Result.Success<float, string>(1337)); // Returns Result<float, string> with a success value of 1337
Result<float, string> result = Result.Failure<float, string>("Failure").BindIfFailure(f => Result.Failure<float, string>("More failure")); // Returns Result<float, string> with a failure value of "More failure"
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
#### Where
If `Success`, this extension will invoke the first delegate parameter and if `true` is returned it will return `Success` of the input success value. If `false` is returns from the first delegate parameter it will return a `Failure` Result with the failure value produced by the second delegate parameter. If the input Result is a `Failure` it will return a `Failure` Result with the existing failure value.
```csharp
Result<int, string> result = Result.Success<int, string>(100).Where(s => true, s => $"Failed on value {v}"); // Returns Result<int, string> with a success value of 100
Result<int, string> result = Result.Success<int, string>(100).Where(s => false, s => $"Failed on value {v}"); // Returns Result<int, string> with a failure value of "Failed on value 100"
Result<int, string> result = Result.Failure<int, string>("Failure").Where(s => true, s => $"Failed on value {v}"); // Returns Result<int, string> with a failure value of "Failure"
```
#### MapFailure
If `Success`, this extension will return a `Success` Result with the existing success value, and if `Failure` it will return a `Failure` Result with the value produced by the delegate parameter.
```csharp
Result<int, int> result = Result.Success<int, string>(100).MapFailure(f => f.Length); // Returns Result<int, int> with a success value of 100
Result<int, int> result = Result.Failure<int, string>("Failure").MapFailure(f => f.Length); // Returns Result<int, int> with a failure value of 7
```
#### Do
This extension returns the input Result and is meant only to create side effects. If `Success`, this extension will invoke the first delegate parameter, and if `Failure` it will invoke the second delegate parameter (if provided).
```csharp
Result<int, string> result = Result.Success<int, string>(100).Do(s => Console.WriteLine(s)); // Outputs "100" to the console and returns Result<int, string> with a success value of 100
Result<int, string> result = Result.Failure<int, string>("Failure").Do(s => Console.WriteLine(s)); // Returns Result<int, string> with a failure value of "Failure"
Result<int, string> result = Result.Failure<int, string>("Failure").Do(s => Console.WriteLine(s), f => Console.WriteLine(f)); // Outputs "Failure" to the console and returns Result<int, string> with a failure value of "Failure"
```
#### Apply
This extension returns void and is meant only to create side effects. If `Success`, this extension will invoke the first delegate parameter, and if `Failure` it will invoke the second delegate parameter (if provided).
```csharp
Result.Success<int, string>(100).Do(s => Console.WriteLine(s)); // Outputs "100" to the console
Result.Failure<int, string>("Failure").Do(s => Console.WriteLine(s)); // Does nothing
Result.Failure<int, string>("Failure").Do(s => Console.WriteLine(s), f => Console.WriteLine(f)); // Outputs "Failure" to the console
```

#### SelectIfSome

This extension is only available for `Result<Option<T>, TFailure>` types.  If `Success` and holds an Option with a value, this extension will invoke the delegate parameter.  If `Success` and holds an Option with no value, the delegate parameter will *not* be invoked, but this extension method will return a `Success` Result holding an Option with no value for the type that would have been produced by the delegate parameter.  If `Failure` it will return a `Failure` Result with the existing failure value.

```csharp
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).SelectIfSome(i => i / 2f); // Returns Result<Option<float>, string> with a success value of Option.Some(50f)
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSome(i => i / 2f); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<float>, string> result = Result.Failure<Option<int>, string>("Failure").SelectIfSome(i => i / 2f); // Returns Result<Option<float>, string> with a failure value of "Failure"
```

#### BindIfSome

This extension is only available for `Result<Option<T>, TFailure>` types.  If `Success` and holds an Option with a value, this extension will return the Result returned by the delegate parameter.  If `Success` and holds an Option with no value, this extension will return a Result holding an Option with no value matching the type that would be produced by the delegate parameter.  If `Failure` it will return a `Failure` Result with the existing failure value.

```csharp
// bind to functions producing Result<TSuccess, TFailure>
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfSome(i => Result.Success<float, string>(i * 2f)); // Returns Result<Option<float>, string> with a success value of Option.Some(200f)
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfSome(i => Result.Failure<float, string>("Failure")); // Returns Result<Option<float>, string> with a failure value of "Failure"
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(i => Result.Success<float, string>(i * 2f)); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(i => Result.Failure<float, string>("Failure")); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<float>, string> result = Result.Failure<Option<int>, string>("Failure").BindIfSome(i => Result.Success<float, string>(i * 2f)); // Returns Result<Option<float>, string> with a failure value of "Failure"

// bind to functions producing Result<Option<T>>, TFailure>
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfSome(i => Result.Success<Option<float>, string>(Option.Some(i * 2f))); // Returns Result<Option<float>, string> with a success value of Option.Some(200f)
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfSome(i => Result.Failure<Option<float>, string>("Failure")); // Returns Result<Option<float>, string> with a failure value of "Failure"
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(i => Result.Success<Option<float>, string>(Option.Some(i * 2f))); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(i => Result.Failure<Option<float>, string>("Failure")); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<float>, string> result = Result.Failure<Option<int>, string>("Failure").BindIfSome(i => Result.Success<Option<float>, string>(Option.Some(i * 2f))); // Returns Result<Option<float>, string> with a failure value of "Failure"
```

#### SelectIfNone

This extension is only available for `Result<Option<T>, TFailure>` types.  If `Success` and holds an Option with a value, this extension will return a `Success` Result with the existing success value.  If `Success` and holds an Option with no value, it will invoke the delegate parameter, producing a `Success` Result holding an Option containing the value produced by the delegate.  If `Failure` it will return a `Failure` Result with the existing failure value.

```csharp
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).SelectIfNone(() => 1337); // Returns Result<Option<int>, string> with a success value of Option.None<int>
Result<Option<float>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).SelectIfNone(() => 1337); // Returns Result<Option<int>, string> with a success value of Option.Some(1337)
Result<Option<float>, string> result = Result.Failure<Option<int>, string>("Failure").SelectIfNone(() => 1337); // Returns Result<Option<int>, string> with a failure value of "Failure"
```

#### BindIfNone

This extension is only available for `Result<Option<T>, TFailure>` types.  If `Success` and holds an Option with a value, it will return a `Success` Result with the existing success value.  If `Success` and holds an Option with no value, it will invoke the delegate parameter.  If `Failure` it will return a `Failure` Result with the existing failure value.

```csharp
// bind to functions producing Result<TSuccess, TFailure>
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfNone(()) => Result.Success<int, string>(i * 2)); // Returns Result<Option<int>, string> with a success value of Option.Some(100)
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfNone(() => Result.Failure<int, string>("Failure")); // Returns Result<Option<int>, string> with a success value of Option.Some(100)
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfNone(() => Result.Success<int, string>(i * 2)); // Returns Result<Option<int>, string> with a success value of Option.None<float>
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfNone(() => Result.Failure<int, string>("Failure")); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<int>, string> result = Result.Failure<Option<int>, string>("Failure").BindIfNone(() => Result.Success<int, string>(i * 2)); // Returns Result<Option<float>, string> with a failure value of "Failure"

// bind to functions producing Result<Option<T>>, TFailure>
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfNone(() => Result.Success<Option<float>, string>(Option.Some(i * 2f))); // Returns Result<Option<float>, string> with a success value of Option.Some(200f)
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).BindIfNone(() => Result.Failure<Option<float>, string>("Failure")); // Returns Result<Option<float>, string> with a failure value of "Failure"
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfNone(() => Result.Success<Option<float>, string>(Option.Some(i * 2f))); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).BindIfNone(() => Result.Failure<Option<float>, string>("Failure")); // Returns Result<Option<float>, string> with a success value of Option.None<float>
Result<Option<int>, string> result = Result.Failure<Option<int>, string>("Failure").BindIfNone(() => Result.Success<Option<float>, string>(Option.Some(i * 2f))); // Returns Result<Option<float>, string> with a failure value of "Failure"
```

#### DoIfSome

This extension is only available for `Result<Option<T>, TFailure>` types.  It retuns the input Result and is meant only to create side effects.  If `Success` and holds an Option with a value, this extension will invoke the delegate parameter.

```csharp
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.Some(100)).DoIfSome(i => Console.WriteLine(i)); // Outputs "100" to the console and returns Result<Option<int>, string> with a success value of Option.Some(100)
Result<Option<int>, string> result = Result.Success<Option<int>, string>(Option.None<int>()).DoIfSome(i => Console.WriteLine(i)); // Does nothing and returns Result<Option<int>, string> with a success value of Option.None<int>
Result<Option<int>, string> result = Result.Failure<Option<int>, string>("Failure").DoIfSome(i => Console.WriteLine(i)); // Does nothing and returns Result<Option<int>, string> with a failure value of "Failure"
```

#### ApplyIfSome

This extension is only available for `Result<Option<T>, TFailure>` types.  It returns void and is meant only to create side effects.  If `Success` and holds an Option with a value, this extension will invoke the delegate parameter; in all other cases, it does nothing.

```csharp
Result.Success<Option<int>, string>(Option.Some(100)).ApplyIfSome(i => Console.WriteLine(i)); // Outputs "100" to the console
Result.Success<Option<int>, string>(Option.None<int>()).ApplyIfSome(i => Console.WriteLine(i)); // Does nothing
Result.Failure<Option<int>, string>("Failure").ApplyIfSome(i => Console.WriteLine(i)); // Does nothing
```

## Query Expressions
Chaining and nested many extensions on Results or Options can quickly become difficult to read. In these scenarios, the query expression syntax can dramatically improve code readability.

### Results
For the following code snippets, assume the following methods are declared.
```csharp
public Result<Value, Error> LoadValue(int id);
public Result<MappedValue, Error> MapValue(Value value);
public Result<AdditionalData, Error> LoadAdditionalData(Value value);
public Result<CombinedData, Error> Combine(MappedValue mappedValue, AdditionalData additionalData);
```
Here is a basic example of a `Bind` and then a `Select` written in the standard functional syntax.
```csharp
public Result<(int Id, MappedValue Value), Error> LoadAndMapValue(int id)
	=> LoadValue(id)
		.Bind(value => MapValue(value))
		.Select(mappedValue => (id, mappedValue));
```
Here is the equivalent code written as a query expression.
```csharp
public Result<(int Id, MappedValue Value), Error> LoadAndMapValue(int id)
	=>
	from value in LoadValue(id)
	from mappedValue in MapValue(value)
	select (id, mappedValue);
```
Both are pretty straight forward to read. We load the data, then we map the data, and then we return the data.

Now let's consider a more complex scenario where we don't simply have a linear chain of functions.
```csharp
public Result<(int Id, CombinedData Data), Error> LoadAndMapValue(int id)
	=> LoadValue(id)
		.Bind(value => LoadAdditionalData(value)
			.Bind(additionalData => MapValue(value)
				.Bind(mappedValue => Combine(mappedValue, additionalData))
			)
		)
		.Select(combinedData => (id, combinedData));
```
This time the value from `LoadValue` is used by multiple subsequent function calls, and this introduces nesting which damages the readability of the expression.

Here is the equivalent code written using a query expression.
```csharp
public Result<(int Id, CombinedData Data), Error> LoadAndMapValue(int id)
	=>
	from value in LoadValue(id)
	from mappedValue in MapValue(value)
	from additionalData in LoadAdditionalData(value)
	from combinedData in Combine(mappedValue, additionalData)
	select (id, combinedData);
```
This syntax allows us to keep the chain of function calls more clearly sequential and makes the statement easier to read.

### Options
The query syntax is also available for Options and behaves in a similar way. For the following code snippet, assume the following methods are declared.
```csharp
public Option<Guid> GetID();
public Option<string> GetInfo();
public Option<int> GetValue();
```

To combine the return values of the above three functions into a single Option, use the following query syntax.
```csharp
public Option<(Guid ID, string Info, int Value)> GetTuple()
	=>
	from id in GetID() // 'id' is Guid type
	from info in GetInfo() // 'info' is string type
	from value in GetValue() // 'value' is int type
	select (id, info, value); // produces Option<(Guid, string ,int)>
```

If any of the three Option-producing functions return `Option.None<T>`, then the value returned from `GetTuple` will be `Option.None<(Guid, string, int)>`.
