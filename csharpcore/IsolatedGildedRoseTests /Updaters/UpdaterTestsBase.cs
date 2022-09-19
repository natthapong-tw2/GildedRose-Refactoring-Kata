using System.Linq;
using FluentAssertions;
using IsolatedTests.GildedRose.Domain.BusinessModels;
using IsolatedTests.GildedRose.Domain.Services.Updaters;

namespace IsolatedTests.GildedRoseTests.Updaters
{
    public class UpdaterTestsBase
    {
        protected IITemUpdater testable;

        protected void ExecuteSellInScenario(int[] expectedSellIns)
        {
            // Be aware that we didn't had to setup the name as the selection is not done here
            var item = new Item { SellIn = expectedSellIns.First(), Quality = new Quality(20) };

            foreach (var expectedSellIn in expectedSellIns.Skip(1))
            {
                testable.UpdateQuality(item);
                item.SellIn.Should().Be(expectedSellIn);
            }
        }
        
        protected void ExecuteScenario(int[] expectedSellIns, int[] expectedQuality)
        {
            expectedQuality.Should().HaveCount(expectedSellIns.Length, "Expected sell in and qualities are expected to have the same length but were not");
            
            var item = new Item { SellIn = expectedSellIns.First(), Quality = new Quality(expectedQuality.First()) };

            for (var day = 1; day < expectedQuality.Length; ++day)
            {
                testable.UpdateQuality(item);
                item.SellIn.Should().Be(expectedSellIns[day]);
                item.Quality.Should().Be(new Quality(expectedQuality[day]));
            }
        }
    }
}