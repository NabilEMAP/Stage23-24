using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PlanningsTool.Tests.SeleniumTests.HomeTests
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
        public void HomeTest_ST01_GetTitleHomePage()
        {
            _driver.Navigate().GoToUrl(_URL);
            Assert.AreEqual(_title, _driver.Title);
            _driver.Quit();
        }

        public void GoToContainer(string container)
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            _driver.FindElement(By.XPath($"//h2[normalize-space()='{container}']")).Click();
        }

        [TestMethod]
        public void HomeTest_ST02_GoToContainerNurse()
        {
            GoToContainer("Zorgkundige");
            Assert.AreEqual(_URL + "zorgkundige", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST03_GoToContainerVacation()
        {
            GoToContainer("Verlof");
            Assert.AreEqual(_URL + "verlof", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST04_GoToContainerNurseShift()
        {
            GoToContainer("Shift");
            Assert.AreEqual(_URL + "shift", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST05_GoToContainerPlanning()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("btnPlanning")).Click();
            Assert.AreEqual(_URL + "teamplanning", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST06_NavigateToPlanning()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navPlanning")).Click();
            Assert.AreEqual(_URL + "teamplanning", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST07_NavigateToNurse()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navNurse")).Click();
            Assert.AreEqual(_URL + "zorgkundige", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST08_NavigateToVacation()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navVacation")).Click();
            Assert.AreEqual(_URL + "verlof", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST09_NavigateToNurseShift()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navNurseShift")).Click();
            Assert.AreEqual(_URL + "shift", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST10_NavigateToRegimeType()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navRegimeType")).Click();
            Assert.AreEqual(_URL + "regimetype", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST11_NavigateToVacationType()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navVacationType")).Click();
            Assert.AreEqual(_URL + "verloftype", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST12_NavigateToShiftType()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navShiftType")).Click();
            Assert.AreEqual(_URL + "shifttype", _driver.Url);
            _driver.Quit();
        }

        [TestMethod]
        public void HomeTest_ST13_NavigateToHoliday()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navHoliday")).Click();
            Assert.AreEqual(_URL + "feestdag", _driver.Url);
            _driver.Quit();
        }
    }
}
