using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using IsolatedTests.GildedRose.Domain.BusinessModels;
using IsolatedTests.GildedRose.Domain.Repositories;
using IsolatedTests.GildedRose.Infrastructure.DataReaders;

namespace IsolatedTests.GildedRose.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemsReader itemsReader;
        
        private List<Item> items;

        public ItemRepository(ItemsReader itemsReader)
        {
            this.itemsReader = itemsReader;
        }
        
        public IReadOnlyList<Item> GetAll()
        {
            if (items == null)
            {
                items = Load();
            }

            return items;
        }

        private List<Item> Load()
        {
            var baseFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(baseFolder, "items.json");
            var itemsDtos = itemsReader.ReadAll(filePath);

            return itemsDtos.Items
                .Where(item => item != null)
                .Select(item => ItemFactory.Create()
                    .WithName(item.Name)
                    .WithSellIn(item.SellIn)
                    .WithQuality(item.Quality)
                    .Get())
                .ToList();
        }
    }
}