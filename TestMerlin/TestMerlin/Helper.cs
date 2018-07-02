using CreateObjectAfterFieldParsing.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMerlin
{
    class Helper
    {
        private IWebDriver driver => TestEnvironment.Instance.Driver;
        public Helper()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "home-initial-popup-candidate")]
        public IWebElement BtnFindJobs { get; set; }

        [FindsBy(How = How.Id, Using = "home-initial-popup-employer")]
        public IWebElement BtnEmployers { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement FieldEmail{ get; set; }

        [FindsBy(How = How.Id, Using = "password1")]
        public IWebElement FieldPassword { get; set; }

        [FindsBy(How = How.Id, Using = "create")]
        public IWebElement BtnLogIn { get; set; }

        [FindsBy(How = How.Name, Using = "user_name")]
        public IWebElement FieldNameQuestion { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement FieldEmailQuestion { get; set; }

        [FindsBy(How = How.Name, Using = "subject")]
        public IWebElement FieldSubjectQuestion { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/ui-view/merl-home-main/div[1]/section[7]/div/form/div[3]/button")]
        public IWebElement BtnSendQuestion { get; set; }

        [FindsBy(How = How.Id, Using = "company_name")]
        public IWebElement FieldCompanyName { get; set; }

        [FindsBy(How = How.Id, Using = "first_last_name")]
        public IWebElement FieldFullName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement FieldPasswordCreateAccount { get; set; }

        [FindsBy(How = How.Id, Using = "recaptcha-anchor")]
        public IWebElement Captcha { get; set; }

        //verifica que un elemento esté presente en el DOM de una página y sea visible.Tiene que ser visible
        public IWebElement WaitForPageUntilElementIsVisible(By locator, int maxSeconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxSeconds))
                .Until(ExpectedConditions.ElementIsVisible((locator)));
        }

        public void ValidateFieldMobileNumber()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnFindJobs.Click();
            IList<IWebElement> AllInput = driver.FindElements(By.TagName("input"));
            foreach (var item in AllInput)
            {
                if ("Ingresa tu número de móvil".Equals(item.GetAttribute("placeholder")))
                {
                    item.SendKeys("1234567890");
                    break;
                }
            }
            IList<IWebElement> AllSpan = driver.FindElements(By.TagName("span"));
            foreach (var item in AllSpan)
            {
                if ("\r\n                        Enviar\r\n                      ".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                    Assert.AreEqual("\r\n                        Reenviar\r\n                      ", "\r\n                        Reenviar\r\n                      ");
                    break;
                }
            }
        }

        public void ValidateEnvironment()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnFindJobs.Click();
            IWebElement element = driver.FindElement(By.Id("first-fold"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            IList<IWebElement> AllSpan = driver.FindElements(By.TagName("span"));
            foreach (var item in AllSpan)
            {
                if ("Ventas al detal".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                }
                if ("Restaurantes y Hospitalidad".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                }
                if ("Transporte".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                }
                if ("Ventas y Servicio al Cliente".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                }
                if ("Administración y Oficinas".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                    break;
                }
            }
        }

        public void ValidateAppStore()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnFindJobs.Click();
            LinkAppStore.Click();
            String Actualtext = driver.FindElement(By.Id("ember589")).GetAttribute("class");
            Assert.AreEqual(Actualtext, "product-hero__artwork we-artwork--fullwidth we-artwork--ios-app-icon we-artwork ember-view");
        }

        public void ValidatePlayStore()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnFindJobs.Click();
            LinkPlatStore.Click();
            String Actualtext = driver.FindElement(By.ClassName("AHFaub")).GetAttribute("itemprop");
            Assert.AreEqual(Actualtext, "name");
        }
        [FindsBy(How = How.XPath, Using = "/html/body/ui-view/merl-home-main/div[1]/div[1]/section/div/div/div[2]/div/div[2]/div[1]/a")]
        public IWebElement LinkAppStore { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/ui-view/merl-home-main/div[1]/div[1]/section/div/div/div[2]/div/div[2]/div[2]/a/img")]
        public IWebElement LinkPlatStore { get; set; }

        public void Login()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnEmployers.Click();
            Thread.Sleep(1000);
            IList<IWebElement> AllA = driver.FindElements(By.TagName("a"));
            foreach (var item in AllA)
            {
                if ("I already have an account".Equals(item.GetAttribute("innerHTML")))
                {
                    item.Click();
                    break;
                }
            }
            FieldEmail.Clear();
            FieldEmail.SendKeys("home@gmail.com");
            FieldPassword.Clear();
            FieldPassword.SendKeys("homehome");
            WaitForPageUntilElementIsVisible(By.Id("create"), 10);
            BtnLogIn.Click();
            IList<IWebElement> AllDiv = driver.FindElements(By.TagName("div"));
            foreach (var item in AllDiv)
            {
                if ("Home Home".Equals(item.GetAttribute("innerHTML")))
                {
                    Assert.AreEqual("home home", item.GetAttribute("innerHTML"));
                    break;
                }
            }
        }

        //se intento automatizar la opcion de crear un cuenta, pero no se puede realizar
        //el flujo ya que tiene opcion de captcha y este funciona para verificar que eres
        //una persona y no una maquina
        public void CreateAccount()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnEmployers.Click();
            Thread.Sleep(1000);
            FieldCompanyName.SendKeys("Test 1");
            FieldFullName.SendKeys("Test");
            FieldEmail.SendKeys("Test@test.com");
            FieldPasswordCreateAccount.SendKeys("1234567890");
            driver.SwitchTo().Frame(2);
            Debug.Write(driver.PageSource);
            Captcha.Click();
            driver.SwitchTo().DefaultContent();
            BtnLogIn.Click();
        }

        public void StillHaveQuestion()
        {
            WaitForPageUntilElementIsVisible(By.Id("home-initial-popup-candidate"), 10);
            BtnFindJobs.Click();
            IWebElement element = driver.FindElement(By.Name("user_name"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            FieldNameQuestion.Clear();
            FieldNameQuestion.SendKeys("user numer 1");
            FieldEmailQuestion.Clear();
            FieldEmailQuestion.SendKeys("userx@gmail.com");
            FieldSubjectQuestion.Clear();
            FieldSubjectQuestion.SendKeys("este mensaje es una prueba de automatizacion");
            BtnSendQuestion.Click();
        }
    }
}
