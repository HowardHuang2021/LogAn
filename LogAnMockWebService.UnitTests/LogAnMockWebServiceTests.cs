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
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyzer_WebServiceThrows_SendsEmail()
        {
            FakeWebService mockWebService = new FakeWebService();
            mockWebService.ToThrow = new Exception("fake exception");
            FakeEmailService mockEmail = new FakeEmailService();
            LogAnalyzer2 log = new LogAnalyzer2(mockWebService, mockEmail);
            string tooShortFileName = "abc.ext";
            log.Analyzer(tooShortFileName);
            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("can't log", mockEmail.Subject);
            StringAssert.Contains("fake exception", mockEmail.Body);
        }
    }
}