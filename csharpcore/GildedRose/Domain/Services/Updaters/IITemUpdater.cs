using GildedRose.Domain.BusinessModels;

namespace GildedRose.Domain.Services.Updaters
{
    public interface IITemUpdater
    {
        void UpdateQuality(Item item);
        bool IsSatisfiedBy(Item item);
    }
}