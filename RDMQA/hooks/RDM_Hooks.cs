using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using RDMQA.steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA.hooks
{
    [Binding]
    public class RDM_Hooks
    {

        private IObjectContainer _objectContainer;
        public RDM_Website<ChromeDriver> RDM_Website;

        public RDM_Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        
        [BeforeScenario]
        public void InitWebDriver()
        {
            RDM_Website = new RDM_Website<ChromeDriver>();
            _objectContainer.RegisterInstanceAs<RDM_Website<ChromeDriver>>(RDM_Website);
        }
        
        [AfterScenario]
        public void DisposeWebDriver()
        {
            RDM_Website.SeleniumDriver.Quit();
            RDM_Website.SeleniumDriver.Dispose();
        }
    }
}
