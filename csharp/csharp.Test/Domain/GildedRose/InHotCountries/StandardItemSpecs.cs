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
            public class StandardItemsSpecs : TestBase
            {
                private const string ItemName = "Eloxur";

                [TestFixture]
                public class ShouldDecreaseSellIn : TestBase
                {
                    [TestFixture]
                    public class ByTwo : TestBase
                    {
                        [TestCase(6, 5, new[] { 4, 2, 0, -2, -4 })]
                        [TestCase(7, 5, new[] { 5, 3, 1, -1, -3 })]
                        public void EveryDay(int sellIn, int quality, int[] expectedSellIns)
                        {
                            ExecuteSellInScenario(hotPolicy, ItemName, sellIn, quality, expectedSellIns);
                        }
                    }
                }

                [TestFixture]
                public class ShouldDecreaseQuality
                {
                    [TestFixture]
                    public class ByTwo : TestBase
                    {
                        [TestCase(new[] { 10, 8, 6, 4, 2, 0 }, new[] { 10, 8, 6, 4, 2, 0 })]
                        public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }
                    }

                    [TestFixture]
                    public class ByTwice : TestBase
                    {
                        [TestCase(new[] { 0, -2, -4, -6, -8, -10 }, new[] { 20, 16, 12, 8, 4, 0 })]
                        [TestCase(new[] { 1, -1, -3, -5, -7, -9 }, new[] { 20, 16, 12, 8, 4, 0 })]
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
                    public class BellowZero : TestBase
                    {
                        [TestCase(new[] { 6, 4, 2, 0 }, new[] { 0, 0, 0, 0 })]
                        [TestCase(new[] { 7, 5, 3, 1 }, new[] { 0, 0, 0, 0 })]
                        public void WhenTheSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
                        {
                            ExecuteScenario(hotPolicy, ItemName, expectedSellIns, expectedQualities);
                        }

                        [TestCase(new[] { 0, -2, -4, -6 }, new[] { 0, 0, 0, 0 })]
                        [TestCase(new[] { 0, -2, -4, -6 }, new[] { 1, 0, 0, 0 })]
                        [TestCase(new[] { 1, -1, -3, -5 }, new[] { 0, 0, 0, 0 })]
                        [TestCase(new[] { 1, -1, -3, -5 }, new[] { 1, 0, 0, 0 })]
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
