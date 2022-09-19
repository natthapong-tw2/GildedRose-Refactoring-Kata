using FluentAssertions;
using IsolatedTests.GildedRose.Domain.BusinessModels;
using IsolatedTests.GildedRose.Domain.Services.Updaters;
using NUnit.Framework;

namespace IsolatedTests.GildedRoseTests.Updaters
{
    [TestFixture]
    public class AgedBrieTests : UpdaterTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            testable = new AgedBrieUpdater();
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

        [TestCase("Aged Brie", true)]
        [TestCase("aged Brie", false)]
        [TestCase("Aged brie", false)]
        [TestCase("Aged briE", false)]
        [TestCase("AgedBrie", false)]
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