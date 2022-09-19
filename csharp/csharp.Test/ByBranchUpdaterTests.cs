using System.Linq;
using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Services;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public class ByBranchUpdaterTests
    {
        private ByBranchUpdater testable;

        [SetUp]
        public void SetUp()
        {
            testable = new ByBranchUpdater();
        }
        
        [TestCase(new[] { 3, 2, 1, 0, -1, -2 })]
        public void ShouldDecreaseSellInByOneEveryDay(int[] expectedSellIns)
        {
            ExecuteSellInScenario(expectedSellIns);
        }
        
        [TestCase(new[] { 4, 3, 2, 1, 0 }, new[] { 10, 11, 12, 13, 14 })]
        public void ShouldIncreaseQualityBeOne_WhenSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 10, 12, 14, 16 })]
        public void ShouldIncreaseQualityTwice_WhenSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 5, 4, 3, 2 }, new[] { 50, 50, 50, 50 })]
        public void ShouldNotIncreaseQualityOverFifty_WhenSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 49, 50, 50, 50 })]
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 50, 50, 50, 50 })]
        public void ShouldNotIncreaseQualityOverFifty_WhenSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }

        private void ExecuteSellInScenario(int[] expectedSellIns)
        {
            // Be aware that we didn't had to setup the name as the selection is not done here
            var agedBrie = new AgedBrie { SellIn = expectedSellIns.First(), Quality = new Quality(20) };

            foreach (var expectedSellIn in expectedSellIns.Skip(1))
            {
                testable.UpdateQuality(agedBrie);
                agedBrie.SellIn.Should().Be(expectedSellIn);
            }
        }

        private void ExecuteScenario(int[] expectedSellIns, int[] expectedQuality)
        {
            expectedQuality.Should().HaveCount(expectedSellIns.Length, "Expected sell in and qualities are expected to have the same length but were not");
            
            var agedBrie = new AgedBrie { SellIn = expectedSellIns.First(), Quality = new Quality(expectedQuality.First()) };

            for (var day = 1; day < expectedQuality.Length; ++day)
            {
                testable.UpdateQuality(agedBrie);
                agedBrie.SellIn.Should().Be(expectedSellIns[day]);
                agedBrie.Quality.Should().Be(new Quality(expectedQuality[day]));
            }
        }
    }
}