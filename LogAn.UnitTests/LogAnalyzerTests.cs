using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            LogAnalyzer la = MakeAnalyzer();
            Exception? ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));
            StringAssert.Contains("filename has to be provided", ex.Message);
        }
        [TestCase("filewithgoodextenstion.slf", true)]
        [TestCase("filewithgoodextenstion.SLF", true)]
        [TestCase("filewithbadextenstion.foo", false)]
        public void IsValidLogFileName_VariousExtenstions_ChecksThem(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();
            bool result = la.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}