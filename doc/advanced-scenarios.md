# Advanced Scenarios

## Aggregation of `Result<TSuccess, TFailure>`

It is possible to cache a collection of `Result`-producing functions and use [LINQ's `Aggregate` method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=net-5.0#System_Linq_Enumerable_Aggregate__2_System_Collections_Generic_IEnumerable___0____1_System_Func___1___0___1__) to produce a single result.

```csharp
public abstract class OutputModel { /* DATA */ }
public sealed class OutputModelType1 : OutputModel { /* DATA */ }
public sealed class OutputModelType2 : OutputModel { /* DATA */ }
public sealed class OutputModelType3 : OutputModel { /* DATA */ }

// the potential return values of each function are...
// - Option.Some<OutputModel> if the InputModel could be mapped to the specified OutputModel
// - Option.None<OutputModel> if the InputModel is being discarded
// - an Error discriminated union indicating "unknown output model" (holding the InputModel) or "an exception occurred" (holding the exception)
private static readonly Func<InputModel, Result<Option<OutputModel>, Error>> _funcCollection =
{
    (inputModel) => inputModel.ToOutputModelType1(),
    (inputModel) => inputModel.ToOutputModelType2(),
    (inputModel) => inputModel.ToOutputModelType3()
};

// use LINQ's Aggregate method to execute each function in the collection
// begin with a Result<Option<OutputModel>, Error> holding "unknown input model" error
// functions from the collection are executed until any of the following occurs:
// - a function returns a success Result holding Option.Some<OutputModel>; ToOutputModel returns that success Result
// - a function returns a success Result holding Option.None<OutputModel>; ToOutputModel returns that success Result
// - a function returns a failure Result holding Error.Exception; ToOutputModel returns that failure Result
//
// if a function returns a failure Result holding Error.UnknownInputModel, then processing continues
// if all functions produce a failure Result holding Error.UnknownInputModel, then ToOutputModel returns a failure Result holding Error.UnknownInputModel
public static Result<Option<OutputModel>, Error> ToOutputModel(this InputModel source)
{
    return _funcCollection.Aggregate(
        Result.Failure<Option<OutputModel>, Error>(Error.DueToUnknownInputModel(source)),
        (current, func) => current.BindOnFailure(error => error.Match(
            unknown => func.Invoke(unknown.InputModel),
            exception => exception.ToPassthrough())));
    )
}
```
