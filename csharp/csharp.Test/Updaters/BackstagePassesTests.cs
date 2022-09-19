using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Services;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public class BackstagePassesTests : UpdaterTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            testable = new BackstagePassesUpdater();
        }
        
        [TestCase(new[] { 3, 2, 1, 0, -1, -2 })]
        public void ShouldDecreaseSellInByOneEveryDay(int[] expectedSellIns)
        {
            ExecuteSellInScenario(expectedSellIns);
        }
        
        [TestCase(new[] { 14, 13, 12, 11, 10 }, new[] { 10, 11, 12, 13, 14 })]
        public void ShouldIncreaseQualityBeOne_WhenSellByDateIsMoreThanTen(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 10, 12, 14, 16, 18, 20 })]
        public void ShouldIncreaseQualityByTwo_WhenSellByDateIsLessThanTenButMoreThanFive(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 10, 13, 16, 19, 22, 25 })]
        public void ShouldIncreaseQualityByThree_WhenSellByDateIsLessThanFive(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 14, 13, 12, 11, 10 }, new[] { 50, 50, 50, 50, 50 })]
        public void ShouldNotIncreaseQualityOverFifty_WhenSellByDateIsMoreThanTen(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 10, 9, 8, 7, 6, 5 } , new[] { 49, 50, 50, 50, 50, 50 })]
        [TestCase(new[] { 10, 9, 8, 7, 6, 5 } , new[] { 50, 50, 50, 50, 50, 50 })]
        public void ShouldNotIncreaseQualityOverFifty_WhenSellByDateIsLessThanTenButMoreThanFive(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 48, 50, 50, 50, 50, 50 })]
        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 49, 50, 50, 50, 50, 50 })]
        [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 50, 50, 50, 50, 50, 50 })]
        public void ShouldNotIncreaseQualityOverFifty_WhenSellByDateIsLessThanFive(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }
        
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 30, 0, 0, 0 })]
        [TestCase(new[] { 0, -1, -2, -3 }, new[] { 50, 0, 0, 0 })]
        public void ShouldDropQualityToZero_WhenSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", true)]
        [TestCase("Backstage passes to a takfal80ETC concert", false)]
        [TestCase("Backstage passes to a TAFKAL80etc concert", false)]
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