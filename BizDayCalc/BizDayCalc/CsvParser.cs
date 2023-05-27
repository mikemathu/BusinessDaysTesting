using CsvHelper;
using System.Reflection.Metadata;
using Xunit;

namespace CsvParserTests
{
    public class CsvReaderTest : IDisposable 
    {
        private StreamReader streamReader;
        private CsvReader csvReader;

        //you open a file in the constructor so that it can be used by each test method.
        //You then close that file in the Dispose method, which will keep you from leaking  open file handles.
        public CsvReaderTest()
        {
            streamReader = new StreamReader(new FileStream("Marvel.csv", FileMode.Open));
            csvReader = new CsvReader((IParser)streamReader);
        }
        // Using Dispose for cleanup/closing
        public void Dispose()
        {
            streamReader.Dispose();
        }

        [Fact]
        public void VerifyNumberOfLines()
        {
          /*  Assert.Equal(7, CsvReader.Lines.Count());*/
        }
    } 
}

