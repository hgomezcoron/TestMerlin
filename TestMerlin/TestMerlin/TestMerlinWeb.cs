using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestMerlin
{
    [TestFixture]
    public class TestMerlinWeb
    {
        Helper helper = new Helper();

        [SetUp]
        public void Setup()
        {
            PageInitial home = new PageInitial();
            home.GoToPage();
        }

        [Test]
        [Category("Validate Field Ingresa tu número de móvil")]
        public void SendNumber()
        {
            helper.ValidateFieldMobileNumber();
        }

        [Test]
        [Category ("Validate environment")]
        public void ValidateEnvironment()
        {
            helper.ValidateEnvironment();
        }

        [Test]
        [Category("Validate flow login")]
        public void Login()
        {
            helper.Login();
        }

        [Test]
        [Category("Validate flow create account")]
        public void CreateAccount()
        {
            helper.CreateAccount();
        }

        [Test]
        [Category("Validate flow send a question")]
        public void StillHaveQuestion()
        {
            helper.StillHaveQuestion();
        }

        [Test]
        [Category("Validate flow Link AppStore")]
        public void ValidateAppStore()
        {
            helper.ValidateAppStore();
        }

        [Test]
        [Category("Validate Link PlayStore")]
        public void ValidatePlayStore()
        {
            helper.ValidatePlayStore();
        }
    }
}
