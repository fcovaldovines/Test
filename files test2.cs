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
    public class Pauseeeeeeee
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
        public void ThePauseeeeeeeeTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.Id("module-content")).Click();
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).Clear();
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).SendKeys("selenium picture 6");
            driver.FindElement(By.CssSelector("img.search-button-image")).Click();
            driver.FindElement(By.CssSelector("img[title=\"Details View\"]")).Click();
            driver.FindElement(By.CssSelector("div.view-detail > div > div.toolbar.icons > div.options-menu > a > img.downarrow")).Click();
            driver.FindElement(By.CssSelector("ul.ui-optionsmenu-ul li.ui-optionsmenu-li a.ui-optionsmenu-a img.download")).Click();
            driver.FindElement(By.CssSelector("div.view-detail > div > div.toolbar.icons > div.options-menu > a > img.downarrow")).Click();
            driver.FindElement(By.CssSelector("ul.ui-optionsmenu-ul li.ui-optionsmenu-li a.ui-optionsmenu-a img.download")).Click();
            driver.FindElement(By.CssSelector("img[title=\"Thumbnails View\"]")).Click();
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
