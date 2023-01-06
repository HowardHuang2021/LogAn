using NUnit.Framework;

namespace LogAnMockWebService.UnitTests
{
    [TestFixture]
    public class LogAnMockWebServiceTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockWebService = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mockWebService);
            string tooShortFileName = "abc.ext";
            log.Analyzer(tooShortFileName);
            StringAssert.Contains("Filename too short:abc.ext", mockWebService.LastError);
        }
    }
}