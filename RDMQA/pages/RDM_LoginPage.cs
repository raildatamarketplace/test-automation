using log4net;
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
    public class RDM_LoginPage
    {
        private IWebDriver _seleniumDriver;
        private WebDriverWait wait;
        //Currently not working due to authentication issue?
        private string _loginPageURL = AppConfigReader.LoginURL;

        private IWebElement _usernameField => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("usernameUserInput")));
        private IWebElement _passwordField => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        private IWebElement _loginButton => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ui.primary.large.button")));

        public RDM_LoginPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
            this.wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(10));
        }

        //public void VisitLoginPage() => _seleniumDriver.Navigate().GoToUrl("https://rdmtcs:UvQ%o+oGSm#6C#?V@" + _loginPageURL);
        public void InputUsername(string username)
        {
            _usernameField.SendKeys(username);
        }
            public void InputPassword(string password) => _passwordField.SendKeys(password);
        public void ClickLogin() => _loginButton.Click();

    }
}
