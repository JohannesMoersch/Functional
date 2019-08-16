using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	internal static class Helpers
	{
		public static bool TryGetValue<TValue>(this Option<TValue> option, out TValue some)
		{
			some = option.Match(_ => _, () => default);

			return option.Match(_ => true, () => false);
		}

		public static bool TryGetValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, out TSuccess success, out TFailure failure)
		{
			success = result.Match(_ => _, _ => default);

			failure = result.Match(_ => default, _ => _);

			return result.Match(_ => true, _ => false);
		}
	}
}
