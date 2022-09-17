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
            public class ForAgedBrie
            {
                private const string ItemName = "Aged Brie";

                [TestFixture]
                public class ShouldDecreaseSellIn : TestBase
                {
                    [TestCase(6, 5, new[] { 4, 2, 0, -2, -4 })]
                    [TestCase(5, 5, new[] { 3, 1, -1, -3, -5 })]
                    public void ByTwoEveryDay(int sellIn, int quality, int[] expectedSellIns)
                    {
                        ExecuteSellInScenario(hotPolicy, ItemName, sellIn, quality, expectedSellIns);
                    }
                }

                [TestFixture]
                public class ShouldIncreaseQuality
                {
                    [TestFixture]
                    public class ByTwoEveryDay : TestBase
                    {
                        [TestCase(new[] { 10, 8, 6, 4, 2, 0 }, new[] { 10, 12, 14, 16, 18, 20 })]
                        public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }

                    [TestFixture]
                    public class ByTwiceEveryDay : TestBase
                    {
                        [TestCase(new[] { 0, -2, -4, -6, -8, -10 }, new[] { 10, 14, 18, 22, 26, 30 })]
                        [TestCase(new[] { 1, -1, -3, -5, -7, -9 }, new[] { 10, 14, 18, 22, 26, 30 })]
                        public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }
                }

                [TestFixture]
                public class ShouldNotUpdateQuality
                {
                    [TestFixture]
                    public class Over50 : TestBase
                    {
                        [TestCase(new[] { 6, 4, 2, 0 }, new[] { 50, 50, 50, 50 })]
                        public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }

                        [TestCase(new[] { 0, -2, -4, -6 }, new[] { 49, 50, 50, 50 })]
                        [TestCase(new[] { 0, -2, -4, -6 }, new[] { 50, 50, 50, 50 })]
                        public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }
                }
            }
        }
    }
}
