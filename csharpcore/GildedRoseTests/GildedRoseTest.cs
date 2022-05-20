using System;
using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private const int NormalUpdateQuality = 1;

        [Fact]
        public void foo()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void SellInShouldBeDecressedAfterUpdateQuality()
        {
            var originalSellIn = 10;
            var expectedSellIn = originalSellIn - 1;
            var items = new List<Item> { new Item { Name = "foo", SellIn = originalSellIn, Quality = 10 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedSellIn, items[0].SellIn);
        }

        [Fact]
        public void GeneralProductQualityShouldDecressAsNormal()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality - NormalUpdateQuality;
            var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = originalQuality } };
            
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void GeneralProductWhenOverSellInDateQualityShouldDecressTwoTimesPerNormal()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality - (2 * NormalUpdateQuality);
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void QualityOfProductsCouldNotBeNegative()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            
            GildedRose app = new GildedRose(items);           
            app.UpdateQuality();
            
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void AgedBrieQualityShouldIncressWithNormalNumberOvertime()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality + NormalUpdateQuality;
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = originalQuality } };
            
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void SulfurasQualityAndSellInDateShouldShouldNotBeUpdatedOvertime()
        {
            var originalQuality = 10;
            var originalSellIn = 10;
            var expectdQuality = 10;
            var expectdSellIn = 10;
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = originalSellIn, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectdQuality, items[0].Quality);
            Assert.Equal(expectdSellIn, items[0].SellIn);
        }

        [Fact]
        public void BackstagePassesThatHaveSellInMoreThanTenQualityShouldIncressOvertimeAsNormal()
        {
            var originalQuality = 10;
            var expectdQuality = originalQuality + NormalUpdateQuality;
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectdQuality, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesThatHaveSellInLessThanTenButMoreThanFiveQualityShouldIncressTwoTimesPerNormal()
        {
            var originalQuality = 10;
            var expectdQuality = originalQuality + (2 * NormalUpdateQuality) ;
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectdQuality, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesThatHaveSellInButLessThanFiveQualityShouldIncressThreeTimesPerNormal()
        {
            var originalQuality = 10;
            var expectdQuality = originalQuality + (3 * NormalUpdateQuality);
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectdQuality, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesOverSellInDateQualityShouldBeZero()
        {
            var originalQuality = 10;
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void ConjuredShouldDecressTwoTimesPerGeneral()
        {
            var originalQuality = 10;
            var expectdQuality = originalQuality - (2 * NormalUpdateQuality);
            var items = new List<Item> { new Item { Name = "Conjured", SellIn = 3, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectdQuality, items[0].Quality);
        }
    }
}
