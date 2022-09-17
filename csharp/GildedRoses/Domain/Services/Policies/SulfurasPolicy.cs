using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies
{
    public class SulfurasPolicy : Policy
    {
        public override void UpdateQuality(Item item)
        {
        }

        public override bool isEligibleFor(string name, string policyName)
        {
            return name.StartsWith("Sulfuras");
        }
    }
}