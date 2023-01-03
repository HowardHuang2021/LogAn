using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TestCase("filewithgoodextenstion.slf")]
        [TestCase("filewithgoodextenstion.SLF")]
        public void IsValidLogFileName_ValidExtenstions_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidLogFileName_BadExtenstion_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextenstion.foo");
            Assert.IsFalse(result);
        }
    }
}