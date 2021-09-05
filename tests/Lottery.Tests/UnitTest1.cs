using Lottery.CrossCutting.FileParser;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Lottery.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var fileParser = new FileParser(new FileStream(@"D:\temp\chipart\sorteio-upgrade-chipart-e-pcyes_export.csv", FileMode.Open));
            foreach (var item in fileParser.GetRows())
            {
                System.Diagnostics.Debug.WriteLine(item);
            };
        }
    }
}
