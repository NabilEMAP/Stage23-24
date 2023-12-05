using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Tests.SeleniumTests.VacationTests
{
    [TestClass]
    public class VacationCRUD
    {
        private IWebDriver _driver;
        private string _URL;
        private string _nurse;
        private string _startDate;
        private string _enddate;
        private string _vacation;
        private string _reason;
        private string _updatedStartDate;
        private string _updatedEnddate;
        private string _updatedVacation;
        private string _updatedReason;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/verlof";
            _nurse = "Fatima Tsridh";
            _startDate = "20042004";
            _enddate = "21042004";
            _vacation = "Verlof";
            _reason = "Verlof test van 2 dagen";
            _updatedStartDate = "01052004";
            _updatedEnddate = "07052004";
            _updatedVacation = "Ziekte";
            _updatedReason = "Ziekte test van een week in mei";
        }

        [TestMethod]
        public void VacationCRUD_ST01_CreateVacation()
        {
            _driver.Navigate().GoToUrl(_URL);
            
            //Eerste Record aanspreken
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();
           
            //Nieuwe verlof aanmaken
            var createVacation = _driver.FindElement(By.Id("createVacation"));
            createVacation.Click();

            //Zorgkundige selecteren
            var selectNurse = _driver.FindElement(By.Id("selectNurse"));
            selectNurse.Click();
            var selectSpecificNurse = _driver.FindElement(By.XPath($"//li[normalize-space()='{_nurse}']"));
            selectSpecificNurse.Click();

            //Start en einddatum ingeven
            var txtInputStartDate = _driver.FindElement(By.XPath("//input[@id=':r2p:']"));
            txtInputStartDate.Click();
            txtInputStartDate.SendKeys(_startDate);
            var txtInputEndDate = _driver.FindElement(By.XPath("//input[@id=':r2t:']"));
            txtInputEndDate.Click();
            txtInputEndDate.SendKeys(_enddate);

            //Verlof selecteren
            var selectVacation = _driver.FindElement(By.Id("selectVacation"));
            selectVacation.Click();
            var selectSpecificVacation = _driver.FindElement(By.XPath($"//li[normalize-space()='{_vacation}']"));
            selectSpecificVacation.Click();

            //Reden ingeven
            var txtInputReason = _driver.FindElement(By.Id("txtInputReason"));
            txtInputReason.SendKeys(_reason);

            //Verlof toevoegen
            var submitForm = _driver.FindElement(By.Id("submitVacationForm"));
            submitForm.Click();

            //Driver beeindigen
            _driver.Quit();
        }

        
    }
}
