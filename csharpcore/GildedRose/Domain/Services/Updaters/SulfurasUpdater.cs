using GildedRose.Domain.BusinessModels;

namespace GildedRose.Domain.Services.Updaters
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