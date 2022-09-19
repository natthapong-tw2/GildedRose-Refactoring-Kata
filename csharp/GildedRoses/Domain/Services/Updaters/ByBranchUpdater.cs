using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
{
    public class ByBranchUpdater
    {
        public virtual void UpdateQuality(AgedBrie agedBrie)
        {
            agedBrie.SellIn -= 1;

            if (agedBrie.SellIn < 0)
            {
                agedBrie.Quality.IncreaseBy(2);
                return;
            }

            agedBrie.Quality.Increase();
        }
    }
}