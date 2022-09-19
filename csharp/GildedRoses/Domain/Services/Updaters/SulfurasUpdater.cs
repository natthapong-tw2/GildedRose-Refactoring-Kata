using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
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