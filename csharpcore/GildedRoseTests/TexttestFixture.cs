using System;
using System.Collections.Generic;
using Ninject;
using SafetyNet.GildedRose;
using SafetyNet.GildedRose.Domain.BusinessModels;

namespace SafetyNet.GildedRoseTests
{
    public static class TexttestFixture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var appContainer = new ApplicationBootstrapper().InitContainer();
            var app = appContainer.TryGet<GildedRose.Domain.Services.GildedRose>();
            var itemRepository = app.ItemRepository;
            
            int days = 2;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            for (var i = 0; i < days; i++)
            {
                PrintItemsOnDay(itemRepository.GetAll(), i);
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
