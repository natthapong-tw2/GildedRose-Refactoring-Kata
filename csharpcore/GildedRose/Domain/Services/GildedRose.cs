using System.Collections.Generic;
using SafetyNet.GildedRose.Domain.Repositories;
using SafetyNet.GildedRose.Domain.Services.Updaters;

namespace SafetyNet.GildedRose.Domain.Services
{
    public class GildedRose
    {
        private readonly IItemRepository itemRepository;
        
        private readonly IList<IITemUpdater> updaters;
        
        public GildedRose(
            AgedBrieUpdater agedBrieUpdater,
            BackstagePassesUpdater backstagePassesUpdater,
            SulfurasUpdater sulfurasUpdater,
            StandardItemUpdater standardItemUpdater,
            IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
            updaters = new List<IITemUpdater>
            {
                agedBrieUpdater,
                backstagePassesUpdater,
                sulfurasUpdater,
                standardItemUpdater
            };
        }

        public IItemRepository ItemRepository => itemRepository;

        public void UpdateQuality()
        {
            var items = itemRepository.GetAll();
            foreach (var item in items)
            {
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
