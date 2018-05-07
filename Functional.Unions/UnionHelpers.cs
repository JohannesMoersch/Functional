using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    internal static class UnionHelpers
    {
		public static T CheckForNull<T>(T value, string argumentName)
		{
			if (value == null)
				throw new ArgumentNullException(argumentName);

			return value;
		}
	}
}
