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
            public class ForSulfuras : TestBase
            {
                private const string ItemName = "Sulfuras, Hand of Ragnaros";

                [TestCase(5, 5, new[] { 5, 5, 5, 5, 5 })]
                public void ShouldNeverUpdateSellIn(int sellIn, int quality, int[] expectedSellIns)
                {
                    ExecuteSellInScenario(hotPolicy, ItemName, sellIn, quality, expectedSellIns);
                }

                [TestCase(5, 5, new[] { 5, 5, 5 })]
                [TestCase(5, 80, new[] { 80, 80, 80 })]
                public void ShouldNeverUpdateQuality(int sellIn, int quality, int[] expectedQualities)
                {
                    ExecuteQualityScenario(hotPolicy, ItemName, sellIn, quality, expectedQualities);
                }
            }
        }
    }
}
