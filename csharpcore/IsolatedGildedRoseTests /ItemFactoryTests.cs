using FluentAssertions;
using IsolatedTests.GildedRose.Domain.BusinessModels;
using IsolatedTests.GildedRose.Infrastructure.Repositories;
using NUnit.Framework;

namespace IsolatedTests.GildedRoseTests
{
    [TestFixture]
    public class ItemFactoryTests
    {
        [Test]
        public void ShouldCreateItem()
        {
            var item = ItemFactory.Create().Get();
            item.Should().NotBeNull();
        }
        
        [TestCase("anExpectedName")]
        [TestCase("anOtherExpectedName")]
        public void ShouldCreateItemWithCorrectName(string expectedName)
        {
            var item = ItemFactory.Create().WithName(expectedName).Get();
            item.Name.Should().Be(expectedName);
        }
        
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(30)]
        public void ShouldCreateItemWithCorrectSellIn(int expectedSellIn)
        {
            var item = ItemFactory.Create().WithSellIn(expectedSellIn).Get();
            item.SellIn.Should().Be(expectedSellIn);
        }
        
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(30)]
        public void ShouldCreateItemWithCorrectQuality(int expectedSellIn)
        {
            var item = ItemFactory.Create().WithQuality(expectedSellIn).Get();
            item.Quality.Should().Be(new Quality(expectedSellIn));
        }
    }
}