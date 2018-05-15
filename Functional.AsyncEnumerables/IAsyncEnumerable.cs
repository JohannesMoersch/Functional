using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    public interface IAsyncEnumerable<out T>
    {
		IAsyncEnumerator<T> GetEnumerator();
    }
}
