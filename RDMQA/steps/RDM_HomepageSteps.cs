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
using System.Web.UI.WebControls.WebParts;
using TechTalk.SpecFlow;

namespace RDMQA
{
    [Binding]
    public class RDM_HomepageSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;

        public RDM_HomepageSteps(RDM_Website<ChromeDriver> rdm_website)
        {
            RDM_Website = rdm_website;
        }

        [When(@"I have navigated to the dashboard homepage")]
        public void WhenIAmOnTHeDashboardHomepage()
        {
            RDM_Website.RDM_Homepage.VisitDashboardHomepage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Specify one of 6 user types</param>
        [Then(@"The navigation bar should display correctly for the ""(.*)"" user")]
        public void ThenTheNavigationBarShouldDisplayCorrectly(string user)
        {
            switch(user.ToLower())
            {
                case "consumer":
                    List<string> Cnavigation = new List<string> { "Home", "Data product catalogue",
                    "Subscriptions", "Organisations", "Help and support"};
                    Assert.AreEqual(Cnavigation, RDM_Website.RDM_Homepage.CheckNavigationUI());
                    break;
                case "finance approver":
                    List<string> FAnavigation = new List<string> { "Home", "Data product catalogue", "Manage",
                    "Overview", "My sales","My products","My data sources","Details",
                    "Product approvals","Transaction approvals", "Subscriptions", "Organisations", "Help and support"};
                    Assert.AreEqual(FAnavigation, RDM_Website.RDM_Homepage.CheckNavigationUI());
                    break;
                case "financially authorised consumer":
                    List<string> FACnavigation = new List<string> { "Home", "Data product catalogue", "Manage",
                    "Details","Transaction approvals", "Subscriptions", "Organisations", "Help and support"};
                    Assert.AreEqual(FACnavigation, RDM_Website.RDM_Homepage.CheckNavigationUI());
                    break;
                case "org admin":
                    List<string> OAnavigation = new List<string> { "Home", "Data product catalogue", "Manage",
                    "Overview", "My sales","My products","My data sources","Details",
                    "Product approvals","Product statistics","Transaction approvals",
                    "Subscriptions", "Organisations", "Help and support"};
                    Assert.AreEqual(OAnavigation, RDM_Website.RDM_Homepage.CheckNavigationUI());
                    break;
                case "publisher":
                    List<string> Pnavigation = new List<string> { "Home", "Data product catalogue", "Manage",
                    "Overview", "My sales","My products","My data sources","Details",
                    "Subscriptions", "Organisations", "Help and support"};
                    Assert.AreEqual(Pnavigation, RDM_Website.RDM_Homepage.CheckNavigationUI());
                    break;
                case "rdm admin":
                    List<string> RDMnavigation = new List<string> { "Home", "Data product catalogue", "Manage",
                    "Overview", "My sales","My products","My data sources","Details",
                    "Manage organisations","Product approvals","Product statistics","Transactions",
                    "Tags","Themes","Alert users","Reports",
                    "Subscriptions", "Organisations", "Help and support"};
                    Assert.AreEqual(RDMnavigation, RDM_Website.RDM_Homepage.CheckNavigationUI());
                    break;
            }
        }

    }
}
