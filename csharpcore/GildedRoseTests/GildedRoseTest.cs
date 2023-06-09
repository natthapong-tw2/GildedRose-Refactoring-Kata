using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestFixture]
        public class UpdateQuality
        {
            [TestFixture]
            public class ForEachStandardItem
            {
                [Test]
                public void ShouldDecreaseSellInByOne()
                {
                    // Arrange
                    var standardItem = new Item { Name = "Standard item", SellIn = 10, Quality = 10 };
                    IList<Item> items = new List<Item> { standardItem };

                    // Act
                    new GildedRose(items).UpdateQuality();

                    // Assert
                    Assert.That(standardItem.SellIn, Is.EqualTo(9));
                }

                [TestFixture]
                public class ShouldDecreaseQuality
                {
                    [Test]
                    public void ByOneBeforeSellInDate()
                    {
                        // Arrange
                        var standardItem = new Item { Name = "Standard item", SellIn = 10, Quality = 10 };
                        IList<Item> items = new List<Item> { standardItem };

                        // Act
                        new GildedRose(items).UpdateQuality();

                        // Assert
                        Assert.That(standardItem.Quality, Is.EqualTo(9));
                    }
                    
                    
                    [Test]
                    public void ByTwoAfterSellInDate()
                    {
                        // Arrange
                        var standardItem = new Item { Name = "Standard item", SellIn = -5, Quality = 10 };
                        IList<Item> items = new List<Item> { standardItem };

                        // Act
                        new GildedRose(items).UpdateQuality();

                        // Assert
                        Assert.That(standardItem.Quality, Is.EqualTo(8));
                    }
                }
            }
        }
    }
}
