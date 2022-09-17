using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies.Hot
{
    public class AgedBriePolicy : Policy
    {
        public override void UpdateQuality(Item item)
        {
            item.SellIn -= 2;

            if (item.SellIn < 0)
            {
                item.Quality.IncreaseBy(4);
                return;
            }
            
            item.Quality.IncreaseBy(2);
        }

        public override bool isEligibleFor(string name, string policyName)
        {
            return name.Equals("Aged Brie") && policyName.Equals("Hot");
        }
    }
}