using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies.Cold
{
    public class AgedBriePolicy : Policy
    {
        public override void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.IncreaseBy(2);
                return;
            }
            
            item.Quality.IncreaseBy(1);
        }

        public override bool isEligibleFor(string name, string policyName)
        {
            return name.Equals("Aged Brie") && policyName.Equals("Cold");
        }
    }
}