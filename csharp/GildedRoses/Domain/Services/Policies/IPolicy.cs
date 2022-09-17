using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies
{
    public interface IPolicy
    {
        void UpdateQuality(AgedBrie agedBrie);
        void UpdateQuality(BackstagePasses backstagePasses);
        void UpdateQuality(Sulfuras sulfuras);
        void UpdateQuality(StandardItem standardItem);
        
        bool IsEligible(Item item);
    }
}