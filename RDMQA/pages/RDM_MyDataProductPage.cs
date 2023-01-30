using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_MyDataProductPage
    {
        private IWebDriver _seleniumDriver;
        //Sets homepage URL
        private string _dataProductURL = AppConfigReader.DataProductURL;

        //Finding web elements
        private IWebElement _publishDataProductButton => _seleniumDriver.FindElement(By.LinkText("Publish new data product"));

        //Constructor
        public RDM_MyDataProductPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
        }

        public void VisitMyDataProductPage() => _seleniumDriver.Navigate().GoToUrl(_dataProductURL);
        public void ClickPublish() => _publishDataProductButton.Click();
    }
}
