using IsolatedTests.GildedRose.Domain.BusinessModels;

namespace IsolatedTests.GildedRose.Domain.Services.Updaters
{
    public interface IITemUpdater
    {
        void UpdateQuality(Item item);
        bool IsSatisfiedBy(Item item);
    }
}