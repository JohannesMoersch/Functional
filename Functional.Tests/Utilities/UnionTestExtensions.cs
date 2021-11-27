using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class UnionTestExtensions
	{
		public static TOne AssertOne<TOne, TTwo>(this Union<TOne, TTwo> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo>(this Union<TOne, TTwo> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _);

		public static TOne AssertOne<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _, _ => throw new Exception("Union should be two."));

		public static TThree AssertThree<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			=> union.Value().Match(_ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => _);

		public static TOne AssertOne<TOne, TTwo, TThree, TFour>(this Union<TOne, TTwo, TThree, TFour> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo, TThree, TFour>(this Union<TOne, TTwo, TThree, TFour> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _, _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."));

		public static TThree AssertThree<TOne, TTwo, TThree, TFour>(this Union<TOne, TTwo, TThree, TFour> union)
			=> union.Value().Match(_ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => _, _ => throw new Exception("Union should be three."));

		public static TFour AssertFour<TOne, TTwo, TThree, TFour>(this Union<TOne, TTwo, TThree, TFour> union)
			=> union.Value().Match(_ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => _);

		public static TOne AssertOne<TOne, TTwo, TThree, TFour, TFive>(this Union<TOne, TTwo, TThree, TFour, TFive> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo, TThree, TFour, TFive>(this Union<TOne, TTwo, TThree, TFour, TFive> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _, _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."));

		public static TThree AssertThree<TOne, TTwo, TThree, TFour, TFive>(this Union<TOne, TTwo, TThree, TFour, TFive> union)
			=> union.Value().Match(_ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => _, _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."));

		public static TFour AssertFour<TOne, TTwo, TThree, TFour, TFive>(this Union<TOne, TTwo, TThree, TFour, TFive> union)
			=> union.Value().Match(_ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => _, _ => throw new Exception("Union should be four."));

		public static TFive AssertFive<TOne, TTwo, TThree, TFour, TFive>(this Union<TOne, TTwo, TThree, TFour, TFive> union)
			=> union.Value().Match(_ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => _);

		public static TOne AssertOne<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _, _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."));

		public static TThree AssertThree<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			=> union.Value().Match(_ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => _, _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."));

		public static TFour AssertFour<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			=> union.Value().Match(_ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => _, _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."));

		public static TFive AssertFive<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			=> union.Value().Match(_ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => _, _ => throw new Exception("Union should be five."));

		public static TSix AssertSix<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			=> union.Value().Match(_ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => _);

		public static TOne AssertOne<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _, _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."));

		public static TThree AssertThree<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => _, _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."));

		public static TFour AssertFour<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => _, _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."));

		public static TFive AssertFive<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => _, _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."));

		public static TSix AssertSix<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => _, _ => throw new Exception("Union should be six."));

		public static TSeven AssertSeven<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			=> union.Value().Match(_ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => _);

		public static TOne AssertOne<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => _, _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."), _ => throw new Exception("Union should be one."));

		public static TTwo AssertTwo<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be two."), _ => _, _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."), _ => throw new Exception("Union should be two."));

		public static TThree AssertThree<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => _, _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."), _ => throw new Exception("Union should be three."));

		public static TFour AssertFour<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => _, _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."), _ => throw new Exception("Union should be four."));

		public static TFive AssertFive<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => _, _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."), _ => throw new Exception("Union should be five."));

		public static TSix AssertSix<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."), _ => _, _ => throw new Exception("Union should be six."), _ => throw new Exception("Union should be six."));

		public static TSeven AssertSeven<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => throw new Exception("Union should be seven."), _ => _, _ => throw new Exception("Union should be seven."));

		public static TEight AssertEight<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value().Match(_ => throw new Exception("Union should be eight."), _ => throw new Exception("Union should be eight."), _ => throw new Exception("Union should be eight."), _ => throw new Exception("Union should be eight."), _ => throw new Exception("Union should be eight."), _ => throw new Exception("Union should be eight."), _ => throw new Exception("Union should be eight."), _ => _);
	}
}
