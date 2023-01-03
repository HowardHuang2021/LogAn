using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_GoodExtenstion_ReturnTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithgoodextenstion.slf");
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidLogFileName_BadExtenstion_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextenstion.foo");
            Assert.IsFalse(result);
        }
    }
}