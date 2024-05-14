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

        /// <summary>
        /// GetTitleHomePage
        /// </summary>
        [TestMethod]
        public void ST_HP_01_01()
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

        /// <summary>
        /// GoToContainerNurse
        /// </summary>
        [TestMethod]
        public void ST_HP_01_02()
        {
            GoToContainer("Zorgkundige");
            Assert.AreEqual(_URL + "zorgkundige", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// GoToContainerVacation
        /// </summary>
        [TestMethod]
        public void ST_HP_01_03()
        {
            GoToContainer("Verlof");
            Assert.AreEqual(_URL + "verlof", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// GoToContainerNurseShift
        /// </summary>
        [TestMethod]
        public void ST_HP_01_04()
        {
            GoToContainer("Shift");
            Assert.AreEqual(_URL + "shift", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// GoToContainerPlanning
        /// </summary>
        [TestMethod]
        public void ST_HP_01_05()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("btnPlan")).Click();
            Assert.AreEqual(_URL + "plan", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToPlanning
        /// </summary>
        [TestMethod]
        public void ST_HP_01_06()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navPlan")).Click();
            Assert.AreEqual(_URL + "plan", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToNurse
        /// </summary>
        [TestMethod]
        public void ST_HP_01_07()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navNurse")).Click();
            Assert.AreEqual(_URL + "zorgkundige", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToVacation
        /// </summary>
        [TestMethod]
        public void ST_HP_01_08()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navVacation")).Click();
            Assert.AreEqual(_URL + "verlof", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToNurseShift
        /// </summary>
        [TestMethod]
        public void ST_HP_01_09()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("navNurseShift")).Click();
            Assert.AreEqual(_URL + "shift", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToRegimeType
        /// </summary>
        [TestMethod]
        public void ST_HP_01_10()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navRegimeType")).Click();
            Assert.AreEqual(_URL + "regimetype", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToVacationType
        /// </summary>
        [TestMethod]
        public void ST_HP_01_11()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navVacationType")).Click();
            Assert.AreEqual(_URL + "verloftype", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToShiftType
        /// </summary>
        [TestMethod]
        public void ST_HP_01_12()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navShiftType")).Click();
            Assert.AreEqual(_URL + "shifttype", _driver.Url);
            _driver.Quit();
        }

        /// <summary>
        /// NavigateToHoliday
        /// </summary>
        [TestMethod]
        public void ST_HP_01_13()
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.FindElement(By.Id("types-button")).Click();
            _driver.FindElement(By.Id("navHoliday")).Click();
            Assert.AreEqual(_URL + "feestdag", _driver.Url);
            _driver.Quit();
        }
    }
}