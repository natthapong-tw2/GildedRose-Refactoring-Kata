using System;

namespace IsolatedTests.GildedRose.Infrastructure.DataModels
{
    [Serializable]
    public class ItemDto
    {
        public string Name { get; set; }
        
        public int SellIn { get; set; }
        
        public int Quality { get; set; }
    }
}