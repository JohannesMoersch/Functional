namespace Functional.Tests;

public static partial class TestInputExtensions
{
	private static Option<MethodInfo> GetMethodFromMethodGroup(MethodInfo method, params Type[] parameterTypes)
		=> (method.DeclaringType ?? throw new Exception("Failed to get class that contained method."))
			.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Where(m => m.Name == method.Name && m.IsGenericMethod == method.IsGenericMethod)
			.Where(m => !m.IsGenericMethod || m.GetGenericArguments().Length == method.GetGenericArguments().Length)
			.Select(m => m.IsGenericMethod ? m.MakeGenericMethod(method.GetGenericArguments()) : m)
			.Where(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes))
			.TryFirst();

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
			AssertionException.Throw(expected.ToFormattedString(), exception.ToFormattedString());
	}
}
