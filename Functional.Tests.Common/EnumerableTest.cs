using System;

namespace Functional.Tests;

public static partial class EnumerableTest
{
	private static Option<MethodInfo> GetMethodFromMethodGroup(MethodInfo method, params Type[] parameterTypes)
	{
		return (method.DeclaringType ?? throw new Exception("Failed to get class that contained method."))
			.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Where(m => m.Name == method.Name && m.IsGenericMethod == method.IsGenericMethod)
			.Where(m => !m.IsGenericMethod || m.GetGenericArguments().Length == method.GetGenericArguments().Length)
			.Select(m => m.IsGenericMethod ? m.MakeGenericMethod(method.GetGenericArguments()) : m)
			.Where(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes))
			.TryFirst();
	}

	private static Type GetTypeFromEnumerableType<T>(EnumerableType enumerableType)
		=> enumerableType switch
		{
			EnumerableType.IEnumerable => typeof(IEnumerable<T>),
			EnumerableType.TaskOfIEnumerable => typeof(Task<IEnumerable<T>>),
			EnumerableType.TaskOfIOrderedEnumerable => typeof(Task<IOrderedEnumerable<T>>),
			EnumerableType.IAsyncEnumerable => typeof(IAsyncEnumerable<T>),
			_ => throw new Exception($"Unexpected {nameof(EnumerableType)} found.")
		};

	private static void ShouldMatchTypeAndMessage(this Exception exception, Exception expected)
	{
		if (exception.GetType() != expected.GetType() || exception.Message != expected.Message)
			throw new Exception($"Expected {expected.ToFormattedString()} but found {exception.ToFormattedString()}.");
	}
	private static string ToFormattedString<T>(this IEnumerable<T> value)
		=> $"({String.Join(", ", value.Select(i => i?.ToString() ?? "null"))})";

	private static string ToFormattedString(this Exception value)
		=> $"{value.GetType().Name} with message \"{value.Message}\"";

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
	private static async Task<TestResult<TResult>> ToTestResult<TResult>(this Task<Result<Option<TResult>, Exception>> result)
		=> new TestResult<TResult>(await result);

	private static async Task<NullTestResult<TResult>> ToNullTestResult<TResult>(this Task<Result<Option<TResult>, Exception>> result, bool[] isNull)
		=> new NullTestResult<TResult>(await result, isNull);
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
}