using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_DataProductApprovalPage
    {
        private IWebDriver _seleniumDriver;
        private Utils utils;
        //Sets homepage URL
        private string _productApprovalURL = AppConfigReader.ProductApprovalURL;

        //Finding web elements

        private IWebElement _reasonTextBox => _seleniumDriver.FindElement(By.Name("remark"));
        private IWebElement _approvalButton => _seleniumDriver.FindElement(By.XPath("//button[.='Approve']"));
        private IWebElement _rejectButton => _seleniumDriver.FindElement(By.XPath("//button[.='Reject']"));
        private IWebElement _sendBackButton => _seleniumDriver.FindElement(By.XPath("//button[.='Send back']"));
        private IWebElement _okConfirmationButton => _seleniumDriver.FindElement(By.XPath("//button[.='OK']"));
        private IWebElement _subscribeButton => _seleniumDriver.FindElement(By.XPath("//button[.='Subscribe']"));

        //Constructor
        public RDM_DataProductApprovalPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
            this.utils = new Utils(seleniumDriver);
        }

        //Functions

        public void VisitProductApproval()
        {
            _seleniumDriver.Navigate().GoToUrl(_productApprovalURL);

        }
        public void FindDataProduct(string name)
        {
            utils.MoveToLocation(_seleniumDriver.FindElement(By.LinkText(name)));
            _seleniumDriver.FindElement(By.LinkText(name)).Click();
        }

        public void AddReason(string reason)
        {
            _reasonTextBox.SendKeys(reason);
        } 
        public void ClickApprovalButton()
        {
            //utils.MoveToLocation(_approvalButton);
            //new Actions(_seleniumDriver).MoveToElement(_approvalButton).Click().Perform();
            //_approvalButton.Click();
            _approvalButton.SendKeys(Keys.Return);
            _okConfirmationButton.Click();
        }
        public void ClickRejectButton()
        {
            _rejectButton.Click();
            _okConfirmationButton.Click();
        }
        public void ClickSendBackButton()
        {
            _sendBackButton.Click();
            _okConfirmationButton.Click();
        }

        public bool IsProductApproved()
        {
            if(_subscribeButton!= null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
