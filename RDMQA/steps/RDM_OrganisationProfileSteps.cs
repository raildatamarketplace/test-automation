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
    public class RDM_OrganisationProfileSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;
        private Utils utils;
        private string username;

        public RDM_OrganisationProfileSteps(RDM_Website<ChromeDriver> rdm_website)
        {
            RDM_Website = rdm_website;
            this.utils = new Utils(RDM_Website.SeleniumDriver);
        }

        /// <summary>
        ///  Add a new user role
        /// </summary>
        /// <param name="username">The username for the user</param>
        /// <param name="roleindex">The index in the dropdown that the role is (1 for the first selection and so on)</param>
        [When(@"I have added a new user ""(.*)"" ""(.*)""")]
        public void WhenIHaveAddedANewUser(string username, int roleindex)
        {
            RDM_Website.RDM_Homepage.VisitOrganisationProfilePage();
            RDM_Website.RDM_OrganisationProfilePage.NavigateToUsersTab();
            this.username = "test."+ username + "_" + utils.GetNewUsernameNumber();
            //Likely need a test email address for automation?
            RDM_Website.RDM_OrganisationProfilePage.AddNewUser(this.username, 
                roleindex, "Test", "User", 0, "RDMTest+"+ utils.GetUsernameNumber() +"@raildeliverygroup.com"); ;
        }

        [Then(@"The new user is added to the organisation")]

        public void ThenTheNewUserIsAddedToTheOrganisation()
        {
            //This could check for the email being sent/user being active with Gov.Notify integration
            //Something to look into in the future. Currently just checking if the add user functionality
            //works and not if the user can create a password etc

            Assert.AreEqual(username, RDM_Website.SeleniumDriver.FindElement(By.XPath("//span[.='"+ username + "']")).Text, "Test Failed - Username can't be found"); ;
        }
    }
}
