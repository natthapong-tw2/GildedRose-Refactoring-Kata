using csharp.GildedRoses.Domain.Repositories;

namespace csharp.GildedRoses.Domain.Services
{
    public class GildedRose
    {
        private readonly IItemRepository itemRepository;

        public GildedRose(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void UpdateQuality()
        {
            var items = itemRepository.GetAll();
            foreach (var item in items)
            {
                item.updateUsing();
            }
        }
    }
}
