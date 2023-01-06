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

            ExtensionManagerFactory extensionManagerFactory = new ExtensionManagerFactory();
            extensionManagerFactory.SetManager(myFakeManager);

            LogAnalyzer log = new LogAnalyzer(extensionManagerFactory);
            bool result = log.IsValidLogFileName("short.ext");
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("this if fake");

            ExtensionManagerFactory extensionManagerFactory = new ExtensionManagerFactory();
            extensionManagerFactory.SetManager(myFakeManager);

            LogAnalyzer log = new LogAnalyzer(extensionManagerFactory);
            bool result = log.IsValidLogFileName("anything.anyextension");
            Assert.IsFalse(result);
        }
    }
    [TestFixture]
    public class LogAnalyzerUsingFactoryMethodTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;

            TestableLogAnalyzer log = new TestableLogAnalyzer(myFakeManager);
            bool result = log.IsValidLogFileName("short.ext");
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("this if fake");

            TestableLogAnalyzer log = new TestableLogAnalyzer(myFakeManager);
            bool result = log.IsValidLogFileName("anything.anyextension");
            Assert.IsFalse(result);
        }
    }
    class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        public TestableLogAnalyzer(IExtensionManager mgr)
        {
            Manager = mgr;
        }
        public IExtensionManager Manager;
        protected override IExtensionManager GetManager()
        {
            return Manager;
        }
    }
    [TestFixture]
    public class LogAnalyzerUsingFactoryMethodWithoutInterfaceTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            TestableLogAnalyzerWithoutInterface log = new TestableLogAnalyzerWithoutInterface();
            log.WillBeValid = true;
            bool result = log.IsValidLogFileName("short.ext");
            Assert.IsTrue(result);
        }
        [Test]
        public void isvalidfilename_extmanagerthrowsexception_returnsfalse()
        {
            TestableLogAnalyzerWithoutInterface log = new TestableLogAnalyzerWithoutInterface();
            log.WillThrow = new Exception("this if fake");
            bool result = log.IsValidLogFileName("anything.anyextension");
            Assert.IsFalse(result);
        }
    }
    class TestableLogAnalyzerWithoutInterface : LogAnalyzerUsingFactoryMethodWithoutInterface
    {
        public bool WillBeValid;
        public Exception? WillThrow = null;
        protected override bool IsValid(string filename)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            return WillBeValid;
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