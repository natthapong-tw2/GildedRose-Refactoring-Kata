using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRose;
using GildedRose.Domain.BusinessModels;
using GildedRose.Domain.Repositories;
using GildedRose.Infrastructure.DataModels;
using GildedRose.Infrastructure.DataReaders;
using Ninject;
using NSubstitute;
using NUnit.Framework;

namespace GildedRoseTests.Domain
{
    [TestFixture]
    public class GildedRoseSpecs 
    {
        [TestFixture]
        public class ForAgedBrie
        {
            private const string ItemName = "Aged Brie";
            
            [TestFixture]
            public class ShouldDecreaseSellIn : TestBase
            {
                [TestCase(4, 5, new[] { 3, 2, 1, 0, -1, -2 })]
                public void ByOneEveryDay(int sellIn, int quality, int[] expectedSellIns)
                {
                    ExecuteSellInScenario(ItemName, sellIn, quality, expectedSellIns);
                }
            }

            [TestFixture]
            public class ShouldIncreaseQuality
            {
                [TestFixture]
                public class ByOneEveryDay : TestBase
                {
                    [TestCase(new[] { 5, 4, 3, 2, 1, 0}, new[] { 10, 11, 12, 13, 14, 15 })]
                    public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }

                [TestFixture]
                public class ByTwiceEveryDay : TestBase
                {
                    [TestCase(new[] { 0, -1, -2, -3, -4, -5}, new[] { 10, 12, 14, 16, 18, 20 })]
                    public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }
            }

            [TestFixture]
            public class ShouldNotUpdateQuality
            {
                [TestFixture]
                public class Over50 : TestBase
                {
                    [TestCase(new[] { 3, 2, 1, 0 }, new[] { 50, 50, 50, 50 })]
                    public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }

                    [TestCase(new[] { 0, -1, -2, -3 }, new[] { 49, 50, 50, 50 })]
                    [TestCase(new[] { 0, -1, -2, -3 }, new[] { 50, 50, 50, 50 })]
                    public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }
            }
        }

        [TestFixture]
        public class ForBackstagePasses
        {
            private const string ItemName = "Backstage passes to a TAFKAL80ETC concert";
            
            [TestFixture]
            public class ShouldDecreaseSellIn : TestBase
            {
                [TestCase(4, 5, new[] { 3, 2, 1, 0, -1, -2 })]
                public void ByOneEveryDay(int sellIn, int quality, int[] expectedSellIns)
                {
                    ExecuteSellInScenario(ItemName, sellIn, quality, expectedSellIns);
                }
            }

            [TestFixture]
            public class ShouldIncreaseQuality
            {
                [TestFixture]
                public class ByOne : TestBase
                {
                    [TestCase(new[] { 14, 13, 12, 11, 10 }, new[] { 10, 11, 12, 13, 14 })]
                    public void WhenTheConcertIsMoreThanTenDays(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }

                [TestFixture]
                public class ByTwo : TestBase
                {
                    [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 10, 12, 14, 16, 18, 20 })]
                    public void WhenTheConcertIsInLessThanTenDaysButMoreThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }

                [TestFixture]
                public class ByThree : TestBase
                {
                    [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 10, 13, 16, 19, 22, 25 })]
                    public void WhenTheConcertIsInLessThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }
            }

            [TestFixture]
            public class ShouldDropQualityOfBackstagePassesToZero : TestBase
            {
                [TestCase(new[] { 1, 0, -1, -2 }, new[] { 40, 43, 0, 0 })]
                public void WhenTheConcertIsOver(int[] expectedSellIns, int[] expectedQualities)
                {
                    ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                }
            }

            [TestFixture]
            public class ShouldNotUpdateQuality
            {
                [TestFixture]
                public class OverFifty : TestBase
                {
                    [TestCase(new[] { 13, 12, 11, 10 }, new[] { 50, 50, 50, 50 })]
                    public void WhenTheConcertIsMoreThanTenDays(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                    
                    [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 49, 50, 50, 50, 50, 50 })]
                    [TestCase(new[] { 10, 9, 8, 7, 6, 5 }, new[] { 50, 50, 50, 50, 50, 50 })]
                    public void WhenTheConcertIsInLessThanTenDaysButMoreThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                    
                    [TestCase(new[] { 5, 4, 3, 2, 1, 0}, new[] { 48, 50, 50, 50, 50, 50 })]
                    [TestCase(new[] { 5, 4, 3, 2, 1, 0}, new[] { 49, 50, 50, 50, 50, 50 })]
                    [TestCase(new[] { 5, 4, 3, 2, 1, 0}, new[] { 50, 50, 50, 50, 50, 50 })]
                    public void WhenTheConcertIsInLessThanFiveDays(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }

                [TestFixture]
                public class BellowZero : TestBase
                {
                    [TestCase(new[] { 0, -1, -2, -3, -4 }, new[] { 30, 0, 0, 0, 0 })]
                    public void AfterTheConcert(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }
            }
        }

        [TestFixture]
        public class ForSulfuras : TestBase
        {
            private const string ItemName = "Sulfuras, Hand of Ragnaros";
            
            [TestCase(5, 5, new[] { 5, 5, 5, 5, 5 })]
            public void ShouldNeverUpdateSellIn(int sellIn, int quality, int[] expectedSellIns)
            {
                ExecuteSellInScenario(ItemName, sellIn, quality, expectedSellIns);
            }

            [TestCase(5, 5, new[] { 5, 5, 5 })]
            [TestCase(5, 80, new[] { 80, 80, 80 })]
            public void ShouldNeverUpdateQuality(int sellIn, int quality, int[] expectedQualities)
            {
                ExecuteQualityScenario(ItemName, sellIn, quality, expectedQualities);
            }
        }

        [TestFixture]
        public class StandardItemsSpecs : TestBase
        {
            private const string ItemName = "Eloxur";
            
            [TestFixture]
            public class ShouldDecreaseSellIn : TestBase
            {
                [TestFixture]
                public class ByOne : TestBase
                {
                    [TestCase(4, 5, new[] { 3, 2, 1, 0, -1, -2 })]
                    public void EveryDay(int sellIn, int quality, int[] expectedSellIns)
                    {
                        ExecuteSellInScenario(ItemName, sellIn, quality, expectedSellIns);
                    }
                }
            }

            [TestFixture]
            public class ShouldDecreaseQuality
            {
                [TestFixture]
                public class ByOne : TestBase
                {
                    [TestCase(new[] { 5, 4, 3, 2, 1, 0 }, new[] { 10, 9, 8, 7, 6, 5 })]
                    public void WhenTheSellByDateIsNotPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }

                [TestFixture]
                public class ByTwice : TestBase
                {
                    [TestCase(new[] { 0, -1, -2, -3, -4, -5 }, new[] { 10, 8, 6, 4, 2, 0 })]
                    public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }
            }

            [TestFixture]
            public class ShouldNotUpdateQuality
            {
                [TestFixture]
                public class BellowZero : TestBase
                {
                    [TestCase(new[] { 3, 2, 1, 0 }, new[] { 0, 0, 0, 0 })]
                    public void WhenTheSellByDateIsNotPassedYet(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                    
                    [TestCase(new[] { 0, -1, -2, -3 }, new[] { 0, 0, 0, 0 })]
                    [TestCase(new[] { 0, -1, -2, -3 }, new[] { 1, 0, 0, 0 })]
                    public void WhenTheSellByDateIsPassed(int[] expectedSellIns, int[] expectedQualities)
                    {
                        ExecuteScenario(ItemName, expectedSellIns, expectedQualities);
                    }
                }
            }
        }

        [TestFixture]
        public class NullItemsSpecs : TestBase
        {
            [Test]
            public void ShouldNotProcessNullItems()
            {
                itemsReaderSubstitute.ReadAll(Arg.Any<string>())
                    .Returns(new ItemsDto { Items = new List<ItemDto> { null } });

                application
                    .Invoking(app => app.UpdateQuality())
                    .Should().NotThrow();
            }
        }

        public class TestBase
        {
            protected GildedRose.Domain.Services.GildedRose application;
            protected ItemsReader itemsReaderSubstitute;
            private IItemRepository itemRepository;

            [SetUp]
            public void SetUp()
            {
                var appContainer = new ApplicationBootstrapper().InitContainer();
                
                itemsReaderSubstitute = Substitute.For<ItemsReader>();
                appContainer.Rebind<ItemsReader>().ToConstant(itemsReaderSubstitute).InSingletonScope();
                
                application = appContainer.Get<GildedRose.Domain.Services.GildedRose>();
                itemRepository = appContainer.Get<IItemRepository>();
            }

            protected void ExecuteSellInScenario(string itemName, int sellIn, int quality, int[] expectedSellIns)
            {
                var itemDto = new ItemDto
                {
                    Name = itemName,
                    SellIn = sellIn,
                    Quality = quality
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

            protected void ExecuteQualityScenario(string itemName, int sellIn, int quality, int[] expectedQualities)
            {
                var itemDto = new ItemDto
                {
                    Name = itemName,
                    SellIn = sellIn,
                    Quality = quality
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
            
            protected void ExecuteScenario(string itemName, int[] expectedSellIns, int[] expectedQualities)
            {
                expectedQualities.Length.Should().Be(expectedSellIns.Length, "Your scenario was expected to have as many SellIns as Qualities but wasn't");
                
                var itemDto = new ItemDto
                {
                    Name = itemName,
                    SellIn = expectedSellIns.First(),
                    Quality = expectedQualities.First()
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
