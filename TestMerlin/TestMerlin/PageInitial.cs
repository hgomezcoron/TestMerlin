using CreateObjectAfterFieldParsing.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMerlin
{
    class PageInitial
    {
        private IWebDriver driver => TestEnvironment.Instance.Driver;

        public PageInitial()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
            //PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://merlin-qa.appspot.com");
        }
    }
}
