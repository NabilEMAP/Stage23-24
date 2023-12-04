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
    public class VacationTests
    {
        private IWebDriver _driver;
        private string _URL;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/";
        }

        public void NavigateToContainer(string container)
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            var submitButton = _driver.FindElement(By.XPath($"//h2[normalize-space()='{container}']"));
            submitButton.Click();
        }

        [TestMethod]
        public void NavigateFromHomePageToNurseShiftPage()
        {
            NavigateToContainer("Verlof");
            _driver.Quit();
        }
    }
}
