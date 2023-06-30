using System.Collections.Generic;
using GildedRose.Domain.BusinessModels;

namespace GildedRose.Domain.Repositories
{
    public interface IItemRepository
    {
        IReadOnlyList<Item> GetAll();
    }
}