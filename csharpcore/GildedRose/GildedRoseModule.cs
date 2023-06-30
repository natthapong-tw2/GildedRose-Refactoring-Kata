using GildedRose.Domain.Repositories;
using GildedRose.Domain.Services.Updaters;
using GildedRose.Infrastructure.DataReaders;
using GildedRose.Infrastructure.Repositories;
using Ninject.Modules;

namespace GildedRose
{
    public class GildedRoseModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AgedBrieUpdater>().ToSelf().InSingletonScope();
            Bind<BackstagePassesUpdater>().ToSelf().InSingletonScope();
            Bind<SulfurasUpdater>().ToSelf().InSingletonScope();
            Bind<StandardItemUpdater>().ToSelf().InSingletonScope();
            Bind<Domain.Services.GildedRose>().ToSelf().InSingletonScope();
            Bind<IItemRepository>().To<ItemRepository>().InSingletonScope();
            Bind<ItemsReader>().ToSelf().InSingletonScope();
        }
    }
}