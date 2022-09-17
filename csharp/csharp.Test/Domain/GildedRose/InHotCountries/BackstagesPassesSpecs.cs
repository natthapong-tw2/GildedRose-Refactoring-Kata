using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public partial class GildedRoseSpecs
    {
        [TestFixture]
        public partial class InHotCountries
        {
            [TestFixture]
            public class ForBackstagePasses
            {
                private const string ItemName = "Backstage passes to a TAFKAL80ETC concert";

                [TestFixture]
                public class ShouldDecreaseSellIn : TestBase
                {
                    [TestCase(4, 5, new[] { 3, 2, 1, 0, -1, -2 })]
                    public void ByOneEveryDay(int sellIn, int quality, int[] expectedSellIns)
                    {
                        ExecuteSellInScenario(hotPolicy, ItemName, sellIn, quality, expectedSellIns);
                    }
                }

                [TestFixture]
                public class ShouldIncreaseQuality
                {
                    [TestFixture]
                    public class ByTwo : TestBase
                    {
                        [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 10, 11, 12, 13, 14, 15 })]
                        public void WhenTheConcertIsInLessThanTenDaysButMoreThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }

                    [TestFixture]
                    public class ByThree : TestBase
                    {
                        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 10, 12, 14, 16, 18, 20 })]
                        public void WhenTheConcertIsInLessThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }
                }

                [TestFixture]
                public class ShouldDropQualityOfBackstagePassesToZero : TestBase
                {
                    [TestCase(new[] { 1, 0, -1, -2 }, new[] { 40, 42, 0, 0 })]
                    public void WhenTheConcertIsOver(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                    }
                }

                [TestFixture]
                public class ShouldNotUpdateQuality
                {
                    [TestFixture]
                    public class OverFifty : TestBase
                    {
                        [TestCase(new[] { 13, 12, 11, 10 }, new[] { 50, 50, 50, 50 })]
                        public void WhenTheConcertIsMoreThanTenDays(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }

                        [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 49, 50, 50, 50, 50, 50 })]
                        [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 50, 50, 50, 50, 50, 50 })]
                        public void WhenTheConcertIsInLessThanTenDaysButMoreThanFiveDays(int[] expectedSellIns,
                            int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }

                        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 48, 50, 50, 50, 50, 50 })]
                        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 49, 50, 50, 50, 50, 50 })]
                        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 50, 50, 50, 50, 50, 50 })]
                        public void WhenTheConcertIsInLessThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }

                    [TestFixture]
                    public class BellowZero : TestBase
                    {
                        [TestCase(new[] { 0, -1, -2, -3, -4 }, new[] { 30, 0, 0, 0, 0 })]
                        public void AfterTheConcert(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }
                }
            }
        }
    }
}
