using SafetyNet.GildedRose.Domain.BusinessModels;

namespace SafetyNet.GildedRose.Domain.Services.Updaters
{
    public class BackstagePassesUpdater : IITemUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.DropTo(0);
                return;
            }

            if (item.SellIn < 5)
            {
                item.Quality.IncreaseBy(3);
                return;
            }

            if (item.SellIn < 10)
            {
                item.Quality.IncreaseBy(2);
                return;
            }
            
            item.Quality.Increase();
        }

        public bool IsSatisfiedBy(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}