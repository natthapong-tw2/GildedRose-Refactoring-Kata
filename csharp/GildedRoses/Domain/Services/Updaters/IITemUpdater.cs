using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services
{
    public interface IITemUpdater
    {
        void UpdateQuality(Item item);
        bool IsSatisfiedBy(Item item);
    }
}