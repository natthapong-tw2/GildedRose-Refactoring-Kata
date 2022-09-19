using System.Collections.Generic;
using FluentAssertions;
using IsolatedTests.GildedRose.Infrastructure.DataModels;
using IsolatedTests.GildedRose.Infrastructure.DataReaders;
using IsolatedTests.GildedRose.Infrastructure.Repositories;
using Moq;
using NUnit.Framework;

namespace IsolatedTests.GildedRoseTests
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        private Mock<ItemsReader> itemsReaderMock;
        
        private ItemRepository testable;

        [SetUp]
        public void Setup()
        {
            itemsReaderMock = new Mock<ItemsReader>();
            
            testable = new ItemRepository(itemsReaderMock.Object);
        }

        [Test]
        public void ShouldReadAllObjects()
        {
            itemsReaderMock.Setup(x => x.ReadAll(It.IsAny<string>()))
                .Returns(new ItemsDto{ Items = new List<ItemDto>() })
                .Verifiable();

            testable.GetAll();
            
            itemsReaderMock.Verify(x => x.ReadAll(It.IsAny<string>()), Times.Once);
        }
        
        [Test]
        public void ShouldCreateItemsForEachItem()
        {
            var firstItem = new ItemDto();
            var secondItem = new ItemDto();
            
            itemsReaderMock.Setup(x => x.ReadAll(It.IsAny<string>()))
                .Returns(new ItemsDto{ Items = new List<ItemDto> { firstItem, secondItem} })
                .Verifiable();

            var items = testable.GetAll();

            items.Should().NotBeNullOrEmpty();
            items.Should().HaveCount(2);
        }
    }
}