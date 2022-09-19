using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Services;
using Moq;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void ShouldReturnFalseOnUpdateQuality()
        {
            var item = new Item();
            var byBranchUpdaterMock = new Mock<ByBranchUpdater>();

            var wasUpdated = item.UpdateQualityUsing(byBranchUpdaterMock.Object);
            
            Assert.That(wasUpdated, Is.False);
        }
    }
    
    [TestFixture]
    public class AgedBrieTests
    {
        [Test]
        public void ShouldTriggerUpdaterOnUpdateQuality()
        {
            var agedBrie = new AgedBrie();
            var byBranchUpdaterMock = new Mock<ByBranchUpdater>();

            byBranchUpdaterMock.Setup(x => x.UpdateQuality(It.IsAny<AgedBrie>())).Verifiable();
            
            agedBrie.UpdateQualityUsing(byBranchUpdaterMock.Object);
            
            byBranchUpdaterMock.Verify(x => x.UpdateQuality(agedBrie), Times.Once);
        }
        
        [Test]
        public void ShouldReturnTrueOnUpdateQuality()
        {
            var agedBrie = new AgedBrie();
            var byBranchUpdaterMock = new Mock<ByBranchUpdater>();

            var wasUpdated = agedBrie.UpdateQualityUsing(byBranchUpdaterMock.Object);
            
            Assert.That(wasUpdated, Is.True);
        }
    }
}