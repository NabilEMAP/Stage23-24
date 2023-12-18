using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.ComponentModel;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace PlanningsTool.Tests.SeleniumTests.NurseTests
{
    [TestClass]
    public class CheckIfExistUpdate
    {
        private IWebDriver _driver;
        private Actions _actions;
        private string _URL;
        private string _firstName;
        private string _lastName;
        private string _regime;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _URL = "http://localhost:3000/zorgkundige";
            _firstName = "Mariem";
            _lastName = "Sariedh";
            _regime = "Voltijds";
        }

        public void StartUp()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_URL);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
        }

        /// <summary>
        /// UpdateNurse_CheckIfExist
        /// </summary>
        [TestMethod]
        public void ST_NP_03_01()
        {
            var clear = Keys.Control + "A" + Keys.Backspace;
            StartUp();

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Update first record
            var updateNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[1]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            updateNurse.Click();

            // Updating firstname and lastname
            var txtInputFirstname = _driver.FindElement(By.Id("txtInputFirstname"));
            txtInputFirstname.SendKeys(clear);
            txtInputFirstname.SendKeys(_firstName);
            var txtInputLastname = _driver.FindElement(By.Id("txtInputLastname"));
            txtInputLastname.SendKeys(clear);
            txtInputLastname.SendKeys(_lastName);

            // Updating regime
            var openRegimeTypes = _driver.FindElement(By.Id("selectRegime"));
            openRegimeTypes.Click();
            var selectRegime = _driver.FindElement(By.XPath($"//li[normalize-space()='{_regime}']"));
            selectRegime.Click();

            // Updating fixednight
            var fixedNightInput = _driver.FindElement(By.Id("fixedNightInput"));
            _actions.MoveToElement(fixedNightInput).Click().Perform();

            // Update nurse
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();

            // Check ErrorMessage Popup
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'De zorgkundige bestaat al')]")));

            // Assertion to check if the element is not null
            Assert.IsNotNull(element, "The error message element was not found on the page.");

            // Driver quit
            _driver.Quit();
        }
    }
}
