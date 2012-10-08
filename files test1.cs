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
    public class SavedSearch
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
        public void TheSavedSearchTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.CssSelector("div.scroll")).Click();
            driver.FindElement(By.CssSelector("li.find > a > span")).Click();
            driver.FindElement(By.CssSelector("#navigation-saved-search-link > span")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("" == driver.FindElement(By.XPath("(//img[@title='Delete this Saved Search'])[3]")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [chooseCancelOnNextConfirmation]]
            driver.FindElement(By.XPath("(//img[@title='Delete this Saved Search'])[3]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [getConfirmation]]
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("" == driver.FindElement(By.XPath("(//img[@title='Delete this Saved Search'])[3]")).Text) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("(//img[@title='Delete this Saved Search'])[3]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [getConfirmation]]
            driver.FindElement(By.CssSelector("#navigation-saved-search-link > span")).Click();
            driver.FindElement(By.XPath("//div[@id='navigation-left-accordion']/div[4]/h3")).Click();
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
