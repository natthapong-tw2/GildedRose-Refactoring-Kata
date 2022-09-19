using System;
using System.Collections.Generic;
using Ninject;
using SafetyNet.GildedRose.Domain.BusinessModels;

namespace SafetyNet.GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var appContainer = new ApplicationBootstrapper().InitContainer();
            var app = appContainer.TryGet<Domain.Services.GildedRose>();
            var itemRepository = app.ItemRepository;
            
            for (var day = 0; day < 31; day++)
            {
                PrintItemsOnDay(itemRepository.GetAll(), day);
                app.UpdateQuality();
            }
        }

        private static void PrintItemsOnDay(IReadOnlyList<Item> items, int i)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            PrintAllItems(items);
            Console.WriteLine("");
        }

        private static void PrintAllItems(IReadOnlyList<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
