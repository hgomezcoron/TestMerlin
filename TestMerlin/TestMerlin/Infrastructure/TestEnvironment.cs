using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CreateObjectAfterFieldParsing.Infrastructure
{
    class TestEnvironment : IDisposable
    {
        public static TestEnvironment Instance => _instance.Value;
        private static Lazy<TestEnvironment> _instance = new Lazy<TestEnvironment>(() => new TestEnvironment());

        public IWebDriver Driver { get; }

        private TestEnvironment()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected internal void Dispose(bool disposing)
        {
            Driver.Close();
            Driver.Dispose();
        }

        ~TestEnvironment()
        {
            Dispose(false);
        }
    }
}
