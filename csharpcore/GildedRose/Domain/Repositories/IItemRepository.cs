using System.Collections.Generic;
using SafetyNet.GildedRose.Domain.BusinessModels;

namespace SafetyNet.GildedRose.Domain.Repositories
{
    public interface IItemRepository
    {
        IReadOnlyList<Item> GetAll();
    }
}