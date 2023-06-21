namespace Functional.Tests;

[Flags]
public enum EnumerableType
{
	IEnumerable = 1,
	TaskOfIEnumerable = 2,
	TaskOfIOrderedEnumerable = 4,
	IAsyncEnumerable = 8,
	AllTypes = IEnumerable | TaskOfIEnumerable | TaskOfIOrderedEnumerable | IAsyncEnumerable,
	AsyncTypes = TaskOfIEnumerable | TaskOfIOrderedEnumerable | IAsyncEnumerable,
	NonTaskVariants = IEnumerable | IAsyncEnumerable,
	TaskTypes = TaskOfIEnumerable | TaskOfIOrderedEnumerable
}

public static class EnumerableTypeExtensions
{
	public static Type GetTypeFromEnumerableType<T>(this EnumerableType enumerableType)
		=> enumerableType switch
		{
			EnumerableType.IEnumerable => typeof(IEnumerable<T>),
			EnumerableType.TaskOfIEnumerable => typeof(Task<IEnumerable<T>>),
			EnumerableType.TaskOfIOrderedEnumerable => typeof(Task<IOrderedEnumerable<T>>),
			EnumerableType.IAsyncEnumerable => typeof(IAsyncEnumerable<T>),
			_ => throw new Exception($"Unexpected {nameof(EnumerableType)} found.")
		};
}