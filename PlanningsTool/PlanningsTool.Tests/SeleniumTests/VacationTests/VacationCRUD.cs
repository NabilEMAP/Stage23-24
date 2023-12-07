using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PlanningsTool.Tests.SeleniumTests.VacationTests
{
    [TestClass]
    public class VacationCRUD
    {
        private IWebDriver _driver;
        private string _URL;
        private string _nurse;
        private string _startdate;
        private string _enddate;
        private string _vacation;
        private string _reason;
        private string _updatedNurse;
        private string _updatedStartdate;
        private string _updatedEnddate;
        private string _updatedVacation;
        private string _updatedReason;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/verlof";
            _nurse = "Fatima Tsridh";
            _startdate = "20/04/2004";
            _enddate = "21/04/2004";
            _vacation = "Verlof";
            _reason = "Verlof test van 2 dagen";
            _updatedNurse = "Fatima Tsridh";
            _updatedStartdate = "01/05/2004";
            _updatedEnddate = "07/05/2004";
            _updatedVacation = "Ziekte";
            _updatedReason = "Ziekte test van een week in mei";
        }

        [TestMethod]
        public void VacationCRUD_ST01_CreateVacation()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Making a new vacation
            var createVacation = _driver.FindElement(By.Id("createVacation"));
            createVacation.Click();

            // Selecting nurse
            var selectNurse = _driver.FindElement(By.Id("selectNurse"));
            selectNurse.Click();
            var selectSpecificNurse = _driver.FindElement(By.XPath($"//li[normalize-space()='{_nurse}']"));
            selectSpecificNurse.Click();

            // Inserting startdate and enddate
            var txtInputStartDate = _driver.FindElement(By.XPath("//body//div[@role='dialog']//div//div//div//div[2]//div[1]//div[1]//input[1]"));
            txtInputStartDate.Click();
            txtInputStartDate.SendKeys(_startdate);
            var txtInputEndDate = _driver.FindElement(By.XPath("//body/div[@role='dialog']/div/div/div/div/div[3]/div[1]/div[1]//input[1]"));
            txtInputEndDate.Click();
            txtInputEndDate.SendKeys(_enddate);

            // Selecting vacation
            var selectVacation = _driver.FindElement(By.Id("selectVacation"));
            selectVacation.Click();
            var selectSpecificVacation = _driver.FindElement(By.XPath($"//li[normalize-space()='{_vacation}']"));
            selectSpecificVacation.Click();

            // Inserting reason
            var txtInputReason = _driver.FindElement(By.Id("txtInputReason"));
            txtInputReason.SendKeys(_reason);

            // Added vacation
            var submitForm = _driver.FindElement(By.Id("submitVacationForm"));
            submitForm.Click();

            // Driver quit
            _driver.Quit();
        }

        [TestMethod]
        public void VacationCRUD_ST02_ReadVacation()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Reading in delete modal
            var read = _driver.FindElement(By.XPath("//body//div[@id='root']//div[@role='presentation']//div[@role='presentation']//div[@role='rowgroup']//div[1]//div[6]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            read.Click();

            // Read data
            var readNurse = _driver.FindElement(By.Id("nurse")).GetAttribute("value");
            var readStartDate = _driver.FindElement(By.Id("startdate")).GetAttribute("value");
            var readEndDate = _driver.FindElement(By.Id("enddate")).GetAttribute("value");
            var readVacation = _driver.FindElement(By.Id("vacationType")).GetAttribute("value");
            var readReason = _driver.FindElement(By.Id("reason")).GetAttribute("value");
            Assert.AreEqual(_nurse, readNurse);
            Assert.AreEqual(_startdate, readStartDate);
            Assert.AreEqual(_enddate, readEndDate);
            Assert.AreEqual(_vacation, readVacation);
            Assert.AreEqual(_reason, readReason);

            // Driver quit
            _driver.Quit();
        }


        [TestMethod]
        public void VacationCRUD_ST03_UpdateVacation()
        {
            var clear = Keys.Control + "A" + Keys.Backspace;
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Update first record
            var updateVacation = _driver.FindElement(By.XPath("//body//div[@id='root']//div[@role='presentation']//div[@role='presentation']//div[@role='rowgroup']//div[1]//div[6]//button[1]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            updateVacation.Click();

            // Updating nurse
            var selectNurse = _driver.FindElement(By.Id("selectNurse"));
            selectNurse.Click();
            var selectSpecificNurse = _driver.FindElement(By.XPath($"//li[normalize-space()='{_updatedNurse}']"));
            selectSpecificNurse.Click();

            // Updating startdate and enddate
            var txtInputStartDate = _driver.FindElement(By.XPath("//body//div[@role='dialog']//div//div//div//div[2]//div[1]//div[1]//input[1]"));
            txtInputStartDate.Click();
            txtInputStartDate.SendKeys(clear);
            txtInputStartDate.SendKeys(_updatedStartdate);
            var txtInputEndDate = _driver.FindElement(By.XPath("//body/div[@role='dialog']/div/div/div/div/div[3]/div[1]/div[1]//input[1]"));
            txtInputEndDate.Click();
            txtInputEndDate.SendKeys(clear);
            txtInputEndDate.SendKeys(_updatedEnddate);

            // Updating vacation
            var selectVacation = _driver.FindElement(By.Id("selectVacation"));
            selectVacation.Click();
            var selectSpecificVacation = _driver.FindElement(By.XPath($"//li[normalize-space()='{_updatedVacation}']"));
            selectSpecificVacation.Click();

            // Updating reason
            var txtInputReason = _driver.FindElement(By.Id("txtInputReason"));
            txtInputReason.SendKeys(clear);
            txtInputReason.SendKeys(_updatedReason);

            // Update vacation
            var submitForm = _driver.FindElement(By.Id("submitVacationForm"));
            submitForm.Click();

            // Driver quit
            _driver.Quit();
        }

        [TestMethod]
        public void VacationCRUD_ST04_ReadUpdatedVacation()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Read in update modal
            var read = _driver.FindElement(By.XPath("//body//div[@id='root']//div[@role='presentation']//div[@role='presentation']//div[@role='rowgroup']//div[1]//div[6]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            read.Click();

            // Read updated data
            var readNurse = _driver.FindElement(By.Id("nurse")).GetAttribute("value");
            var readStartDate = _driver.FindElement(By.Id("startdate")).GetAttribute("value");
            var readEndDate = _driver.FindElement(By.Id("enddate")).GetAttribute("value");
            var readVacation = _driver.FindElement(By.Id("vacationType")).GetAttribute("value");
            var readReason = _driver.FindElement(By.Id("reason")).GetAttribute("value");
            Assert.AreEqual(_updatedNurse, readNurse);
            Assert.AreEqual(_updatedStartdate, readStartDate);
            Assert.AreEqual(_updatedEnddate, readEndDate);
            Assert.AreEqual(_updatedVacation, readVacation);
            Assert.AreEqual(_updatedReason, readReason);

            // Driver quit
            _driver.Quit();
        }

        [TestMethod]
        public void VacationCRUD_ST05_DeleteVacation()
        {
            _driver.Navigate().GoToUrl(_URL);

            // Addressing first record
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();

            // Delete first record
            var deleteVacation = _driver.FindElement(By.XPath("//div[@role='rowgroup']//div[1]//div[6]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            deleteVacation.Click();

            // Deleted vacation
            var submitForm = _driver.FindElement(By.Id("submitVacationForm"));
            submitForm.Click();

            // Driver quit
            _driver.Quit();
        }
    }
}
