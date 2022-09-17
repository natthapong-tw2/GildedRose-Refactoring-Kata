namespace csharp.GildedRoses.Domain.BusinessModels
{
    public class Sulfuras : Item
    {
        public override void updateUsing()
        {
            Policy.UpdateQuality(this);
        }
    }
}