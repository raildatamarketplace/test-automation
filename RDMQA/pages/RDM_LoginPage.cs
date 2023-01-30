using OpenQA.Selenium;
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

        //Currently not working due to authentication issue?
        private string _loginPageURL = AppConfigReader.LoginURL;

        private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("usernameUserInput"));
        private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _loginButton => _seleniumDriver.FindElement(By.CssSelector(".ui.primary.large.button"));

        public RDM_LoginPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
        }

        public void VisitLoginPage() => _seleniumDriver.Navigate().GoToUrl("https://rdmtcs:UvQ%o+oGSm#6C#?V@" + _loginPageURL);
        public void InputUsername(string username) => _usernameField.SendKeys(username);
        public void InputPassword(string password) => _passwordField.SendKeys(password);
        public void ClickLogin() => _loginButton.Click();

    }
}
