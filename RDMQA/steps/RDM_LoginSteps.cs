using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA
{
    [Binding]
    public class RDM_LoginSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;

       public RDM_LoginSteps(RDM_Website<ChromeDriver> rdm_website) 
       {
            RDM_Website = rdm_website;
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            RDM_Website.RDM_Homepage.VisitHomePage();
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
           RDM_Website.RDM_Homepage.VisitHomePage();
           RDM_Website.RDM_Homepage.ClickAccess(); 
           //Updated for Private Beta
           //RDM_Website.RDM_Homepage.VisitLoginPage();
        }

        [Given(@"I have entered ""(.*)"" in the username field")]
        public void GivenIHaveEnteredInTheUsernameField(string username)
        {
            RDM_Website.RDM_LoginPage.InputUsername(username);
        }

        [Given(@"I have entered ""(.*)"" in the password field")]
        public void GivenIHaveEnteredInThePasswordField(string password)
        {
            RDM_Website.RDM_LoginPage.InputPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            RDM_Website.RDM_LoginPage.ClickLogin();
        }

        [When(@"I wait for (.*) seconds")]
        public void WhenIWaitForSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        [When(@"I have logged out")]
        public void WhenIHaveLoggedOut()
        {
            RDM_Website.RDM_Homepage.Logout();
        }

        [Then(@"I should be taken to the dashboard homepage")]
        public void ThenIShouldBeTakenToTheDashboardHomepage()
        {
           Assert.AreEqual("https://test.raildata.org.uk/dashboard", RDM_Website.SeleniumDriver.Url, "Test Failed - URL is incorrect");
           //Assert.IsTrue(RDM_Website.SeleniumDriver.Url.Contains("9"), "Test Failed");
           //if (RDM_Website.SeleniumDriver.Url.Contains("9"))
           //{
           //    Assert.Pass("Test Passed");
           //}
           //else
           //{
           //    Assert.Fail("Test Failed - User is not taken to the homepage");
           //}
        }

        [Then(@"I should be taken to the access homepage")]
        public void ThenIShouldBeTakenToTheAccessHomepage()
        {
           //Assert.IsTrue(RDM_Website.RDM_Homepage.IsOnHomepage(), "Test Failed");
           //if(RDM_Website.RDM_Homepage.IsOnHomepage())
           //{
           //    Assert.Pass("Test Passed");
           //} else
           //{
           //    log.Debug("Test Failed - User wasn't taken to the Access Homepage");
           //    Assert.Fail();
           //}
        }
    }
}
