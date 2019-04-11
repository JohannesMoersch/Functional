using System;
using System.Threading.Tasks;

namespace Functional
{
	public interface IAsyncEnumerator<out T> : IDisposable
	{
		Task<bool> MoveNext();

		T Current { get; }
	}
}
