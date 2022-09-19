using IsolatedTests.GildedRose.Domain.BusinessModels;

namespace IsolatedTests.GildedRose.Domain.Services.Updaters
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