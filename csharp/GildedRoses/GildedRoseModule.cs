using csharp.GildedRoses.Domain.Repositories;
using csharp.GildedRoses.Domain.Services;
using csharp.GildedRoses.Infrastructure.DataReaders;
using csharp.GildedRoses.Infrastructure.Repositories;
using Ninject.Modules;

namespace csharp.GildedRoses
{
    public class GildedRoseModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GildedRose>().ToSelf().InSingletonScope();
            
            Bind<IItemRepository>().To<ItemRepository>().InSingletonScope();
            Bind<ItemsReader>().ToSelf().InSingletonScope();
        }
    }
}