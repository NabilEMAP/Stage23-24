using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.ComponentModel;

namespace PlanningsTool.Tests.SeleniumTests.NurseTests
{
    [TestClass]
    public class NurseCRUD
    {
        private IWebDriver _driver;
        private string _URL;
        private string _firstName;
        private string _lastName;
        private string _regime;
        private string _fixedNight;
        private string _updatedFirstName;
        private string _updatedLastName;
        private string _updatedRegime;
        private string _updatedFixedNight;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/zorgkundige";
            _firstName = "TestFirstname";
            _lastName = "TestLastname";
            _regime = "Voltijds";
            _fixedNight = "Ja";
            _updatedFirstName = "TestUpdateFirstname";
            _updatedLastName = "TestUpdateLastname";
            _updatedRegime = "Deeltijds 4/5";
            _updatedFixedNight = "Nee";
        }

        [TestMethod]
        public void NurseCRUD_ST01_CreateNurse()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Making a new nurse
            var createNurse = _driver.FindElement(By.Id("createNurse"));
            createNurse.Click();

            // Inserting firstname and lastname
            var txtInputFirstname = _driver.FindElement(By.Id("txtInputFirstname"));
            txtInputFirstname.SendKeys(_firstName);
            var txtInputLastname = _driver.FindElement(By.Id("txtInputLastname"));
            txtInputLastname.SendKeys(_lastName);

            // Selecting regime
            var selectRegime = _driver.FindElement(By.Id("selectRegime"));
            selectRegime.Click();
            var selectSpecificRegime = _driver.FindElement(By.XPath($"//li[normalize-space()='{_regime}']"));
            selectSpecificRegime.Click();

            // Added fixednight
            var fixedNightInput = _driver.FindElement(By.Id("fixedNightInput"));
            fixedNightInput.Click();

            // Added nurse
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();

            // Driver quit
            _driver.Quit();
        }

        [TestMethod]
        public void NurseCRUD_ST02_ReadNurse()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Reading in delete modal
            var read = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            read.Click();

            // Reading data
            var readFirstname = _driver.FindElement(By.Id("firstName")).GetAttribute("value");
            var readLastname = _driver.FindElement(By.Id("lastName")).GetAttribute("value");
            var readRegime = _driver.FindElement(By.Id("regime")).GetAttribute("value");
            var readFixedNight = _driver.FindElement(By.Id("fixedNight")).GetAttribute("value");
            Assert.AreEqual(_firstName, readFirstname);
            Assert.AreEqual(_lastName, readLastname);
            Assert.AreEqual(_regime, readRegime);
            Assert.AreEqual(_fixedNight, readFixedNight);

            // Driver quit
            _driver.Quit();
        }


        [TestMethod]
        public void NurseCRUD_ST03_UpdateNurse()
        {
            var clear = Keys.Control + "A" + Keys.Backspace;
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Update first record
            var updateNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[1]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            updateNurse.Click();

            // Updating firstname and lastname
            var txtInputFirstname = _driver.FindElement(By.Id("txtInputFirstname"));
            txtInputFirstname.SendKeys(clear);
            txtInputFirstname.SendKeys(_updatedFirstName);
            var txtInputLastname = _driver.FindElement(By.Id("txtInputLastname"));
            txtInputLastname.SendKeys(clear);
            txtInputLastname.SendKeys(_updatedLastName);

            // Updating regime
            var selectRegime = _driver.FindElement(By.Id("selectRegime"));
            selectRegime.Click();
            var selectSpecificRegime = _driver.FindElement(By.XPath($"//li[normalize-space()='{_updatedRegime}']"));
            selectSpecificRegime.Click();

            // Updating fixednight
            var fixedNightInput = _driver.FindElement(By.Id("fixedNightInput"));
            fixedNightInput.Click();

            // Update nurse
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();

            // Driver quit
            _driver.Quit();
        }

        [TestMethod]
        public void NurseCRUD_ST04_ReadUpdatedNurse()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Read in delete modal
            var readNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            readNurse.Click();

            // Read updated data
            var readFirstname = _driver.FindElement(By.Id("firstName")).GetAttribute("value");
            var readLastname = _driver.FindElement(By.Id("lastName")).GetAttribute("value");
            var readRegime = _driver.FindElement(By.Id("regime")).GetAttribute("value");
            var readFixedNight = _driver.FindElement(By.Id("fixedNight")).GetAttribute("value");
            Assert.AreEqual(_updatedFirstName, readFirstname);
            Assert.AreEqual(_updatedLastName, readLastname);
            Assert.AreEqual(_updatedRegime, readRegime);
            Assert.AreEqual(_updatedFixedNight, readFixedNight);

            // Driver quit
            _driver.Quit();
        }

        [TestMethod]
        public void NurseCRUD_ST05_DeleteNurse()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Delete first record
            var deleteNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            deleteNurse.Click();

            // Deleted nurse
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();

            // Driver quit
            _driver.Quit();
        }
    }
}
