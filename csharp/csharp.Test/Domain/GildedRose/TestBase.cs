using System.Collections.Generic;
using System.Linq;
using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Repositories;
using csharp.GildedRoses.Domain.Services;
using csharp.GildedRoses.Infrastructure.DataModels;
using csharp.GildedRoses.Infrastructure.DataReaders;
using FluentAssertions;
using Ninject;
using NSubstitute;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public partial class GildedRoseSpecs
    {
        [TestFixture]
        public partial class InColdCountries
        {
            protected const string coldPolicy = "Cold";
        }

        [TestFixture]
        public partial class InHotCountries
        {
            protected const string hotPolicy = "Hot";
        }

        public class TestBase
        {
            protected GildedRose application;
            protected ItemsReader itemsReaderSubstitute;
            private IItemRepository itemRepository;

            [SetUp]
            public void SetUp()
            {
                var appContainer = new ApplicationBootstrapper().InitContainer();

                itemsReaderSubstitute = Substitute.For<ItemsReader>();
                appContainer.Rebind<ItemsReader>().ToConstant(itemsReaderSubstitute).InSingletonScope();

                application = appContainer.Get<GildedRose>();
                itemRepository = appContainer.Get<IItemRepository>();
            }
            
            protected void ExecuteSellInScenario(string policyName, string itemName, int sellIn, int quality, int[] expectedSellIns)
            {
                var itemDto = new ItemDto
                {
                    Name = itemName,
                    SellIn = sellIn,
                    Quality = quality,
                    Policy = policyName
                };
                itemsReaderSubstitute.ReadAll(Arg.Any<string>())
                    .Returns(new ItemsDto { Items = new List<ItemDto> { itemDto } });

                for (var day = 0; day < expectedSellIns.Length; day++)
                {
                    application.UpdateQuality();
                    var first = itemRepository.GetAll().First();
                    first.SellIn.Should().Be(expectedSellIns[day]);
                }
            }

            protected void ExecuteQualityScenario(string policyName, string itemName, int sellIn, int quality, int[] expectedQualities)
            {
                var itemDto = new ItemDto
                {
                    Name = itemName,
                    SellIn = sellIn,
                    Quality = quality,
                    Policy = policyName
                };
                itemsReaderSubstitute.ReadAll(Arg.Any<string>())
                    .Returns(new ItemsDto { Items = new List<ItemDto> { itemDto } });

                for (var day = 0; day < expectedQualities.Length; day++)
                {
                    application.UpdateQuality();
                    var first = itemRepository.GetAll().First();
                    first.Quality.Should().Be(new Quality(expectedQualities[day]));
                }
            }

            protected void ExecuteScenario(string policyName, string itemName, int[] expectedSellIns, int[] expectedQualities)
            {
                expectedQualities.Length.Should().Be(expectedSellIns.Length,
                    "Your scenario was expected to have as many SellIns as Qualities but wasn't");

                var itemDto = new ItemDto
                {
                    Name = itemName,
                    SellIn = expectedSellIns.First(),
                    Quality = expectedQualities.First(),
                    Policy = policyName
                };
                itemsReaderSubstitute.ReadAll(Arg.Any<string>())
                    .Returns(new ItemsDto { Items = new List<ItemDto> { itemDto } });

                for (var day = 1; day < expectedQualities.Length - 1; day++)
                {
                    application.UpdateQuality();
                    itemRepository.GetAll().First().Quality.Should().Be(new Quality(expectedQualities[day]));
                }
            }
        }
    }
}
