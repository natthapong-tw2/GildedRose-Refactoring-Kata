using System.IO;
using FluentAssertions;
using GildedRose.Infrastructure.DataReaders;
using NUnit.Framework;

namespace GildedRoseTests.Infrastructure
{
    public class ItemsReaderTests
    {
        private ItemsReader testable;

        [OneTimeSetUp]
        public void PrepareFiles()
        {
            File.Copy("correctItems.json", "correctItemsA.json");
            File.Copy("withParseErrorItems.json", "withParseErrorItemsA.json");
        }

        [OneTimeTearDown]
        public void CleanFiles()
        {
            File.Delete("correctItemsA.json");
            File.Delete("withParseErrorItemsA.json");
        }
        
        [SetUp]
        public void SetUp()
        {
            testable = new ItemsReader();
        }
        
        [Test]
        public void ShouldReturnAllItemsFromFiles()
        {
            var items = testable.ReadAll("correctItemsA.json");

            items.Should().NotBeNull();
            items.Items.Should().NotBeNullOrEmpty();
            
            var agedBrie = items.Items[0];
            agedBrie.Name.Should().Be("Aged Brie");
            agedBrie.SellIn.Should().Be(2);
            agedBrie.Quality.Should().Be(0);
            
            var elixir = items.Items[1];
            elixir.Name.Should().Be("Elixir of the Mongoose");
            elixir.SellIn.Should().Be(5);
            elixir.Quality.Should().Be(7);
            
            var sulfuras = items.Items[2];
            sulfuras.Name.Should().Be("Sulfuras, Hand of Ragnaros");
            sulfuras.SellIn.Should().Be(0);
            sulfuras.Quality.Should().Be(80);
            
            var backstagePasses = items.Items[3];
            backstagePasses.Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            backstagePasses.SellIn.Should().Be(5);
            backstagePasses.Quality.Should().Be(49);
        }
        
        
        [Test]
        public void ShouldReturnEmptyListOneItemIsNull()
        {
            var items = testable.ReadAll("withParseErrorItemsA.json");

            items.Should().NotBeNull();
            items.Items.Should().NotBeNull();
            items.Items.Should().BeEmpty();
        }
    }
}