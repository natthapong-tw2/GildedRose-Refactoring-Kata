using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies.Hot
{
    public class StandardItemPolicy : Policy
    {
        public override void UpdateQuality(Item item)
        {
            item.SellIn -= 2;

            if (item.SellIn < 0)
            {
                item.Quality.DecreaseBy(4);
                return;
            }
            
            item.Quality.DecreaseBy(2);
        }

        public override bool isEligibleFor(string name, string policyName)
        {
            return !name.Equals("Aged Brie") && 
                   !name.StartsWith("Backstage passes") &&
                   !name.StartsWith("Sulfuras") &&
                   policyName.Equals("Hot");
        }
    }
}