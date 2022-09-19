using System;
using System.Collections.Generic;

namespace csharp.GildedRoses.Infrastructure.DataModels
{
    [Serializable]
    public class ItemsDto
    {
        public IReadOnlyList<ItemDto> Items { get; set; }
    }
}