using SafetyNet.GildedRose.Domain.BusinessModels;

namespace SafetyNet.GildedRose.Domain.Services.Updaters
{
    public interface IITemUpdater
    {
        void UpdateQuality(Item item);
        bool IsSatisfiedBy(Item item);
    }
}