using IsolatedTests.GildedRose.Domain.Repositories;
using IsolatedTests.GildedRose.Domain.Services.Updaters;
using IsolatedTests.GildedRose.Infrastructure.DataReaders;
using IsolatedTests.GildedRose.Infrastructure.Repositories;
using Ninject.Modules;

namespace IsolatedTests.GildedRose
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