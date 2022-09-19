using System.Collections.Generic;
using csharp.GildedRoses.Domain.Repositories;

namespace csharp.GildedRoses.Domain.Services
{
    public class GildedRose
    {
        private readonly IItemRepository itemRepository;
        
        private readonly IList<IITemUpdater> updaters;
        
        public GildedRose(AgedBrieUpdater agedBrieUpdater,
            BackstagePassesUpdater backstagePassesUpdater,
            SulfurasUpdater sulfurasUpdater,
            StandardItemUpdater standardItemUpdater,
            IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
            updaters = new List<IITemUpdater>
            {
                // Be aware that order matters, is it covered ?
                agedBrieUpdater,
                backstagePassesUpdater,
                sulfurasUpdater,
                standardItemUpdater
            };
        }

        public void UpdateQuality()
        {
            var items = itemRepository.GetAll();
            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }
                
                foreach (var updater in updaters)
                {
                    if (updater.IsSatisfiedBy(item))
                    {
                        updater.UpdateQuality(item);
                        break;
                    }
                }
            }
        }
    }
}
