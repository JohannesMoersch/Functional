namespace Functional.Tests;

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
public static partial class TestInputExtensions
{
	private static Task<Option<T>> ConvertToTask<T>(T source)
		=> Task.FromResult(source != null ? Option.Some(source) : Option.None());

	private static async Task<Option<T>> ConvertToTask<T>(Task<T> source)
		=> await source is T value ? value : Option.None();
}
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
