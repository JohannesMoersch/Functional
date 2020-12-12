# Collections

## Perform Side Effects Using `Apply` and `Do`

Instead of using a `foreach` loop, you can use `Apply` or `Do` to execute some `Action<T>` or `Action<T, int>` for each item in the collection.

The `Apply` extension method returns no value.

``` csharp
new { 1, 2, 3 }.Apply(i => Console.WriteLine(i));

// 1
// 2
// 3

new { "ITEM1", "ITEM2", "ITEM3" }.Apply((item, index) => Console.WriteLine($"[{index}] = {item}"));

// [0] = ITEM1
// [1] = ITEM2
// [2] = ITEM3
```

The `Do` extension method returns the original collection.  This method is useful when you want to perform additional processing on the collection after applying side effects.

``` csharp
// returns { 1, 2, 3 }
new { 1, 2, 3 }.Do(i => Console.WriteLine(i));

// 1
// 2
// 3

// returns { "ITEM1", "ITEM2", "ITEM3" }
new { "ITEM1", "ITEM2", "ITEM3" }.Do((item, index) => Console.WriteLine($"[{index}] = {item}"));

// [0] = ITEM1
// [1] = ITEM2
// [2] = ITEM3
```
