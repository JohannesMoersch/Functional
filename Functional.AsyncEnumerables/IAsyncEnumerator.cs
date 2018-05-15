using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public interface IAsyncEnumerator<out T>
    {
		Task<bool> MoveNext();

		T Current { get; }
    }
}
