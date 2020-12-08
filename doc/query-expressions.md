# Query Expressions

Chaining and nested extensions on `Result<TSuccess, TFailure>` or `Option<TValue>` types can quickly become difficult to read. In these scenarios, the query expression syntax can dramatically improve code readability.

## Query Expressions for `Result<TSuccess, TFailure>`

For the following code snippets, assume the following methods are declared.

```csharp
public Result<Value, Error> LoadValue(int id);
public Result<MappedValue, Error> MapValue(Value value);
public Result<AdditionalData, Error> LoadAdditionalData(Value value);
public Result<CombinedData, Error> Combine(MappedValue mappedValue, AdditionalData additionalData);
```

Here is a basic example of a `Bind` and then a `Map` written in the standard functional syntax.

```csharp
public Result<(int Id, MappedValue Value), Error> LoadAndMapValue(int id)
    => LoadValue(id)
        .Bind(value => MapValue(value))
        .Map(mappedValue => (id, mappedValue));
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
        .Map(combinedData => (id, combinedData));
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

## Query Expressions for `Option<TValue>`

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
