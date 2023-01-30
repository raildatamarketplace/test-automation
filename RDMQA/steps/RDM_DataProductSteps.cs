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
    public class RDM_DataProductSteps
    {
        private RDM_Website<ChromeDriver> RDM_Website;

        public RDM_DataProductSteps(RDM_Website<ChromeDriver> rdm_website)
        {
            RDM_Website = rdm_website;
        }

        [When(@"I have navigated to create a Data Product")]
        public void WhenIHaveNavigatedToCreateADataProduct()
        {
            RDM_Website.RDM_Homepage.ClickAcceptCookies();
            RDM_Website.RDM_Homepage.VisitDataProductsPage();
            RDM_Website.RDM_MyDataProductPage.ClickPublish();
        }

        [When(@"I have entered ""(.*)"" in the name field")]

        public void WhenIHaveEnteredIntoTheNameField(string name)
        {
            RDM_Website.RDM_PublishAProductPage.ClickProductDetails();
            RDM_Website.RDM_PublishAProductPage.InputDataProductName(name);
        }

        [When(@"I have entered ""(.*)"" in the description field")]

        public void WhenIHaveEnteredIntoTheDescriptionField(string description)
        {
            RDM_Website.RDM_PublishAProductPage.InputDataProductDescription(description);
        }

        [When(@"I have clicked the next step button")]

        public void WhenIHaveClickedTheNextStepButton()
        {
            RDM_Website.RDM_PublishAProductPage.ClickNextButton();
        }

        [When(@"I have searched for and selected this data source ""(.*)""")]

        public void WhenIHaveSearchedForAndSelectedThisDataSource(string searchValue)
        {
            RDM_Website.RDM_PublishAProductPage.SearchDataSource(searchValue);
            RDM_Website.RDM_PublishAProductPage.ClickDataSourceRadioButton(0);
        }

        [When(@"I have selected the data source at index ""(.*)""")]

        public void WhenIHaveSelectedTheDataSource(int index)
        {
            RDM_Website.RDM_PublishAProductPage.ClickDataSourceRadioButton(index);
        }

        [When(@"I have selected the tag ""(.*)"" and subtag ""(.*)""")]

        public void WhenIHaveSelectedTheTag(string searchValue, int index)
        {
            RDM_Website.RDM_PublishAProductPage.SearchTags(searchValue);
            RDM_Website.RDM_PublishAProductPage.ClickTagsRadioButton(0, index);
        }

        [When(@"I have selected the theme ""(.*)""")]

        public void WhenIHaveSelectedTheTheme(string searchValue)
        {
            RDM_Website.RDM_PublishAProductPage.SearchThemes(searchValue);
            RDM_Website.RDM_PublishAProductPage.ClickThemesRadioButton(0);
        }

        [When(@"I have entered ""(.*)"" in what the data product can do")]

        public void WhenIHaveEnteredInWhatTheDataProductCanDo(string description)
        {
            RDM_Website.RDM_PublishAProductPage.InputDataProductCanDo(description);
        }

        [When(@"I have entered ""(.*)"" in what the data product cant do")]

        public void WhenIHaveEnteredInWhatTheDataProductCantDo(string description)
        {
            RDM_Website.RDM_PublishAProductPage.InputDataProductCantDo(description);
        }

        [When(@"I have entered ""(.*)"" in the retirement policy")]

        public void WhenIHaveEnteredInTheRetirementPolicy(string description)
        {
            RDM_Website.RDM_PublishAProductPage.InputRetirementPolicy(description);
        }

        [When(@"I have clicked immediate publishing after approval")]

        public void WhenIHaveClickedImmediatePublishingAfterApproval()
        {
            RDM_Website.RDM_PublishAProductPage.ClickPublishImmediatelyRadioButton();
        }

        [When(@"I have clicked yes to the SLA")]

        public void WhenIHaveClickedYesToTheSLA()
        {
            RDM_Website.RDM_PublishAProductPage.ClickYesSLARadioButton();
        }

        [When(@"I have entered ""(.*)"" into the service uptime percentage")]

        public void WhenIHaveEnteredIntoTheServiceUptimePercentage(int percentage)
        {
            RDM_Website.RDM_PublishAProductPage.ClickSLAServiceUptimeRadioButton();
            RDM_Website.RDM_PublishAProductPage.InputSLAServiceUptimePercentage(percentage);
        }

        [When(@"I have entered ""(.*)"" into the response time outside business hours")]

        public void WhenIHaveEnteredIntoTheResponseTimeOutsideBusinessHours(int hours)
        {
            RDM_Website.RDM_PublishAProductPage.ClickSLAResponseTimeOutsideRadioButton();
            RDM_Website.RDM_PublishAProductPage.InputSLAResponseTimeOutside(hours);
        }

        [When(@"I have entered ""(.*)"" into the resolution time outside business hours")]

        public void WhenIHaveEnteredIntoTheResolutionTimeOutsideBusinessHours(int hours)
        {
            RDM_Website.RDM_PublishAProductPage.ClickSLAResolutionTimeRadioButton();      
            RDM_Website.RDM_PublishAProductPage.InputSLAResolutionTime(hours);
        }

        [When(@"I have selected who can use the data")]

        public void WhenIHaveSelectedWhoCanUseTheData()
        {
            RDM_Website.RDM_PublishAProductPage.ClickWhoCanUseTheDataRadioButton();
        }

        [When(@"I have selected what the data can be used for")]

        public void WhenIHaveSelectedWhatTheDataCanBeUsedFor()
        {
            RDM_Website.RDM_PublishAProductPage.ClickWhatCanTheDataBeUsedForRadioButton();
        }

        [When(@"I have selected the charging model")]

        public void WhenIHaveSelectedTheChargingModel()
        {
            RDM_Website.RDM_PublishAProductPage.ClickChargingModelRadioButton();
        }

        [When(@"I have selected the fair usage limit")]

        public void WhenIHaveSelectedTheFairUsageLimit()
        {
            RDM_Website.RDM_PublishAProductPage.ClickNoFairUsageLimitsRadioButton();
        }

        [When(@"I have selected my recommended licence")]

        public void WhenIHaveSelectedMyRecommendedLicence()
        {
            RDM_Website.RDM_PublishAProductPage.ClickYesRecommendedLicenceRadioButton();
        }

        [When(@"I have selected my licence term length to be ""(.*)""")]

        public void WhenIHaveSelectedMyLicenceTermLengthToBe(int index)
        {
            RDM_Website.RDM_PublishAProductPage.SelectDropDownLicenceTerm(index);
        }

        [When(@"I have selected my licence term length to be ""(.*)""")]

        public void WhenIHaveSelectedMyLicenceTermLengthToBe(string name)
        {
            RDM_Website.RDM_PublishAProductPage.SelectDropDownLicenceTerm(name);
        }

        [When(@"I have selected my notice period length to be ""(.*)""")]

        public void WhenIHaveSelectedMyNoticePeriodLengthToBe(int index)
        {
            RDM_Website.RDM_PublishAProductPage.SelectDropDownLicenceNoticePeriod(index);
        }

        [When(@"I have selected my notice period length to be ""(.*)""")]

        public void WhenIHaveSelectedMyNoticePeriodLengthToBe(string name)
        {
            RDM_Website.RDM_PublishAProductPage.SelectDropDownLicenceNoticePeriod(name);
        }

        [When(@"I have selected my territorial permissions to be ""(.*)""")]

        public void WhenIHaveSelectedMyTerritorialPermissionsToBe(int index)
        {
            RDM_Website.RDM_PublishAProductPage.SelectDropDownLicenceTerritorialPermission(index);
        }

        [When(@"I have selected my territorial permissions to be ""(.*)""")]

        public void WhenIHaveSelectedMyTerritorialPermissionsToBe(string name)
        {
            RDM_Website.RDM_PublishAProductPage.SelectDropDownLicenceTerritorialPermission(name);
        }

        [When(@"I have clicked submit")]

        public void WhenIHaveClickedSubmit()
        {
            RDM_Website.RDM_PublishAProductPage.ClickSubmitButton();
        }

        [Then(@"I should be taken to the submit confirmation page")]
        public void ThenIShouldBeTakenToTheSubmitConfirmationPage()
        {
            Thread.Sleep(3000);
            Assert.That(RDM_Website.SeleniumDriver.Url, Does.Contain("/submit"));
        }
    }
}
