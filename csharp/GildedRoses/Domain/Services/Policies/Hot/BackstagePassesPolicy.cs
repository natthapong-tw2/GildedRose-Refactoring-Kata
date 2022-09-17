using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Services.Policies.Hot
{
    public class BackstagePassesPolicy : Policy
    {
        public override void UpdateQuality(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality.DropTo(0);
                return;
            }

            if (item.SellIn < 5)
            {
                item.Quality.IncreaseBy(2);
                return;
            }

            if (item.SellIn < 10)
            {
                item.Quality.IncreaseBy(1);
                return;
            }
        }

        public override bool isEligibleFor(string name, string policyName)
        {
            return name.StartsWith("Backstage passes") && policyName.Equals("Hot");
        }
    }
}