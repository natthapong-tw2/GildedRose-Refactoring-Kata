using System.Collections.Generic;
using IsolatedTests.GildedRose.Domain.BusinessModels;

namespace IsolatedTests.GildedRose.Domain.Repositories
{
    public interface IItemRepository
    {
        IReadOnlyList<Item> GetAll();
    }
}