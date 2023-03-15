using log4net;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA.steps
{
    [Binding]
    public class RDM_RegistrationSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;
        private Utils utils;

        public RDM_RegistrationSteps(RDM_Website<ChromeDriver> rdm_website)
        {
            RDM_Website = rdm_website;
            this.utils = new Utils(RDM_Website.SeleniumDriver);
        }

        [Given(@"I have navigated to the registration page")]

        public void GivenIHaveNavigatedToTheRegistrationPage()
        {
            RDM_Website.RDM_RegistrationPage.VisitRegistrationPage();
        }

        [When(@"I have registered as a new organisation")]

        public void WhenIHaveRegisteredAsANewOrganisation()
        {
            //the whole process of registering as org should be in a "journey" file
            //and seperate out each step into seperate "when" steps here?

            RDM_Website.RDM_RegistrationPage.ClickAgreeToPlatformAgreement();
            RDM_Website.RDM_RegistrationPage.EnterTypeOfOrganisation(1);
            RDM_Website.RDM_RegistrationPage.EnterAccountName("SeleniumAutomationOrg");
            RDM_Website.RDM_RegistrationPage.EnterAddressLine1("Address Line 1");
            RDM_Website.RDM_RegistrationPage.EnterTown("AutomationTown");
            RDM_Website.RDM_RegistrationPage.EnterCounty("AutomationCounty");
            RDM_Website.RDM_RegistrationPage.EnterPostcode("Postcode");
            RDM_Website.RDM_RegistrationPage.EnterOrgEmailAddress("RDMTest@raildeliverygroup.com");
            RDM_Website.RDM_RegistrationPage.EnterUsername("test.AutomationAdmin");
            RDM_Website.RDM_RegistrationPage.EnterFirstName("Automation");
            RDM_Website.RDM_RegistrationPage.EnterLastName("User");
            RDM_Website.RDM_RegistrationPage.EnterUserPhoneNumber(0);
            RDM_Website.RDM_RegistrationPage.EnterUserEmailAddress("RDMTest@raildeliverygroup.com");
        }

        [Then("The organisation should be registered")]

        public void ThenTheOrganisationShouldBeRegistered()
        {
            //Need to integrate Gov.Notift at some point to check emails
            Assert.Equals("https://test.raildata.org.uk/registerPartner/submit", RDM_Website.SeleniumDriver.Url);
        }
    }
}
