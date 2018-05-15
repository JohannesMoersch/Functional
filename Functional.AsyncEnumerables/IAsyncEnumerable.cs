using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    public interface IAsyncEnumerable<T>
    {
		IAsyncEnumerator<T> GetEnumerator();
    }
}
