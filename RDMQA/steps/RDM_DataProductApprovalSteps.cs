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

        public RDM_DataProductApprovalSteps(RDM_Website<ChromeDriver> rdm_website)
        {
            RDM_Website = rdm_website;
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
            Assert.IsTrue(RDM_Website.RDM_DataProductApprovalPage.IsProductApproved());
        }
    }
}
