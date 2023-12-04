using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Tests.SeleniumTests
{
    [TestClass]
    public class SeleniumTests
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void GetTitleHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            Assert.AreEqual(_driver.Title, "Web form");

            _driver.Quit();
        }

        [TestMethod]
        public void EightComponents()
        {
            _driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            var title = _driver.Title;
            Assert.AreEqual("Web form", title);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var textBox = _driver.FindElement(By.Name("my-text"));
            var submitButton = _driver.FindElement(By.TagName("button"));

            textBox.SendKeys("Selenium");
            submitButton.Click();

            var message = _driver.FindElement(By.Id("message"));
            var value = message.Text;
            Assert.AreEqual("Received!", value);

            _driver.Quit();
        }
    }
}
