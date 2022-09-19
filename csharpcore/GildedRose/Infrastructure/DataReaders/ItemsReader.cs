using System;
using System.IO;
using Newtonsoft.Json;
using SafetyNet.GildedRose.Infrastructure.DataModels;

namespace SafetyNet.GildedRose.Infrastructure.DataReaders
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