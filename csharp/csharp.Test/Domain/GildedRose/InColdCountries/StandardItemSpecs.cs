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
            public class StandardItemsSpecs : TestBase
            {
                private const string ItemName = "Eloxur";

                [TestFixture]
                public class ShouldDecreaseSellIn : TestBase
                {
                    [TestFixture]
                    public class ByOne : TestBase
                    {
                        [TestCase(4, 5, new[] { 3, 2, 1, 0, -1, -2 })]
                        public void EveryDay(int sellIn, int quality, int[] expectedSellIns)
                        {
                            ExecuteSellInScenario(coldPolicy, ItemName, sellIn, quality, expectedSellIns);
                        }
                    }
                }

                [TestFixture]
                public class ShouldDecreaseQuality
                {
                    [TestFixture]
                    public class ByOne : TestBase
                    {
                        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 10, 9, 8, 7, 6, 5 })]
                        public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(coldPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }

                    [TestFixture]
                    public class ByTwice : TestBase
                    {
                        [TestCase(new[] { 0, -1, -2, -3, -4, -5 }, new[] { 10, 8, 6, 4, 2, 0 })]
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
                    public class BellowZero : TestBase
                    {
                        [TestCase(new[] { 3, 2, 1, 0 }, new[] { 0, 0, 0, 0 })]
                        public void WhenTheSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(coldPolicy, ItemName, expectedSellIns, expectedQualities);
                        }

                        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 0, 0, 0, 0 })]
                        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 1, 0, 0, 0 })]
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
