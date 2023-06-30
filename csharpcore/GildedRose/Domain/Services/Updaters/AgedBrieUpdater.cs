using GildedRose.Domain.BusinessModels;

namespace GildedRose.Domain.Services.Updaters
{
    public class AgedBrieUpdater : IITemUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.IncreaseBy(2);
                return;
            }
            
            item.Quality.IncreaseBy(1);
        }

        public bool IsSatisfiedBy(Item item)
        {
            return item.Name == "Aged Brie";
        }
    }
}