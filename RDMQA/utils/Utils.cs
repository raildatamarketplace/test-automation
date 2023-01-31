using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using SeleniumExtras.WaitHelpers;

namespace RDMQA
{
    public class Utils
    {
        private IWebDriver _seleniumDriver;
        private WebDriverWait wait;

        public Utils(IWebDriver _driver)
        {
            _seleniumDriver = _driver;
            this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void MoveToLocation(IWebElement element)
        {
            //Thread.Sleep(2000);
            int deltaY = element.Location.Y;
            new Actions(_seleniumDriver).ScrollByAmount(0, deltaY).Perform();
            //Thread.Sleep(2000);
        }

        //public void MoveToLocation(By element)
        //{
        //    wait.Until(ExpectedConditions.ElementExists(element));
        //    int deltaY = _seleniumDriver.FindElement(element).Location.Y;
        //    new Actions(_seleniumDriver).ScrollByAmount(0, deltaY).Perform();
        //}

        public string GetNewDataProductNumber()
        {
            int current = Convert.ToInt32(AppConfigReader.DataProductNumber);
            int updated = current + 1;
            AppConfigReader.UpdateValue("dataproduct_number", updated.ToString());
            return current.ToString();
        }

        public string GetDataProductNumber()
        {
            int current = Convert.ToInt32(AppConfigReader.DataProductNumber) - 1;
            return current.ToString();
        }
    }
}
