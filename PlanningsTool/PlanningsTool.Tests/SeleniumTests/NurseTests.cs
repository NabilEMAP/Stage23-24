using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.ComponentModel;

namespace PlanningsTool.Tests.SeleniumTests
{
    [TestClass]
    public class NurseTests
    {
        private IWebDriver _driver;
        private string _URL;
        private string _firstName;
        private string _updatedFirstName;
        private string _lastName;
        private string _updatedLastName;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/";
            _firstName = "TestFirstname";
            _updatedFirstName = "TestUpdateFirstname";
            _lastName = "TestLastname";
            _updatedLastName = "TestUpdateLastname";
        }

        public void NavigateToContainer(string container)
        {
            _driver.Navigate().GoToUrl(_URL);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            var submitButton = _driver.FindElement(By.XPath($"//h2[normalize-space()='{container}']"));
            submitButton.Click();
        }

        [TestMethod]
        public void Test01_NavigateToNursePage()
        {
            NavigateToContainer("Zorgkundige");
            _driver.Quit();
        }

        [TestMethod]
        public void Test02_CreateNurse()
        {
            string regime = "Voltijds";
            _driver.Navigate().GoToUrl(_URL + "Zorgkundige");
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();
            var createNurse = _driver.FindElement(By.Id("createNurse"));
            createNurse.Click();
            var txtInputFirstname = _driver.FindElement(By.Id("txtInputFirstname"));
            var txtInputLastname = _driver.FindElement(By.Id("txtInputLastname"));
            var selectRegime = _driver.FindElement(By.Id("selectRegime"));
            txtInputFirstname.SendKeys(_firstName);
            txtInputLastname.SendKeys(_lastName);
            selectRegime.Click();
            var selectSpecificRegime = _driver.FindElement(By.XPath($"//li[normalize-space()='{regime}']"));
            selectSpecificRegime.Click();
            var fixedNightInput = _driver.FindElement(By.Id("fixedNightInput"));
            fixedNightInput.Click(); //als je dit erbij zet, verander je dit naar true anders false
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();
            _driver.Quit();
        }

        [TestMethod]
        public void Test03_ReadNurse()
        {
            _driver.Navigate().GoToUrl(_URL + "Zorgkundige");
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click();
            sortByNew.Click();
            var readNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[1]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            readNurse.Click();
            var readFirstname = _driver.FindElement(By.XPath("//input[@id='txtInputFirstname']")).GetAttribute("value");
            var readLastname = _driver.FindElement(By.XPath("//input[@id='txtInputLastname']")).GetAttribute("value");
            Assert.AreEqual(_firstName, readFirstname);
            Assert.AreEqual(_lastName, readLastname);
            _driver.Quit();
        }


        [TestMethod]
        public void Test04_UpdateNurse()
        {
            var clear = Keys.Control + "A" + Keys.Backspace;
            string regime = "Deeltijds 4/5";
            _driver.Navigate().GoToUrl(_URL + "Zorgkundige");
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();
            var updateNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[1]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            updateNurse.Click();
            var txtInputFirstname = _driver.FindElement(By.Id("txtInputFirstname"));
            var txtInputLastname = _driver.FindElement(By.Id("txtInputLastname"));
            var selectRegime = _driver.FindElement(By.Id("selectRegime"));
            txtInputFirstname.SendKeys(clear);
            txtInputFirstname.SendKeys(_updatedFirstName);
            txtInputLastname.SendKeys(clear);
            txtInputLastname.SendKeys(_updatedLastName);
            selectRegime.Click();
            var selectSpecificRegime = _driver.FindElement(By.XPath($"//li[normalize-space()='{regime}']"));
            selectSpecificRegime.Click();
            var fixedNightInput = _driver.FindElement(By.Id("fixedNightInput"));
            fixedNightInput.Click();
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();
            _driver.Quit();
        }

        [TestMethod]
        public void Test05_ReadUpdatedNurse()
        {
            _driver.Navigate().GoToUrl(_URL + "Zorgkundige");
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click();
            sortByNew.Click();
            var readNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[1]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            readNurse.Click();
            var readFirstname = _driver.FindElement(By.XPath("//input[@id='txtInputFirstname']")).GetAttribute("value");
            var readLastname = _driver.FindElement(By.XPath("//input[@id='txtInputLastname']")).GetAttribute("value");
            Assert.AreEqual(_updatedFirstName, readFirstname);
            Assert.AreEqual(_updatedLastName, readLastname);
            _driver.Quit();
        }

        [TestMethod]
        public void Test06_DeleteNurse()
        {
            _driver.Navigate().GoToUrl(_URL + "Zorgkundige");
            var sortByNew = _driver.FindElement(By.XPath("//div[contains(text(),'Id')]"));
            sortByNew.Click(); sortByNew.Click();
            var deleteNurse = _driver.FindElement(By.XPath("//div[1]//div[6]//div[1]//button[2]//*[name()='svg']//*[name()='path' and contains(@fill,'currentCol')]"));
            deleteNurse.Click();
            var submitForm = _driver.FindElement(By.Id("submitNurseForm"));
            submitForm.Click();
            _driver.Quit();
        }
    }
}
