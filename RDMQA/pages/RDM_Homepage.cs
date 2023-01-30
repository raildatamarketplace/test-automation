using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_Homepage
    {
        private IWebDriver _seleniumDriver;
        //Sets homepage URL
        private string _homepageURL = AppConfigReader.HomepageURL;

        //Finding web elements
        private IWebElement _loginLink => _seleniumDriver.FindElement(By.LinkText("Login"));
        private IWebElement _manageDropdownLink => _seleniumDriver.FindElement(By.CssSelector("div[title='Manage']"));
        private IWebElement _myProductsLink => _seleniumDriver.FindElement(By.LinkText("My products"));
        private IWebElement _productAprovalsLink => _seleniumDriver.FindElement(By.LinkText("Product approvals"));
        private IWebElement _accessButton => _seleniumDriver.FindElement(By.CssSelector("button[class='ui button customBtn1Primary']"));
        private IWebElement _cookieBannerButton => _seleniumDriver.FindElement(By.CssSelector("button[class='ui small button customBtn1Primary']"));
        private IWebElement _cookieBannerButton2 => _seleniumDriver.FindElement(By.CssSelector("button[class='ui small fluid button customBtn1Primary']"));
        private IWebElement _accountDropdown => _seleniumDriver.FindElement(By.CssSelector("div[class='ui item dropdown'"));
        private IWebElement _signoutButton => _seleniumDriver.FindElement(By.XPath("//div[.='Sign out']"));
        //Constructor
        public RDM_Homepage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
        }

        //Functions

        public void VisitHomePage()
        {
            _seleniumDriver.Navigate().GoToUrl(_homepageURL);

            //Below uses AutoItX to interact with the windows login form
            //AutoItX.WinWaitActive("https://test.raildata.org.uk - Google Chrome");
            //AutoItX.Send("rdmtcs");
            //AutoItX.Send("{TAB}");
            //AutoItX.Send("UvQ%o+oGSm#6C#?V", 1);
            //AutoItX.Send("{ENTER}");
        }

        public void VisitLoginPage() => _loginLink.Click();

        public void VisitDataProductsPage()
        {
            _manageDropdownLink.Click();
            _myProductsLink.Click();
        }

        public void VisitProductAprovalsPage()
        {
            _manageDropdownLink.Click();
            _productAprovalsLink.Click();
        }

        public void ClickAccess() => _accessButton.Click();

        public void Logout()
        {
            _accountDropdown.Click();
            _signoutButton.Click();
        }

        public string GetPageTitle() => _seleniumDriver.Title;

        public void ClickAcceptCookies() => _cookieBannerButton2.Click();

        public void DeleteCookies() => _seleniumDriver.Manage().Cookies.DeleteAllCookies();

        public bool IsOnHomepage()
        {
            if (_accessButton != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
