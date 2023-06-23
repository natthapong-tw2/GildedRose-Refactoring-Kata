using System.Collections;
using System.Security.AccessControl;
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
            //We can nest test by item with TestFixture

            [TestFixture]
            public class ForEachStandardItem
            {
                // Just copy down. I am gonna leave zoom and commebac ;)
                [Test]
                public void ShouldDecreaseSellInByOne()
                {
                    // Arrange
                    var standardItem = new Item
                    {
                        Name = "Standard item",
                        SellIn = 10,
                        Quality = 10
                    };
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
                        var standardItem = new Item
                        {
                            Name = "Standard item",
                            SellIn = 10,
                            Quality = 10
                        };
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
                        var standardItem = new Item
                        {
                            Name = "Standard item",
                            SellIn = -5,
                            Quality = 10
                        };
                        IList<Item> items = new List<Item> { standardItem };

                        // Act
                        new GildedRose(items).UpdateQuality();

                        // Assert
                        Assert.That(standardItem.Quality, Is.EqualTo(8));
                    }
                }
            }

            // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality

            [TestFixture]
            public class ForEachSulfurasItem
            {
                [TestCase(-1, -1)]
                [TestCase(0, 0)]
                [TestCase(10, 10)]
                public void ShouldNotDecreaseSellIn(int currentSellIn, int expectedSellIn)
                {
                    // Arrange
                    var sulfurasItem = new Item
                    {
                        Name = "Sulfuras, Hand of Ragnaros",
                        SellIn = currentSellIn
                    };
                    IList<Item> items = new List<Item> { sulfurasItem };

                    // Act
                    new GildedRose(items).UpdateQuality();

                    // Assert
                    Assert.That(sulfurasItem.SellIn, Is.EqualTo(expectedSellIn));
                }

                [TestCase(-1, -1)]
                [TestCase(0, 0)]
                [TestCase(10, 10)]
                public void ShouldNotDecreaseQuality(int currentQuality, int expectedQuality)
                {
                    // Arrange
                    var sulfurasItem = new Item
                    {
                        Name = "Sulfuras, Hand of Ragnaros",
                        Quality = currentQuality
                    };
                    IList<Item> items = new List<Item> { sulfurasItem };

                    // Act
                    new GildedRose(items).UpdateQuality();

                    // Assert
                    Assert.That(sulfurasItem.Quality, Is.EqualTo(expectedQuality));
                }
            }
        }
    }
}
