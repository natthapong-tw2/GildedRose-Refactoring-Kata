using System;
using System.Collections.Generic;

namespace GildedRose.Infrastructure.DataModels
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