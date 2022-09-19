using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Infrastructure.Repositories
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
            if (name != null && name.Equals("Aged Brie"))
            {
                return new AgedBrie
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                };
            }
            
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