using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
{
    public class StandardItemUpdater : IITemUpdater
    {
        public virtual void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.DecreaseBy(2);
                return;
            }
            
            item.Quality.Decrease();
        }

        public virtual bool IsSatisfiedBy(Item item)
        {
            return item != null;
        }
    }
}