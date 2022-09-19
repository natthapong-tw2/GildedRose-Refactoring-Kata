using System;
using System.Collections.Generic;

namespace IsolatedTests.GildedRose.Infrastructure.DataModels
{
    [Serializable]
    public class ItemsDto
    {
        public IReadOnlyList<ItemDto> Items { get; set; }

        public ItemsDto()
        {
            Items = new List<ItemDto>();
        }
    }
}