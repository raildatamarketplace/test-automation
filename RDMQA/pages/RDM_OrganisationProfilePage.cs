using AutoIt;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_OrganisationProfilePage
    {
        private IWebDriver _seleniumDriver;
        private Utils utils;
        private WebDriverWait wait;
        private ILog log;

        //Finding web elements

        private IWebElement _usersLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[.='Users ']")));
        private IWebElement _addNewUser => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Add user")));
        private IWebElement _usernameField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Username']")));
        private IWebElement _roleField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Role']")));
        private IWebElement _firstNameField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='First name']")));
        private IWebElement _lastNameField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Last name']")));
        private IWebElement _contactNumberField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Contact number']")));
        private IWebElement _emailField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Email']")));
        private IWebElement _submitButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[.='Add user']")));
        private IReadOnlyList<IWebElement> _dropdownElements => wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='mantine-Select-dropdown mantine-rynikm']")));


        //Constructor
        public RDM_OrganisationProfilePage(IWebDriver seleniumDriver, ILog log)
        {
            this._seleniumDriver = seleniumDriver;
            this.utils = new Utils(seleniumDriver);
            this.wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(10));
            this.log = log;
        }

        //Functions

        public void NavigateToUsersTab()
        {
            _usersLink.Click();
        }

        public void AddNewUser(string username, int roleIndex, string firstName, string lastName, int contactNumber, string emailAddress)
        {
            log.Info("Adding a new user..");

            _addNewUser.Click();
            _usernameField.SendKeys(username);
            _roleField.Click();
            for(int i = 0; i < roleIndex; i++) 
            {
                _roleField.SendKeys(Keys.ArrowDown);
            }
            _roleField.SendKeys(Keys.Enter);
            _firstNameField.SendKeys(firstName);
            _lastNameField.SendKeys(lastName);
            _contactNumberField.SendKeys(contactNumber.ToString());
            _emailField.SendKeys(emailAddress);

            log.Info("Submitting a new user..");

            utils.MoveToLocation(_submitButton);
            _submitButton.Click();
        }
    }
}
