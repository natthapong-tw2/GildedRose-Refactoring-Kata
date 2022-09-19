namespace IsolatedTests.GildedRose.Domain.BusinessModels
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }  
    }
}
