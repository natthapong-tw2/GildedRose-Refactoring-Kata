using csharp.GildedRoses.Infrastructure.DataModels;
using csharp.GildedRoses.Infrastructure.DataReaders;
using Moq;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public class ItemReaderTests
    {
        private Mock<FileReader> fileReaderMock;
        private Mock<ItemsDtoConverter> itemsDtoConverterMock;
        
        private ItemsReader testable;

        [SetUp]
        public void SetUp()
        {
            fileReaderMock = new Mock<FileReader>();
            itemsDtoConverterMock = new Mock<ItemsDtoConverter>();
            
            testable = new ItemsReader(fileReaderMock.Object, itemsDtoConverterMock.Object);
        }

        [Test]
        public void ShouldReadAllItemsFromAFile()
        {
            const string expectedFilePass = "anyFilePath";
            
            // Be aware that by using IsAny everywhere, the test could be a false positive and may betrayed us one day
            fileReaderMock.Setup(x => x.Read(It.IsAny<string>())).Verifiable();
            itemsDtoConverterMock.Setup(x => x.Convert(It.IsAny<string>())).Returns(new ItemsDto());

            testable.ReadAll(expectedFilePass);
            
            fileReaderMock.Verify(x => x.Read(expectedFilePass), Times.Once);
        }
        
    }
}