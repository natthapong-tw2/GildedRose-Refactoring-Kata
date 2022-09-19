namespace csharp.GildedRoses.Domain.BusinessModels
{
    public class Item
    {
        // Be aware that properties are often left public to make the setup easier in tests
        public string Name { get; set; }
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }  
    }
}
