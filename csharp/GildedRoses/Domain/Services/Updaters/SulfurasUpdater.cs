using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
{
    public class SulfurasUpdater : IITemUpdater
    {
        public void UpdateQuality(Item item)
        {
        }

        public bool IsSatisfiedBy(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}