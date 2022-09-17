using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
{
    public class StandardItemUpdater : IITemUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.DecreaseBy(2);
                return;
            }
            
            item.Quality.Decrease();
        }

        public bool IsSatisfiedBy(Item item)
        {
            return true;
        }
    }
}