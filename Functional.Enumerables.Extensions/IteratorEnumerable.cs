using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class IteratorEnumerable<T> : IEnumerable<T>
	{
		private readonly Func<IEnumerator<T>> _iteratorFactory;

		public IteratorEnumerable(Func<IEnumerator<T>> iteratorFactory)
			=> _iteratorFactory = iteratorFactory;

		public IEnumerator<T> GetEnumerator()
			=> _iteratorFactory.Invoke();

		IEnumerator IEnumerable.GetEnumerator()
			=> _iteratorFactory.Invoke();
	}

	internal static class IteratorEnumerable
	{
		public static IEnumerable<T> Create<T>(Func<IEnumerator<T>> enumeratorFactory)
			=> new IteratorEnumerable<T>(enumeratorFactory);
	}
}
