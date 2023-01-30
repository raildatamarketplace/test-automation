using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDMQA
{
    class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs)
        {
            //Headless can't be done due to the current AUTOITX script running for authentication
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            //Driver = new ChromeDriver(options);
            Driver = new T();
            DriverSetup(pageLoadInSecs, implicitWaitInSecs);
        }

        public void DriverSetup(int pageLoadInSecs, int implicitWaitInSecs)
        {
            //Time the driver waits for the page to load in seconds
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            //Time the driver waits for the elements to load before the tests fail in seconds
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
        }
    }
}
