using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public partial class GildedRoseSpecs
    {
        [TestFixture]
        public partial class InColdCountries
        {
            [TestFixture]
            public class ForAgedBrie
            {
                private const string ItemName = "Aged Brie";

                [TestFixture]
                public class ShouldDecreaseSellIn : TestBase
                {
                    [TestCase(4, 5, new[] { 3, 2, 1, 0, -1, -2 })]
                    public void ByOneEveryDay(int sellIn, int quality, int[] expectedSellIns)
                    {
                        ExecuteSellInScenario(coldPolicy, ItemName, sellIn, quality, expectedSellIns);
                    }
                }

                [TestFixture]
                public class ShouldIncreaseQuality
                {
                    [TestFixture]
                    public class ByOneEveryDay : TestBase
                    {
                        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 10, 11, 12, 13, 14, 15 })]
                        public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(coldPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }

                    [TestFixture]
                    public class ByTwiceEveryDay : TestBase
                    {
                        [TestCase(new[] { 0, -1, -2, -3, -4, -5 }, new[] { 10, 12, 14, 16, 18, 20 })]
                        public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(coldPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }
                }

                [TestFixture]
                public class ShouldNotUpdateQuality
                {
                    [TestFixture]
                    public class Over50 : TestBase
                    {
                        [TestCase(new[] { 3, 2, 1, 0 }, new[] { 50, 50, 50, 50 })]
                        public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(coldPolicy, ItemName, expectedSellIns, expectedQualities);
                        }

                        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 49, 50, 50, 50 })]
                        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 50, 50, 50, 50 })]
                        public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(coldPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }
                }
            }
        }
    }
}
