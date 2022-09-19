using IsolatedTests.GildedRose.Domain.BusinessModels;

namespace IsolatedTests.GildedRose.Infrastructure.Repositories
{
    public class ItemFactory
    {
        private string name;
        private int sellIn;
        private Quality quality;

        public static ItemFactory Create()
        {
            return new ItemFactory();
        }

        public Item Get()
        {
            return new Item
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }

        public ItemFactory WithName(string itemName)
        {
            name = itemName;
            return this;
        }

        public ItemFactory WithSellIn(int itemSellIn)
        {
            sellIn = itemSellIn;
            return this;
        }

        public ItemFactory WithQuality(int itemQuality)
        {
            quality = new Quality(itemQuality);
            return this;
        }
    }
}