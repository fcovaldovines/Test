using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Logintest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://eagl-qa.spe.sony.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheLoginTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/siteminderagent/forms/EAGL/login.fcc?TYPE=33554433&REALMOID=06-e4d66de5-2e36-1138-aa5b-83f810a10cb3&GUID=&SMAUTHREASON=0&METHOD=GET&SMAGENTNAME=-SM-QR4ObLrnYWKnCehuc3h59TrEkSH8brhiriTPB6%2b%2fme3jkY3e62wTJzry8pjR5szM&TARGET=-SM-https%3a%2f%2feagl--qa%2espe%2esony%2ecom%2f");
            driver.FindElement(By.Id("USER")).Clear();
            driver.FindElement(By.Id("USER")).SendKeys("TDrift");
            driver.FindElement(By.Id("PASSWORD")).Clear();
            driver.FindElement(By.Id("PASSWORD")).SendKeys("5JIKJR");
            driver.FindElement(By.Id("LOGIN")).Click();
            driver.FindElement(By.CssSelector("a > img")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
