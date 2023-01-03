using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TestCase("filewithgoodextenstion.slf", true)]
        [TestCase("filewithgoodextenstion.SLF", true)]
        [TestCase("filewithbadextenstion.foo", false)]
        public void IsValidLogFileName_VariousExtenstions_ChecksThem(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }
    }
}