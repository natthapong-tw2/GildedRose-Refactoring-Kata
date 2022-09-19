using System.IO;

namespace IsolatedTests.GildedRose.Infrastructure.DataReaders
{
    public class FileReader
    {
        public virtual string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}