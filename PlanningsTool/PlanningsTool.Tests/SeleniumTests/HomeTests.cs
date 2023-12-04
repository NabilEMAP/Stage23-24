using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Tests.SeleniumTests
{
    [TestClass]
    public class HomeTests
    {
        private IWebDriver _driver;
        private string _URL;
        private string _title;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/";
            _title = "React App";
        }

        [TestMethod]
        public void GetTitleHomePage()
        {
            _driver.Navigate().GoToUrl(_URL);
            Assert.AreEqual(_title, _driver.Title);
            _driver.Quit();
        }

        public void NavigateToContainer(string container)
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            var submitButton = _driver.FindElement(By.XPath($"//h2[normalize-space()='{container}']"));
            submitButton.Click();
        }
    }
}
