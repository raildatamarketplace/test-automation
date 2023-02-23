using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA
{
    [Binding]
    public class RDM_LoginJourneySteps
    {
        private RDM_LoginSteps steps;
        private RDM_Website<ChromeDriver> RDM_Website;

        public RDM_LoginJourneySteps(RDM_Website<ChromeDriver> rdm_website, RDM_LoginSteps _steps)
        {
            RDM_Website = rdm_website;
            steps = _steps;
        }

        [Given(@"I have logged in as a Consmer")]
        public void GivenIHaveLoggedInAsAConsumer()
        {
            steps.GivenIAmOnTheLoginPage();
            steps.GivenIHaveEnteredInTheUsernameField("test.LNConsumer");
            steps.GivenIHaveEnteredInThePasswordField("TestPassword123$");
            steps.WhenIClickTheLoginButton();
            steps.WhenIWaitForSeconds(3);
            steps.ThenIShouldBeTakenToTheDashboardHomepage();
        }

        [Given(@"I have logged in as a Publisher")]
        public void GivenIHaveLoggedInAsAPublisher()
        {
            steps.GivenIAmOnTheLoginPage();
            steps.GivenIHaveEnteredInTheUsernameField("test.LNPublisher");
            steps.GivenIHaveEnteredInThePasswordField("TestPassword123$");
            steps.WhenIClickTheLoginButton();
            steps.WhenIWaitForSeconds(3);
            steps.ThenIShouldBeTakenToTheDashboardHomepage();
        }

        [Given(@"I have logged in as a Org Admin")]
        public void GivenIHaveLoggedInAsAOrgAdmin()
        {
            steps.GivenIAmOnTheLoginPage();
            steps.GivenIHaveEnteredInTheUsernameField("test.LNAdmin");
            steps.GivenIHaveEnteredInThePasswordField("TestPassword123$");
            steps.WhenIClickTheLoginButton();
            steps.WhenIWaitForSeconds(3);
            steps.ThenIShouldBeTakenToTheDashboardHomepage();
        }

        [Given(@"I have logged in as a RDM Admin")]
        public void GivenIHaveLoggedInAsARDMAdmin()
        {
            steps.GivenIAmOnTheLoginPage();
            steps.GivenIHaveEnteredInTheUsernameField("test.RDMadminLiam");
            steps.GivenIHaveEnteredInThePasswordField("TestPassword123$");
            steps.WhenIClickTheLoginButton();
            steps.WhenIWaitForSeconds(3);
            steps.ThenIShouldBeTakenToTheDashboardHomepage();
        }

        [Given(@"I have logged in as a Financially Authorised Consumer")]
        public void GivenIHaveLoggedInAsAFinanciallyAuthorisedConsumer()
        {
            steps.GivenIAmOnTheLoginPage();
            steps.GivenIHaveEnteredInTheUsernameField("test.LNFinanceConsumer");
            steps.GivenIHaveEnteredInThePasswordField("TestPassword123$");
            steps.WhenIClickTheLoginButton();
            steps.WhenIWaitForSeconds(3);
            steps.ThenIShouldBeTakenToTheDashboardHomepage();
        }

        [Given(@"I have logged in as a Finance Approver")]
        public void GivenIHaveLoggedInAsAFinanceApprover()
        {
            steps.GivenIAmOnTheLoginPage();
            steps.GivenIHaveEnteredInTheUsernameField("test.FinanceApprover");
            steps.GivenIHaveEnteredInThePasswordField("TestPassword123$");
            steps.WhenIClickTheLoginButton();
            steps.WhenIWaitForSeconds(5);
            steps.ThenIShouldBeTakenToTheDashboardHomepage();
        }
    }
}
