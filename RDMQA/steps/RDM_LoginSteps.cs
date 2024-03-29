﻿using log4net;
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
using System.Web.UI;
using TechTalk.SpecFlow;

namespace RDMQA
{
    [Binding]
    public class RDM_LoginSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;
        private Utils utils;

        public RDM_LoginSteps(RDM_Website<ChromeDriver> rdm_website) 
       {
            RDM_Website = rdm_website;
            this.utils = new Utils(RDM_Website.SeleniumDriver);
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
           RDM_Website.RDM_Homepage.VisitLoginPage();
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

        [Given(@"I have logged in as ""(.*)"" user")]
        public void GivenIHaveLoggedIn(Utils.UserType userType)
        {
            switch(userType)
            {
                case Utils.UserType.RDMAdmin:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.RDMAdmin));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.RDMAdmin));
                    break;
                case Utils.UserType.Admin:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.Admin));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.Admin));
                    break;
                case Utils.UserType.Publisher:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.Publisher));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.Publisher));
                    break;
                case Utils.UserType.Consumer:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.Consumer));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.Consumer));
                    break;
                case Utils.UserType.FAConsumer:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.FAConsumer));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.FAConsumer));
                    break;
                case Utils.UserType.FinanceApprover:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.FinanceApprover));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.FinanceApprover));
                    break;
                case Utils.UserType.ContentManager:
                    RDM_Website.RDM_LoginPage.InputUsername(utils.GetUsername(Utils.UserType.ContentManager));
                    RDM_Website.RDM_LoginPage.InputPassword(utils.GetPassword(Utils.UserType.ContentManager));
                    break;
            }
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            RDM_Website.RDM_LoginPage.ClickLogin();
            RDM_Website.RDM_Homepage.ClickAcceptCookies();
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
           Assert.AreEqual("https://preprod.raildata.org.uk/dashboard", RDM_Website.SeleniumDriver.Url, "Test Failed - URL is incorrect");
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
