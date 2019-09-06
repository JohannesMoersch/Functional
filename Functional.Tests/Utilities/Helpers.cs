using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class Helpers
	{
		public static async Task<TValue> DelayedTask<TValue>(TValue value)
		{
			await Task.Delay(10);

			return value;
		}
	}
}
