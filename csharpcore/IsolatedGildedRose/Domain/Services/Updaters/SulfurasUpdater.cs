using IsolatedTests.GildedRose.Domain.BusinessModels;

namespace IsolatedTests.GildedRose.Domain.Services.Updaters
{
    public class SulfurasUpdater : IITemUpdater
    {
        public virtual void UpdateQuality(Item item)
        {
        }

        public virtual bool IsSatisfiedBy(Item item)
        {
            return item?.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}