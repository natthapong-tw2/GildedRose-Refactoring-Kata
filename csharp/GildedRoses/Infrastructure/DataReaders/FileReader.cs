using System.IO;

namespace csharp.GildedRoses.Infrastructure.DataReaders
{
    public class FileReader
    {
        public virtual string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}