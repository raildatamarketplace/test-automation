using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
        private WebDriverWait wait;
        //Sets homepage URL
        private string _dataProductURL = AppConfigReader.DataProductURL;

        //Finding web elements
        private IWebElement _publishDataProductButton => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Publish new data product")));  

        //Constructor
        public RDM_MyDataProductPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
            this.wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(10));
        }

        public void VisitMyDataProductPage() => _seleniumDriver.Navigate().GoToUrl(_dataProductURL);
        public void ClickPublish() => _publishDataProductButton.Click();
    }
}
