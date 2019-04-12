using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class OptionTestExtensions
	{
		public static TSome AssertSome<TSome>(this Option<TSome> option)
			=> option.Match(s => s, () => throw new Exception("Option should be some."));

		public static async Task<TSome> AssertSome<TSome>(this Task<Option<TSome>> option)
		   => (await option).Match(s => s, () => throw new Exception("Option should be some."));

		public static void AssertNone<TSome>(this Option<TSome> option)
		   => option.Match(s => throw new Exception("Option should be none."), () => 0);

		public static async Task AssertNone<TSome>(this Task<Option<TSome>> option)
		   => (await option).Match(s => throw new Exception("Option should be none."), () => 0);
	}
}
