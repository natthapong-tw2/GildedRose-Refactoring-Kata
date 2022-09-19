using Ninject.Modules;
using SafetyNet.GildedRose.Domain.Repositories;
using SafetyNet.GildedRose.Domain.Services.Updaters;
using SafetyNet.GildedRose.Infrastructure.DataReaders;
using SafetyNet.GildedRose.Infrastructure.Repositories;

namespace SafetyNet.GildedRose
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