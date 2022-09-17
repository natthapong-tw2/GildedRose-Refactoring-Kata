namespace csharp.GildedRoses.Domain.BusinessModels
{
    public class StandardItem : Item
    {
        public override void updateUsing()
        {
            Policy.UpdateQuality(this);
        }
    }
}