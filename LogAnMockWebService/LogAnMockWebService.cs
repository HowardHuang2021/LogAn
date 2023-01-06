namespace LogAnMockWebService
{
    public interface IWebService
    {
        void LogError(string message);
    }
    public class FakeWebService : IWebService
    {
        public string LastError;
        public void LogError(string message)
        {
            LastError = message;
        }
    }
    public class LogAnalyzer
    {
        private IWebService service;
        public LogAnalyzer(IWebService service)
        {
            this.service = service;
        }
        public void Analyzer(string fileName)
        {
            if (fileName.Length < 8)
            {
                service.LogError("Filename too short:"
                    + fileName);
            }
        }
    }
}