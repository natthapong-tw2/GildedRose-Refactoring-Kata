namespace csharp.GildedRoses.Domain.BusinessModels
{
    public class BackstagePasses : Item
    {
        public override void updateUsing()
        {
            Policy.UpdateQuality(this);
        }
    }
}