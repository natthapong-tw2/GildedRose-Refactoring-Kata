using FluentAssertions;
using IsolatedTests.GildedRose.Domain.BusinessModels;
using IsolatedTests.GildedRose.Domain.Services.Updaters;
using NUnit.Framework;

namespace IsolatedTests.GildedRoseTests.Updaters
{
    [TestFixture]
    public class StandardUpdaterTests : UpdaterTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            testable = new StandardItemUpdater();
        }
        
        [TestCase(new[] { 3, 2, 1, 0, -1, -2 })]
        public void ShouldDecreaseSellInByOneEveryDay(int[] expectedSellIns)
        {
            ExecuteSellInScenario(expectedSellIns);
        }
        
        [TestCase(new[] { 4, 3, 2, 1, 0 }, new[] { 10, 9, 8, 7, 6 })]
        public void ShouldDecreaseQualityBeOne_WhenSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 10, 8, 6, 4 })]
        public void ShouldDecreaseQualityTwice_WhenSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 5, 4, 3, 2 }, new[] { 0, 0, 0, 0 })]
        public void ShouldNotDecreaseQualityBellowZero_WhenSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 1, 0, 0, 0 })]
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 0, 0, 0, 0 })]
        public void ShouldNotDecreaseQualityBellowZero_WhenSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }

        [TestCase("Not aged brie", true)]
        [TestCase("Not backstage", true)]
        [TestCase("Not sulfuras", true)]
        [TestCase("Aged Brie", true)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", true)]
        [TestCase("Sulfuras, Hand of Ragnaros", true)]
        public void ShouldBeSatisfiedIfTheNameMatches(string itemName, bool isExpectedToSatisfy)
        {
            var item = new Item
            {
                Name = itemName
            };

            testable.IsSatisfiedBy(item).Should().Be(isExpectedToSatisfy);
        }

        [Test]
        public void ShouldNotBeSatisfiedIfNull()
        {
            testable.IsSatisfiedBy(null).Should().BeFalse();
        }
    }
}