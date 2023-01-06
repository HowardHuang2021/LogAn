namespace LogAnMockWebService
{
    public interface IWebService
    {
        void LogError(string message);
    }
    public class FakeWebService : IWebService
    {
        public string LastError;
        public Exception ToThrow;
        public void LogError(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }
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
                service.LogError("Filename too short:" + fileName);
            }
        }
    }
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
    public class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;
        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
    public class LogAnalyzer2
    {
        public LogAnalyzer2(IWebService service, IEmailService email)
        {
            Service = service;
            Email = email;
        }
        public IWebService Service
        {
            get;
            set;
        }
        public IEmailService Email
        {
            get;
            set;
        }
        public void Analyzer(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("Filename too short:" + fileName);
                }
                catch (Exception ex)
                {
                    Email.SendEmail("someone@somewhere.com", "can't log", ex.Message);
                }
            }
        }
    }
}