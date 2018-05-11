using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public class AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionDefinitionBase<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
	}
}
