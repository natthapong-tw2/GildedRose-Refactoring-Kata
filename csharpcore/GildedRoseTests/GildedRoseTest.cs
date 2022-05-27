using System;
using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        protected const int NormalUpdateQuality = 1;
    }
    public class GildedRoseBuilder
    {
        public List<Item> Items { get; set; }

        public GildedRose Build()
        {
            return new GildedRose(new List<Item>());
        }
        
        public GildedRoseBuilder WithItem(Item item)
        {
            if (this.Items == null)
            {
                this.Items = new List<Item>();                
            }
            this.Items.Add(item);

            return this;
        }
    }

    public class GeneralProductTests : GildedRoseTest
    {
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
        public void ProductQualityShouldDecressAsNormal()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality - NormalUpdateQuality;
            var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void GeneralProductQualityShouldBeDecressTwiceAsFastAsSellInDatePassed()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality - (2 * NormalUpdateQuality);
            var items = new List<Item> { new Item { Name = "UnknownType", SellIn = -1, Quality = originalQuality } };

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
    }

    public class AgedBrieProductTests : GildedRoseTest
    {
        [Fact]
        public void QualityShouldIncressWithNormalNumberOvertime()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality + NormalUpdateQuality;
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void QualityShouldIncressTwiceAsFastAsSellInDatePassed()
        {
            var originalQuality = 10;
            var expectedQuality = originalQuality + (2 * NormalUpdateQuality);
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedQuality, items[0].Quality);
        }
    }

    public class SulfurasProductTests : GildedRoseTest
    {
        [Fact]
        public void QualityAndSellInDateShouldShouldNotBeUpdatedOvertime()
        {
            var originalQuality = 10;
            var originalSellIn = 10;
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = originalSellIn, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(originalQuality, items[0].Quality);
            Assert.Equal(originalSellIn, items[0].SellIn);
        }
    }

    public class BackstagePassesTests : GildedRoseTest
    {
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

        [Theory]
        [InlineData(50, 1)]
        [InlineData(11, 1)]
        [InlineData(10, 2)]
        [InlineData(6, 2)]
        [InlineData(5, 3)]
        [InlineData(1, 3)]
        public void ShouldIncressQualityOvertimesBaseOnSellInRemainDays(int remainDays, int qualityUpdatedMultiplier)
        {
            var originalQuality = 10;
            var expectdQuality = originalQuality + (qualityUpdatedMultiplier * NormalUpdateQuality);
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = remainDays, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectdQuality, items[0].Quality);
        }

        [Fact]
        public void OverSellInDateQualityShouldBeZero()
        {
            var originalQuality = 10;
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = originalQuality } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }
    }

    public class ConjuredTests : GildedRoseTest
    {
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
