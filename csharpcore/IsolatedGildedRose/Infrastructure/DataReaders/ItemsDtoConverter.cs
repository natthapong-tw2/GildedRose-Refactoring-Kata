using IsolatedTests.GildedRose.Infrastructure.DataModels;
using Newtonsoft.Json;

namespace IsolatedTests.GildedRose.Infrastructure.DataReaders
{
    public class ItemsDtoConverter
    {
        public virtual ItemsDto Convert(string content)
        {
            return JsonConvert.DeserializeObject<ItemsDto>(content);
        }
    }
}