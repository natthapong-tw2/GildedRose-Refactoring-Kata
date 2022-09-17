using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies.Cold
{
    public class StandardItemPolicy : Policy
    {
        public override void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.DecreaseBy(2);
                return;
            }
            
            item.Quality.Decrease();
        }

        public override bool isEligibleFor(string name, string policyName)
        {
            return !name.Equals("Aged Brie") && 
                   !name.StartsWith("Backstage passes") &&
                   !name.StartsWith("Sulfuras") &&
                   policyName.Equals("Cold");
        }
    }
}