using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Services;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public class SulfurasUpdaterTests : UpdaterTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            testable = new SulfurasUpdater();
        }
        
        [TestCase(new[] { 5, 5, 5 })]
        public void ShouldNeverUpdateSellIn(int[] expectedSellIns)
        {
            ExecuteSellInScenario(expectedSellIns);
        }
        
        [TestCase(new[] { 5, 5, 5 }, new[] { 5, 5, 5 })]
        [TestCase(new[] { 5, 5, 5 }, new[] { 80, 80, 80 })]
        public void ShouldNeverUpdateQuality(int[] expectedSellIns, int[] expectedQualities)
        {
            ExecuteScenario(expectedSellIns, expectedQualities);
        }

        [TestCase("Sulfuras, Hand of Ragnaros", true)]
        [TestCase("Sulfuras Hand of Ragnaros", false)]
        [TestCase("Sulfuras, Hand Of Ragnaros", false)]
        [TestCase("SulfurasHandOfRagnaros", false)]
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