using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using RDMQA.steps;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RDMQA
{
    [Binding]
    public class RDM_DataProductApprovalJourneySteps
    {
        private RDM_DataProductApprovalSteps steps;
        private Utils utils;
        private RDM_Website<ChromeDriver> RDM_Website;

        public RDM_DataProductApprovalJourneySteps(RDM_Website<ChromeDriver> rdm_website, RDM_DataProductApprovalSteps steps)
        {
            RDM_Website = rdm_website;
            this.steps = steps;
            this.utils = new Utils(rdm_website.SeleniumDriver);
        }

        [When(@"I have approved a data product")]

        public void WhenIHaveApprovedADataProduct()
        {
            steps.WhenIHaveNavigatedToTheDataProductApprovalPage();
            steps.WhenIHaveClickedOnTheDataProductForApproval("DataProductSelenium" + utils.GetDataProductNumber());
            steps.WhenIHaveApprovedTheDataProductWithAComment("Approved with Selenium");
        }

        [When(@"I have approved the data product ""(.*)""")]

        public void WhenIHaveApprovedADataProduct(string name)
        {
            steps.WhenIHaveNavigatedToTheDataProductApprovalPage();
            steps.WhenIHaveClickedOnTheDataProductForApproval(name);
            steps.WhenIHaveApprovedTheDataProductWithAComment("Approved with Selenium");
        }

    }
}
