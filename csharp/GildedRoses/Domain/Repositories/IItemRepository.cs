using System.Collections.Generic;
using csharp.GildedRoses.Domain.BusinessModels;

namespace csharp.GildedRoses.Domain.Repositories
{
    public interface IItemRepository
    {
        IReadOnlyList<Item> GetAll();
    }
}