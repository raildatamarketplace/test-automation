using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class RDM_DataProductApprovalSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;
        private ILog log;
        private ScenarioContext scenarioContext;

        public RDM_DataProductApprovalSteps(RDM_Website<ChromeDriver> rdm_website, ScenarioContext scenarioContext)
        {
            RDM_Website = rdm_website;
            this.scenarioContext = scenarioContext;
            log = Log4NetHelper.GetLogger($@"{scenarioContext.ScenarioInfo.Title} - {DateTime.UtcNow.ToString("HH-mm-ss")}", scenarioContext);
        }

        [When(@"I have navigated to the data product approval page")]
        public void WhenIHaveNavigatedToTheDataProductApprovalPage()
        {
            RDM_Website.RDM_Homepage.VisitProductAprovalsPage();
        }

        [When(@"I have clicked on the data product for approval ""(.*)""")]
        public void WhenIHaveClickedOnTheDataProductForApproval(string name)
        {
            RDM_Website.RDM_DataProductApprovalPage.FindDataProduct(name);
        }

        [When(@"I have approved the data product with a comment ""(.*)""")]
        public void WhenIHaveApprovedTheDataProductWithAComment(string comment)
        {
            RDM_Website.RDM_DataProductApprovalPage.AddReason(comment);
            RDM_Website.RDM_DataProductApprovalPage.ClickApprovalButton();
        }

        [Then(@"The data product is approved")]
        public void ThenTheDataProductIsApproved()
        {
            if(RDM_Website.RDM_DataProductApprovalPage.IsProductApproved())
            {
                log.Info("Test Passed");
                Assert.Pass();
            } else
            {
                log.Error("Test Failed - Product was not approved");
                Assert.Fail();
            }
        }
    }
}
