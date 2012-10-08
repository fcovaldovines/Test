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
    public class Deltetetetete
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
        public void TheDelteteteteteTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.CssSelector("a > img")).Click();
            driver.FindElement(By.CssSelector("li.find > a > span")).Click();
            driver.FindElement(By.CssSelector("#navigation-saved-search-link > span")).Click();
            driver.FindElement(By.LinkText("dited")).Click();
            driver.FindElement(By.CssSelector("img[title=\"Delete\"]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [getAlert]]
            driver.FindElement(By.CssSelector("#navigation-saved-search-link > span")).Click();
            driver.FindElement(By.CssSelector("img[title=\"Delete this Saved Search\"]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow]]
            driver.FindElement(By.Id("fbInspectButton")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow]]
            // ERROR: Caught exception [ERROR: Unsupported command [getConfirmation]]
            driver.FindElement(By.CssSelector("a > img")).Click();
            driver.FindElement(By.CssSelector("a > img")).Click();
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
