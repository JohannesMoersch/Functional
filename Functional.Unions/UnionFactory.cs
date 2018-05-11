using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IUnionFactory<out TUnionDefintion> { }

	internal class UnionFactory<TUnionDefinition> : IUnionFactory<TUnionDefinition>
		where TUnionDefinition : IUnionDefinition
	{
		internal static IUnionFactory<TUnionDefinition> Instance { get; } = new UnionFactory<TUnionDefinition>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo> { }

	internal class UnionFactory<TOne, TTwo> : IUnionFactory<TOne, TTwo>
	{
		internal static IUnionFactory<TOne, TTwo> Instance { get; } = new UnionFactory<TOne, TTwo>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo, TThree> { }

	internal class UnionFactory<TOne, TTwo, TThree> : IUnionFactory<TOne, TTwo, TThree>
	{
		internal static IUnionFactory<TOne, TTwo, TThree> Instance { get; } = new UnionFactory<TOne, TTwo, TThree>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo, TThree, TFour> { }

	internal class UnionFactory<TOne, TTwo, TThree, TFour> : IUnionFactory<TOne, TTwo, TThree, TFour>
	{
		internal static IUnionFactory<TOne, TTwo, TThree, TFour> Instance { get; } = new UnionFactory<TOne, TTwo, TThree, TFour>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo, TThree, TFour, TFive> { }

	internal class UnionFactory<TOne, TTwo, TThree, TFour, TFive> : IUnionFactory<TOne, TTwo, TThree, TFour, TFive>
	{
		internal static IUnionFactory<TOne, TTwo, TThree, TFour, TFive> Instance { get; } = new UnionFactory<TOne, TTwo, TThree, TFour, TFive>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> { }

	internal class UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix>
	{
		internal static IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> Instance { get; } = new UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> { }

	internal class UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
		internal static IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Instance { get; } = new UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>();

		private UnionFactory() { }
	}

	public interface IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> { }

	internal class UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
		internal static IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Instance { get; } = new UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>();

		private UnionFactory() { }
	}
}
