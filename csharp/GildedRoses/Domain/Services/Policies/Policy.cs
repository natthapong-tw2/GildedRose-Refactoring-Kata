using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies
{
    public abstract class Policy
    {
        public static class Cold
        {
            public static readonly Policy AgedBrie = new Policies.Cold.AgedBriePolicy();
            public static readonly Policy BackstagePasses = new Policies.Cold.BackstagePassesPolicy();
            public static readonly Policy Sulfuras = new SulfurasPolicy();
            public static readonly Policy StandardItem = new Policies.Cold.StandardItemPolicy();
        }
    
        public static class Hot
        {
            public static readonly Policy AgedBrie = new Policies.Hot.AgedBriePolicy();
            public static readonly Policy BackstagePasses = new Policies.Hot.BackstagePassesPolicy();
            public static readonly Policy Sulfuras = new SulfurasPolicy();
            public static readonly Policy StandardItem = new Policies.Hot.StandardItemPolicy();
        }
        
        public abstract void UpdateQuality(Item item);

        public abstract bool isEligibleFor(string name, string policyName);
    }
}