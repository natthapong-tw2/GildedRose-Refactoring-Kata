using System.Collections.Generic;
using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Repositories;
using csharp.GildedRoses.Domain.Services;
using Moq;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public class GildedRoseTests 
    {
        private Mock<AgedBrieUpdater> agedBrieUpdaterMock;
        private Mock<BackstagePassesUpdater> backstagePassesUpdaterMock;
        private Mock<SulfurasUpdater> sulfurasUpdaterMock;
        private Mock<StandardItemUpdater> standardItemUpdaterMock;
        private Mock<IItemRepository> itemRepositoryMock;

        private GildedRose testable;

        [SetUp]
        public void Setup()
        {
            agedBrieUpdaterMock = new Mock<AgedBrieUpdater>();
            backstagePassesUpdaterMock = new Mock<BackstagePassesUpdater>();
            sulfurasUpdaterMock = new Mock<SulfurasUpdater>();
            standardItemUpdaterMock = new Mock<StandardItemUpdater>();
            itemRepositoryMock = new Mock<IItemRepository>();
            
            testable = new GildedRose(
                agedBrieUpdaterMock.Object, 
                backstagePassesUpdaterMock.Object, 
                sulfurasUpdaterMock.Object,
                standardItemUpdaterMock.Object, 
                itemRepositoryMock.Object);
        }

        [Test]
        public void ShouldLoadAllItems()
        {
            itemRepositoryMock.Setup(x => x.GetAll())
                .Returns(new List<Item>())
                .Verifiable();
            
            testable.UpdateQuality();

            itemRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldUseAgedBrieUpdaterIfTheItemIsAgedBrie()
        {
            var item = new Item();
            itemRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> { item });
            
            agedBrieUpdaterMock.Setup(x => x.IsSatisfiedBy(item)).Returns(true);
            agedBrieUpdaterMock.Setup(x => x.UpdateQuality(item)).Verifiable();
            
            testable.UpdateQuality();

            agedBrieUpdaterMock.Verify(x => x.UpdateQuality(item), Times.Once);
        }
        
        [Test]
        public void ShouldUseBackstagePassesUpdaterIfTheItemIsBackstagePasses()
        {
            var item = new Item();
            itemRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> { item });
            
            backstagePassesUpdaterMock.Setup(x => x.IsSatisfiedBy(item)).Returns(true);
            backstagePassesUpdaterMock.Setup(x => x.UpdateQuality(item)).Verifiable();
            
            testable.UpdateQuality();

            backstagePassesUpdaterMock.Verify(x => x.UpdateQuality(item), Times.Once);
        }
        
        [Test]
        public void ShouldUseSulfurasUpdaterIfTheItemIsSulfuras()
        {
            var item = new Item();
            itemRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> { item });
            
            sulfurasUpdaterMock.Setup(x => x.IsSatisfiedBy(item)).Returns(true);
            sulfurasUpdaterMock.Setup(x => x.UpdateQuality(item)).Verifiable();
            
            testable.UpdateQuality();

            sulfurasUpdaterMock.Verify(x => x.UpdateQuality(item), Times.Once);
        }
        
        [Test]
        public void ShouldUseStandardItemUpdaterIfTheItemIsStandard()
        {
            // Be aware that because the IsSatisfiedBy is stub, the properties of the item are no relevant in this test
            var item = new Item();
            itemRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> { item });
            
            standardItemUpdaterMock.Setup(x => x.IsSatisfiedBy(item)).Returns(true);
            standardItemUpdaterMock.Setup(x => x.UpdateQuality(item)).Verifiable();
            
            testable.UpdateQuality();

            standardItemUpdaterMock.Verify(x => x.UpdateQuality(item), Times.Once);
        }
        
        [Test]
        public void ShouldSkipNullItems()
        {
            itemRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> { null });
            
            agedBrieUpdaterMock.Setup(x => x.IsSatisfiedBy(null)).Verifiable();
            backstagePassesUpdaterMock.Setup(x => x.IsSatisfiedBy(null)).Verifiable();
            sulfurasUpdaterMock.Setup(x => x.IsSatisfiedBy(null)).Verifiable();
            standardItemUpdaterMock.Setup(x => x.IsSatisfiedBy(null)).Verifiable();
            
            testable.UpdateQuality();

            agedBrieUpdaterMock.Verify(x => x.IsSatisfiedBy(null), Times.Never);
            backstagePassesUpdaterMock.Verify(x => x.IsSatisfiedBy(null), Times.Never);
            sulfurasUpdaterMock.Verify(x => x.IsSatisfiedBy(null), Times.Never);
            standardItemUpdaterMock.Verify(x => x.IsSatisfiedBy(null), Times.Never);
        }
    }
}
