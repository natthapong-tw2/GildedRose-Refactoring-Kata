using System.Collections.Generic;
using csharp.GildedRoses.Domain.Repositories;

namespace csharp.GildedRoses.Domain.Services
{
    public class GildedRose
    {
        private readonly ByBranchUpdater byBranchUpdater;
        private readonly IItemRepository itemRepository;
        
        private readonly IList<IITemUpdater> updaters;
        
        public GildedRose(
            BackstagePassesUpdater backstagePassesUpdater,
            SulfurasUpdater sulfurasUpdater,
            StandardItemUpdater standardItemUpdater,
            ByBranchUpdater byBranchUpdater,
            IItemRepository itemRepository)
        {
            this.byBranchUpdater = byBranchUpdater;
            this.itemRepository = itemRepository;
            updaters = new List<IITemUpdater>
            {
                // Be aware that order matters, is it covered ?
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

                item.UpdateQualityUsing(byBranchUpdater);
                
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
