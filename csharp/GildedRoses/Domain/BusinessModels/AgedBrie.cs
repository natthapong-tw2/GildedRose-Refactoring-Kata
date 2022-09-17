namespace csharp.GildedRoses.Domain.BusinessModels
{
    public class AgedBrie : Item
    {
        public override void updateUsing()
        {
            Policy.UpdateQuality(this);
        }
    }
}