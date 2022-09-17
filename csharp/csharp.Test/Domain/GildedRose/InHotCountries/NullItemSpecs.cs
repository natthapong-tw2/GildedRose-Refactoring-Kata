using System.Collections.Generic;
using csharp.GildedRoses.Infrastructure.DataModels;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace csharp.Test
{
    [TestFixture]
    public partial class GildedRoseSpecs
    {
        [TestFixture]
        public partial class InHotCountries
        {
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
        }
    }
}
