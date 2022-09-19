using csharp.GildedRoses.Infrastructure.DataModels;

namespace csharp.GildedRoses.Infrastructure.DataReaders
{
    public class ItemsReader
    {
        /*
         Be aware that it may be as efficient to create the infrastructure test at this level without splitting the behaviour
         */
        private readonly FileReader fileReader;
        private readonly ItemsDtoConverter itemsDtoConverter;

        public ItemsReader() {}
        public ItemsReader(FileReader fileReader, ItemsDtoConverter itemsDtoConverter)
        {
            this.fileReader = fileReader;
            this.itemsDtoConverter = itemsDtoConverter;
        }
        
        /*
         Be aware that function are made virtual just for test purpose,
         otherwise we will have to create an interface even so we have no plan to create another implementation
         */
        public virtual ItemsDto ReadAll(string filePath)
        {
            var content = fileReader.Read(filePath);
            return itemsDtoConverter.Convert(content);
        }
    }
}