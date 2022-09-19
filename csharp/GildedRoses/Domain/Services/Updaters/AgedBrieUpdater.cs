using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
{
    public class AgedBrieUpdater : IITemUpdater
    {
        public virtual void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.IncreaseBy(2);
                return;
            }
            
            item.Quality.IncreaseBy(1);
        }

        public virtual bool IsSatisfiedBy(Item item)
        {
            return item?.Name == "Aged Brie";
        }
    }
}