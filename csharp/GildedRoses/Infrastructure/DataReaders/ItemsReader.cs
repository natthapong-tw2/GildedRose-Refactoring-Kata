using System;
using System.IO;
using csharp.GildedRoses.Infrastructure.DataModels;
using Newtonsoft.Json;

namespace csharp.GildedRoses.Infrastructure.DataReaders
{
    public class ItemsReader
    {
        public virtual ItemsDto ReadAll(string filePath)
        {
            try
            {
                var content = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<ItemsDto>(content);
            }
            catch (Exception exception)
            {
                return new ItemsDto();
            }
        }
    }
}