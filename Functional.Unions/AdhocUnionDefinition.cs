using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public class AdhocUnionDefinition<TOne, TTwo> : UnionDefinitionBase<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>
	{
	}

	public class AdhocUnionDefinition<TOne, TTwo, TThree> : UnionDefinitionBase<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>
	{
	}

	public class AdhocUnionDefinition<TOne, TTwo, TThree, TFour> : UnionDefinitionBase<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>
	{
	}

	public class AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive> : UnionDefinitionBase<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>
	{
	}

	public class AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix> : UnionDefinitionBase<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>
	{
	}

	public class AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionDefinitionBase<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
	}

	public class AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionDefinitionBase<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
	}
}
