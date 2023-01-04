using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            LogAnalyzer log = new LogAnalyzer(myFakeManager);
            bool result = log.IsValidLogFileName("short.ext");
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("this if fake");
            LogAnalyzer log = new LogAnalyzer(myFakeManager);
            bool result = log.IsValidLogFileName("anything.anyextension");
            Assert.IsFalse(result);
        }
    }
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public Exception? WillThrow = null;
        public bool IsValid(string filename)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            return WillBeValid;
        }
    }
}