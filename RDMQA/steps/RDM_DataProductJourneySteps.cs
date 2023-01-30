using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V106.Debugger;
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
    public class RDM_DataProductJourneySteps
    {
        private DataProduct _dataProductInformation = new DataProduct();
        private RDM_DataProductSteps steps;
        private Utils utils;
        private RDM_Website<ChromeDriver> RDM_Website;

        public RDM_DataProductJourneySteps(RDM_Website<ChromeDriver> rdm_website, RDM_DataProductSteps steps)
        {
            RDM_Website = rdm_website;
            this.steps = steps;
            this.utils = new Utils(rdm_website.SeleniumDriver);
        }

        /// <summary>
        /// Default publish a data product
        /// </summary>
        [When(@"I have published a data product")]
        public void WhenIHavePublishedADataProduct()
        {
            steps.WhenIHaveNavigatedToCreateADataProduct();
            steps.WhenIHaveEnteredIntoTheNameField("DataProductSelenium" + utils.GetNewDataProductNumber());
            steps.WhenIHaveEnteredIntoTheDescriptionField("Automated testing of creating a data product using selenium");
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSearchedForAndSelectedThisDataSource("API Authentication Test");
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedTheTag("Freight", 0);
            steps.WhenIHaveSelectedTheTheme("Another Theme");
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveEnteredInWhatTheDataProductCanDo("Something the data product can do");
            steps.WhenIHaveEnteredInWhatTheDataProductCantDo("Something the data product can't do");
            steps.WhenIHaveEnteredInTheRetirementPolicy("Some retirement policy");
            steps.WhenIHaveClickedImmediatePublishingAfterApproval();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedYesToTheSLA();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveEnteredIntoTheServiceUptimePercentage(99);
            steps.WhenIHaveEnteredIntoTheResponseTimeOutsideBusinessHours(48);
            steps.WhenIHaveEnteredIntoTheResolutionTimeOutsideBusinessHours(48);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedWhoCanUseTheData();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedWhatTheDataCanBeUsedFor();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedTheChargingModel();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedTheFairUsageLimit();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedMyRecommendedLicence();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedMyLicenceTermLengthToBe(1);
            steps.WhenIHaveSelectedMyNoticePeriodLengthToBe(1);
            steps.WhenIHaveSelectedMyTerritorialPermissionsToBe(4);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedSubmit();
            steps.ThenIShouldBeTakenToTheSubmitConfirmationPage();
        }

        /// <summary>
        /// Custom data product with information filled out in the table
        /// </summary>
        /// <param name="table">Util Table with all the information for creating a data product</param>
        [When(@"I have created a data product with the information:")]
        public void WhenIHaveCreatedADataProductWithTheInformation(Table table)
        {
            _dataProductInformation = table.CreateInstance<DataProduct>();
            steps.WhenIHaveNavigatedToCreateADataProduct();
            steps.WhenIHaveEnteredIntoTheNameField(_dataProductInformation.DataProductName + utils.GetNewDataProductNumber());
            steps.WhenIHaveEnteredIntoTheDescriptionField(_dataProductInformation.DataProductDescription);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSearchedForAndSelectedThisDataSource(_dataProductInformation.DataSourceName);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedTheTag(_dataProductInformation.TagName, _dataProductInformation.SubTagNumber);
            steps.WhenIHaveSelectedTheTheme(_dataProductInformation.ThemeName);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveEnteredInWhatTheDataProductCanDo(_dataProductInformation.DataProductCanDescription);
            steps.WhenIHaveEnteredInWhatTheDataProductCantDo(_dataProductInformation.DataProductCantDescription);
            steps.WhenIHaveEnteredInTheRetirementPolicy(_dataProductInformation.DataProductRetirementDescription);
            steps.WhenIHaveClickedImmediatePublishingAfterApproval();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedYesToTheSLA();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveEnteredIntoTheServiceUptimePercentage(_dataProductInformation.SLAServiceUptimeNumber);
            steps.WhenIHaveEnteredIntoTheResponseTimeOutsideBusinessHours(_dataProductInformation.SLAResponseTimeOutsideBusinessHoursNumber);
            steps.WhenIHaveEnteredIntoTheResolutionTimeOutsideBusinessHours(_dataProductInformation.SLAResolutionTimeOutsideBusinessHoursNumber);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedWhoCanUseTheData();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedWhatTheDataCanBeUsedFor();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedTheChargingModel();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedTheFairUsageLimit();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedMyRecommendedLicence();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveSelectedMyLicenceTermLengthToBe(_dataProductInformation.LicenceTermLength);
            steps.WhenIHaveSelectedMyNoticePeriodLengthToBe(_dataProductInformation.NoticePeriodLength);
            steps.WhenIHaveSelectedMyTerritorialPermissionsToBe(_dataProductInformation.TerritorialPermissions);
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedTheNextStepButton();
            steps.WhenIHaveClickedSubmit();
        }

    }
}
