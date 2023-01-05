using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;
        public LogAnalyzer(ExtensionManagerFactory extensionManagerFactory)
        {
            manager = extensionManagerFactory.Create();
        }
        public bool IsValidLogFileName(string filename)
        {
            try
            {
                return manager.IsValid(filename);
            }
            catch
            {
                return false;
            }
        }
    }
    public class ExtensionManagerFactory
    {
        private IExtensionManager? customManager = null;
        public IExtensionManager Create()
        {
            if (customManager != null)
                return customManager;
            return new FileExtensionManager();
        }
        public void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
    public class FileExtensionManager : IExtensionManager
    {
        public bool WasLastFileNameValid { get; set; }
        public bool IsValid(string filename)
        {
            WasLastFileNameValid = false;
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("filename has to be provided");
            }
            if (!filename.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            WasLastFileNameValid = true;
            return true;
        }
    }
    public interface IExtensionManager
    {
        bool IsValid(string filename);
    }
}