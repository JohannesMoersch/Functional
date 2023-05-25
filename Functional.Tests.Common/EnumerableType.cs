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