using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Tests.SeleniumTests.NurseShiftTests
{
    [TestClass]
    public class NurseShiftTests
    {
        private IWebDriver _driver;
        private string _URL;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _URL = "http://localhost:3000/shift";
        }
    }
}
