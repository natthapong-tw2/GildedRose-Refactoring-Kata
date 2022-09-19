using csharp.GildedRoses.Infrastructure.DataModels;
using Newtonsoft.Json;

namespace csharp.GildedRoses.Infrastructure.DataReaders
{
    public class ItemsDtoConverter
    {
        public virtual ItemsDto Convert(string content)
        {
            return JsonConvert.DeserializeObject<ItemsDto>(content);
        }
    }
}