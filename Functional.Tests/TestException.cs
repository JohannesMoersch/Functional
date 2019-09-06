using System;
using System.Collections.Generic;
using System.Text;

namespace Functional.Tests
{
    public class TestException : Exception
    {
		public TestException() { }

		public TestException(string message) : base(message) { }
    }
}
