using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace PlanningsTool.Tests.SeleniumTests
{
    public class SeleniumTests
    {
        [Test]
        public void GetTitleHomePage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:3000/");

            Assert.That(driver.Title, Is.EqualTo("React App"));

            driver.Quit();
        }
    }
}
