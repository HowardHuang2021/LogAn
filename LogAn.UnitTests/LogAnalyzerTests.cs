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