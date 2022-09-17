using csharp.GildedRoses.Domain.Services.Policies;

namespace csharp.GildedRoses.Domain.BusinessModels
{
    public abstract class Item
    {
        public string Name { get; set; }
        
        public Policy Policy { get; set; }
        
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }

        public abstract void updateUsing();
    }
}
