using AutoIt;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_Homepage
    {
        private IWebDriver _seleniumDriver;
        private WebDriverWait wait;
        //Sets homepage URL
        private string _homepageURL = AppConfigReader.HomepageURL;
        private string _dashboardHomepageURL = AppConfigReader.DashboardHomepageURL;

        //Finding web elements
        private IWebElement _loginLink => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
        private IWebElement _navigationHomeLink => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Home")));
        private IWebElement _navigationDataProductCatalogue => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Data product catalogue")));

        private IReadOnlyList<IWebElement> _manageDropdownLinkElements => _seleniumDriver.FindElements(By.XPath("//div[@class='mantine-1eawhj0 mantine-Menu-itemLabel']"));
        private IReadOnlyList<IWebElement> _manageDropdownLink => _seleniumDriver.FindElements(By.XPath("//div[.='Manage']"));
        private IWebElement _overviewLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Overview']")));
        private IWebElement _mySalesLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='My sales']")));
        private IWebElement _myProductsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='My products']")));
        private IWebElement _myDataSourcesLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='My data sources']")));
        private IWebElement _detailsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Details']")));
        private IWebElement _manageOrganisationsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Manage organisations']")));
        private IWebElement _productApprovalsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Product approvals']")));
        private IWebElement _productStatistics => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Product statistics']")));
        private IWebElement _transactionsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Transactions']")));
        private IWebElement _tagsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Tags']")));
        private IWebElement _themesLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Themes']")));
        private IWebElement _alertUsersLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Alert Users']")));
        private IWebElement _reportsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Reports']")));
        private IWebElement _subscriptionsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Subscriptions")));
        private IWebElement _organisationsLink => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Organisations")));
        private IWebElement _helpAndSupportLink => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Help and support")));
        private IWebElement _accessButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='Access Rail Data Marketplace']")));
        private IWebElement _cookieBannerButton => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='ui small button customBtn1Primary']")));
        private IWebElement _cookieBannerButton2 => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='Accept additional cookies']")));
        private IWebElement _accountDropdown => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='ui item dropdown'")));
        private IWebElement _signoutButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Sign out']")));
        //Constructor
        public RDM_Homepage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
            this.wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(10));
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

        public void VisitDashboardHomepage()
        {
            _seleniumDriver.Navigate().GoToUrl(_dashboardHomepageURL);
        }

        public void VisitLoginPage() => _loginLink.Click();

        public void VisitDataProductsPage()
        {
            _manageDropdownLink[1].Click();
            _myProductsLink.Click();
        }

        public void VisitProductAprovalsPage()
        {
            _manageDropdownLink[0].Click();
            _productApprovalsLink.Click();
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

        public bool[] CheckManageDropdown()
        {
            if (_manageDropdownLink.Count <= 0)
            {
                return new bool[1] { true };
            }
            List<string> expected = new List<string> { "Overview", "My sales", "My products", "My data sources", "Details", 
                "Manage organisations", "Product approvals", "Product statistics", "Transactions", 
                "Tags", "Themes", "Alert users", "Reports" };
            bool[] results = new bool[_manageDropdownLinkElements.Count];
            for (int i = 0; i<_manageDropdownLinkElements.Count; i++)
            {
                if (_manageDropdownLinkElements[i].Text == expected[i])
                {
                    results[i] = true;
                } else
                {
                    results[i] = false;
                }
            }
            return results;
        }

        public List<string> CheckNavigationUI()
        {
            //Checks to ensure navigation UI and Manage dropdown are all as expected
            //The only thing that changes per user is the manage dropdown
            //and that is covered in CheckManageDropdownMethod
            List<string> actual = new List<string>();
            if (_manageDropdownLink.Count <= 0)
            {
                actual.Add(_navigationHomeLink.Text);
                actual.Add(_navigationDataProductCatalogue.Text);
                actual.Add(_subscriptionsLink.Text);
                actual.Add(_organisationsLink.Text);
                actual.Add(_helpAndSupportLink.Text);
            } else
            {
                actual.Add(_navigationHomeLink.Text);
                actual.Add(_navigationDataProductCatalogue.Text);
                actual.Add(_manageDropdownLink[0].Text);
                _manageDropdownLink[0].Click();
                for (int i = 0; i < _manageDropdownLinkElements.Count; i++)
                {
                    actual.Add(_manageDropdownLinkElements[i].Text);
                }
                
                actual.Add(_subscriptionsLink.Text);
                actual.Add(_organisationsLink.Text);
                actual.Add(_helpAndSupportLink.Text);
            }
            return actual;
        }
    }
}
