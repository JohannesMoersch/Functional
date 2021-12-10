# `Option<TValue>` Types

An `Option<TValue>` is an immutable type that can either have `Some` which is a typed value, or `None`. Option types should be used in any scenario where data can be null or empty; unlike nullables, an `Option` forces consuming code to handle the `None` case. Instead of using `null` or `-1` to present an empty id, use `Option<int>` with a value of `None`.

## Creating an `Option<TValue>`

### With a value

```csharp
Option<int> some = Option.Some(100);
```

### With no value

```csharp
Option<int> none = Option.None<int>();
```

### With type inferencing when target type is known

```csharp
Option<int> success = 100;
Option<int> none = Option.None();

// or as a return from a method
Option<int> MakeSome() => 100;
Result<int> MakeNone() => Option.None();
```

### Conditionally

```csharp
Option<int> some = Option.Create(true, () => 100);
Option<int> none = Option.Create(false, () => 100);
```

### From a nullable where null become `None`

```csharp
Option<int> some = Option.FromNullable((int?)100);
Option<int> none = Option.FromNullable((int?)null);
```

## Working with `Option<TValue>`

### Match

You cannot access the value of an `Option` type directly; instead, you work with them functionally. An `Option` only exposes one function with the following signature:

```csharp
public TResult Match(Func<TValue, TResult> onSome, Func<TResult> onNone)
```

If the `Option` has a value, then the delegate in the first parameter is invoked and it's result is returned. If the `Option` has no value, then the delegate in the second parameter is invoked instead.

```csharp
// Returns "Has value of 100"
string value = Option.Some(100).Match(v => $"Has value of {v}", () => "Has no value");

// Returns "Has no value"
string value = Option.None<int>().Match(v => $"Has value of {v}", () => "Has no value");
```

Working with `Match` can be tedious, but there are many extension methods that make using `Option` easy and very powerful.

### Map

If `Some`, this extension will return an `Option` with the value produced by the delegate parameter, and if `None` it will return `None`.

```csharp
// Returns Option<string> with a value of "100"
Option<string> option = Option.Some(100).Map(v => $"{v}");

// Returns Option<string> with no value
Option<string> option = Option.None<int>().Map(v => $"{v}");
```

### Bind

If `Some`, this extension will return the `Option` returned by the delegate parameter, and if `None` it will return `None`.

```csharp
// Returns Option<string> with a value of "100"
Option<string> option = Option.Some(100).Bind(v => Option.Some($"{v}"));

// Returns Option<string> with no value
Option<string> option = Option.Some(100).Bind(v => Option.None<string>());

// Returns Option<string> with no value
Option<string> option = Option.None<int>().Bind(v => Option.Some($"{v}"));
```

### HasValue

If `Some`, this extension will return `true`, and if `None` it will return `false`.

```csharp
// Returns true
bool value = Option.Some(100).HasValue();

// Returns false
bool value = Option.None<int>().HasValue();
```

### ValueOrDefault

If `Some`, this extension will return the value, and if `None` it will return a specified default.

```csharp
// Returns 100
int value = Option.Some(100).ValueOrDefault(50);

// Returns 50
int value = Option.None<int>().ValueOrDefault(50);
```

A function overload accepting a factory method also exists.  If `Some`, this extension will return the value.  If `None`, the delegate will be invoked to produce the specified value.

```csharp
// Returns 100
int value = Option.Some(100).ValueOrDefault(() => 50);

// Returns 50
int value = Option.None<int>().ValueOrDefault(() => 50);
```

### BindOnNone

If `Some`, this extension will return the original `Option`.  If `None`, it will return the `Option` returned by the delegate parameter.

```csharp
// Returns Option<int> with a value of 100
Option<int> value = Option.Some(100).BindOnNone(() => Option.Some(50));

// Returns Option<int> with a value of 50
Option<int> value = Option.None<int>().BindOnNone(() => Option.Some(50));

// Returns Option<int> with no value
Option<int> value = Option.None<int>().BindOnNone(() => Option.None<int>());
```

### ToNullable

This extension only works on value types. If `Some`, this extension will return the value, and if `None` it will return null.

```csharp
// Returns 100
int? value = Option.Some<int>(100).ToNullable();

// Returns null
int? value = Option.None<int>().ToNullable();
```

### OfType

This extension only works on `Option<object>`. If `Some` and the value is of the specified type, then a typed `Option` is returned. Otherwise `None` is returned.

```csharp
// Returns Option<int> with a value of 100
Option<int> option = Option.Some<object>(100).OfType<int>();

// Returns Option<int> with no value
Option<int> option = Option.Some<object>("100").OfType<int>();

// Returns Option<int> with no value
Option<int> option = Option.None<object>().OfType<int>();
```

### Where

If `Some`, this extension will invoke the delegate parameter and if `true` is returned it will return `Some` of the input value. Otherwise `None` is returned.

```csharp
// Returns Option<int> with a value of 100
Option<int> option = Option.Some(100).Where(v => true);

// Returns Option<int> with no value
Option<int> option = Option.Some(100).Where(v => false);

// Returns Option<int> with no value
Option<int> option = Option.None<int>().Where(v => true);
```

### Do

This extension returns the input `Option` and is meant only to create side effects. If `Some`, this extension will invoke the first delegate parameter, and if `None` it will invoke the second delegate parameter (if provided).

```csharp
// Outputs "100" to the console and returns Option<int> with a value of 100
Option<int> option = Option.Some(100).Do(v => Console.WriteLine(v));

// Returns Option<int> with no value
Option<int> option = Option.None<int>().Do(v => Console.WriteLine(v));

// Outputs "None" to the console and returns Option<int> with no value
Option<int> option = Option.None<int>().Do(v => Console.WriteLine(v), () => Console.WriteLine("None"));
```

### DoOnNone

This extension returns the input `Option` and is meant only to create side effects. If `Some`, this extension will do nothing, and if `None` it will invoke the delegate parameter.

``` csharp
// Returns Option<int> with a value of 100
Option<int> option = Option.Some(100).DoOnNone(() => Console.WriteLine("NOTHING"));

// Outputs "NOTHING" to the console and returns Option<int> with no value
Option<int> option = Option.None<int>().DoOnNone(() => Console.WriteLine("NOTHING"));
```

### Apply

This extension returns void and is meant only to create side effects. If `Some`, this extension will invoke the first delegate parameter, and if `None` it will invoke the second delegate parameter (if provided).

```csharp
// Outputs "100" to the console
Option.Some(100).Apply(v => Console.WriteLine(v));

// Does nothing
Option.None<int>().Apply(v => Console.WriteLine(v));

// Outputs "None" to the console
Option.None<int>().Apply(v => Console.WriteLine(v), () => Console.WriteLine("None"));
```

### ThrowOnNone

If `Some`, this extension will return the `Option`'s value.  If `None`, an exception will be thrown.

```csharp
// Returns 1337
int value = Option.Some<int>(1337).ThrowOnNone(() => new InvalidOperationException("Expected value!"));

// Throws InvalidOperationException
Option.None<int>().ThrowOnNone(() => new InvalidOperationException("Expected value!"));
```

### ToResult

If `Some`, this extension will return a `Success` result with the value, and if `None` it will a `Failure` result contains the failure produced by the delegate parameter.

```csharp
// Returns Result<int, string> with a success value of 100
Result<int, string> result = Option.Some<int>(100).ToResult(() => "Failure Message");

// Returns Result<int, string> with a failure value of "Failure Message"
Result<int, string> result = Option.None<int>().ToResult(() => "Failure Message");
```

### ToEnumerable

If `Some`, this extension method will return an `IEnumerable<T>` containing a single item: the value. If `None`, it will return an empty `IEnumerable<T>`.  This extension method can be useful in cases where you have developed a function that accepts a collection of items (accepting `IEnumerable<T>`) and wish to reuse that function for processing a single item.

``` csharp
// Returns an enumerable collection with one element: { 100 }
Enumerable<int> result = Option.Some<int>(100).ToEnumerable();

// Returns an empty enumerable collection: { }
Enumerable<int> result = Option.None<int>().ToEnumerable();
```

### ToArray

If `Some`, this extension method will return an array of `T` containing a single element: the value. If `None`, it will return an empty array.  This extension method can be useful in cases where you have developed a function that accepts a collection of items (accepting `IReadOnlyCollection<T>`) and wish to reuse that function for processing a single item.

``` csharp
// Returns the array with one element: { 100 }
int[] result = Option.Some<int>(100).ToArray()

// Returns the empty array: { }
int[] result = Option.None<int>().ToArray()
```
