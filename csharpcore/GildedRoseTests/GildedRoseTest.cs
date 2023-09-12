using System.Runtime.CompilerServices;
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

            [TestFixture]
            public class ForEachAgedBrieItem
            {
                [TestCase(-1, 1, -1)]
                [TestCase(0, 2, -1)]
                [TestCase(48, 50, -1)]
                [TestCase(-1, 1, 0)]
                [TestCase(0, 2, 0)]
                [TestCase(48, 50, 0)]
                public void ShouldIncreaseQualityBy2(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                )
                {
                    var agedBrieItem = new Item
                    {
                        Name = "Aged Brie",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { agedBrieItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(agedBrieItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(49, 50, 1)]
                [TestCase(49, 50, -1)]
                [TestCase(49, 50, 0)]
                public void ShouldIncreaseQualityBy1(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                )
                {
                    var agedBrieItem = new Item
                    {
                        Name = "Aged Brie",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { agedBrieItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(agedBrieItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(50, 50, -1)]
                [TestCase(50, 50, 0)]
                [TestCase(50, 50, 1)]
                public void ShouldNotIncreaseQuality(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                )
                {
                    var agedBrieItem = new Item
                    {
                        Name = "Aged Brie",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { agedBrieItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(agedBrieItem.Quality, Is.EqualTo(expectedQuality));
                }
            }

            [TestFixture]
            public class ForEachBackStagePassesItem
            {
                [TestCase(49, 50, 11)] // Q<50 && S>=11
                public void ShouldIncreaseQualiteBy1(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                ){
                    var backStagePassesItem = new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { backStagePassesItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(backStagePassesItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(48, 50, 5)]
                [TestCase(45, 47, 6)] // (Q<50 && Q>=48) || (Q<50 && S>=6)
                public void ShouldIncreaseQualityBy2(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                ){
                    var backStagePassesItem = new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { backStagePassesItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(backStagePassesItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(47, 50, 5)] // Q<50 && Q+2<50 && S<6
                public void ShouldIncreaseQualiteBy3(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                ){
                    var backStagePassesItem = new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { backStagePassesItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(backStagePassesItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(50, 50, 5)] // Q>=50
                public void ShouldNotIncreaseQualite(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                ){
                    var backStagePassesItem = new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { backStagePassesItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(backStagePassesItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(50, 0, 0)]
                [TestCase(45, 0, -1)] //S<1
                public void ShouldDropQualiteto0(
                    int currentQuality,
                    int expectedQuality,
                    int currentSellIn
                ){
                    var backStagePassesItem = new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        Quality = currentQuality,
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { backStagePassesItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(backStagePassesItem.Quality, Is.EqualTo(expectedQuality));
                }

                [TestCase(50, 49)]
                [TestCase(45, 44)]
                public void ShouldDecreaseSellIn(
                    int currentSellIn,
                    int expectedSellIn
                ){
                    var backStagePassesItem = new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = currentSellIn
                    };

                    IList<Item> items = new List<Item> { backStagePassesItem };

                    new GildedRose(items).UpdateQuality();

                    Assert.That(backStagePassesItem.SellIn, Is.EqualTo(expectedSellIn));
                }
            }

            [TestFixture]
            public class ForStandardItemQualityOver50
            {
                [TestCase(50, 49, 10)]
                [TestCase(50, 48, -1)]
                [TestCase(50, 48, 0)]
                public void ShouldNotUpdateQuality(
                    int currentQuality,
                    int expectedQuality,
                    int sellIn
                )
                {
                    // Arrange
                    var standardItem = new Item
                    {
                        Name = "Standard item",
                        Quality = currentQuality,
                        SellIn = sellIn
                    };
                    IList<Item> items = new List<Item> { standardItem };

                    // Act
                    new GildedRose(items).UpdateQuality();

                    // Assert
                    Assert.That(standardItem.Quality, Is.EqualTo(expectedQuality));
                }
                
            }
            
            [TestFixture]
            public class ForStandardItemQualityBellow0
            {
                [TestCase(0, 0, 10)]
                [TestCase(0, 0, -1)]
                [TestCase(0, 0, 0)]
                public void ShouldNotDecreaseBellow0(
                    int currentQuality,
                    int expectedQuality,
                    int sellIn
                )
                {
                    // Arrange
                    var standardItem = new Item
                    {
                        Name = "Standard item",
                        Quality = currentQuality,
                        SellIn = sellIn
                    };
                    IList<Item> items = new List<Item> { standardItem };

                    // Act
                    new GildedRose(items).UpdateQuality();

                    // Assert
                    Assert.That(standardItem.Quality, Is.EqualTo(expectedQuality));
                }
                
            }
            
            [Ignore("Waiting for the implementation")]
            [TestFixture]
            public class ForEachConjuredItem
            {
                [TestCase(10, 8)]
                [TestCase(0, -2)]
                public void ShouldDecreaseQuality(int currentQuality, int expectedQuality)
                {
                    // Arrange
                    var conjuredItem = new Item
                    {
                        Name = "Conjured",
                        SellIn = currentQuality
                    };
                    IList<Item> items = new List<Item> { conjuredItem };

                    // Act
                    new GildedRose(items).UpdateQuality();

                    // Assert
                    Assert.That(conjuredItem.SellIn, Is.EqualTo(expectedQuality));
                }
            }
        }
    }
}
