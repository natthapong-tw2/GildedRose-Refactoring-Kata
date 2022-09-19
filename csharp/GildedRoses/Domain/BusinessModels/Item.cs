using csharp.GildedRoses.Domain.Services;

namespace csharp.GildedRoses.Domain.BusinessModels
{
    public class Item
    {
        // Be aware that properties are often left public to make the setup easier in tests
        public string Name { get; set; }
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }

        public virtual bool UpdateQualityUsing(ByBranchUpdater byBranchUpdater)
        {
            return false;
        }
    }

    public class AgedBrie : Item
    {
        public override bool UpdateQualityUsing(ByBranchUpdater byBranchUpdater)
        {
            byBranchUpdater.UpdateQuality(this);
            return true;
        }
    }
}
