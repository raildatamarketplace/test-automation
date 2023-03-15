using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_RegistrationPage
    {
        private IWebDriver _seleniumDriver;
        private WebDriverWait wait;
        //Currently not working due to authentication issue?
        private string _registrationURL = AppConfigReader.RegistrationURL;
        private ILog log;

        private IWebElement _platformAgreement => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='mantine-14ce0tc mantine-Radio-radio']")));
        private IWebElement _typeOfOrganisation => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='mantine-Input-wrapper mantine-Select-wrapper mantine-jrzo75']")));
        private IWebElement _accountName => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Account name']")));
        private IWebElement _profileDescription => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Profile description']")));
        private IWebElement _website => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Website']")));
        private IWebElement _addressLine1 => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Address line 1']")));
        private IWebElement _town => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Town or city']")));
        private IWebElement _county => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='County or region']")));
        private IWebElement _postcode => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Postcode or ZIP code']")));
        private IWebElement _countrydropdown => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='mantine-Input-input mantine-Select-input mantine-8852l6']")));
        private IWebElement _orgEmailAddress => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='']")));
        private IWebElement _username => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Username']")));
        private IWebElement _userFirstName => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='First name']")));
        private IWebElement _userLastName => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Last name']")));
        private IWebElement _userPhoneNumber => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Phone number']")));
        private IWebElement _userEmailAddress => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Email address']")));


        public RDM_RegistrationPage(IWebDriver seleniumDriver, ILog log)
        {
            this._seleniumDriver = seleniumDriver;
            this.wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(10));
            this.log = log;
        }

        public void VisitRegistrationPage()
        {
            log.Info("Visiting registration page");
            _seleniumDriver.Navigate().GoToUrl(_registrationURL);
        }

        public void ClickAgreeToPlatformAgreement()
        {
            log.Info("Clicking agree to platform agreement");
            _platformAgreement.Click();
        }
        public void EnterTypeOfOrganisation(int index)
        {
            log.Info("Entering type of organisation");
            _typeOfOrganisation.Click();
            //use index to input number of arrows down
            _typeOfOrganisation.SendKeys(Keys.ArrowDown);
            _typeOfOrganisation.SendKeys(Keys.Enter);
        }

        public void EnterAccountName(string accountName)
        {
            log.Info("Entering acount name " + accountName);
            _accountName.SendKeys(accountName);
        }

        public void EnterProfileDescription(string profileDescription)
        {
            log.Info("Entering profile description ");
            _profileDescription.SendKeys(profileDescription);
        }

        public void EnterWebsite(string website)
        {
            log.Info("Entering website " + website);
            _website.SendKeys(website);
        }

        public void EnterAddressLine1(string address)
        {
            log.Info("Entering address line 1 " + address);
            _addressLine1.SendKeys(address);
        }

        public void EnterTown(string town)
        {
            log.Info("Entering town " + town);
            _town.SendKeys(town);
        }

        public void EnterCounty(string county)
        {
            log.Info("Entering county " + county);
            _county.SendKeys(county);
        }
        public void EnterPostcode(string postcode)
        {
            log.Info("Entering postcode " + postcode);
            _postcode.SendKeys(postcode);
        }

        public void EnterCountry(int index)
        {
            //this is an issue as this is a VERY big dropdown selection
            //234 down inputs to get to United Kingdom.
            //Other dropdowns can be searched. Might be worth asking TCS to do this
            log.Info("Entering country ");
            _countrydropdown.Click();
            _countrydropdown.SendKeys(Keys.ArrowDown);
            _countrydropdown.SendKeys(Keys.Enter);
        }

        public void EnterOrgEmailAddress(string orgEmail)
        {
            log.Info("Entering org email address " + orgEmail);
            _orgEmailAddress.SendKeys(orgEmail);  
        }

        public void EnterUsername(string username)
        {
            log.Info("Entering username " + username);
            _username.SendKeys(username);
        }

        public void EnterFirstName(string firstName)
        {
            log.Info("Entering first name " + firstName);
            _userFirstName.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            log.Info("Entering last name " + lastName);
            _userLastName.SendKeys(lastName);
        }

        public void EnterUserPhoneNumber(int phoneNumber)
        {
            log.Info("Entering users phone number " + phoneNumber.ToString());
            _userPhoneNumber.SendKeys(phoneNumber.ToString());
        }

        public void EnterUserEmailAddress(string userEmail)
        {
            log.Info("Entering users email address " + userEmail);
            _userEmailAddress.SendKeys(userEmail);
        }



    }
}
