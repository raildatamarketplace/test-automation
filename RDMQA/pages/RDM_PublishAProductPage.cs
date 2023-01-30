using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDMQA
{
    public class RDM_PublishAProductPage
    {
        private IWebDriver _seleniumDriver;
        private Utils utils;
        private WebDriverWait wait;
        //Sets homepage URL
        private string _publishAProductURL = AppConfigReader.DataProductURL;

        //Finding web elements
        private IWebElement _enterProductDetaisLink => _seleniumDriver.FindElement(By.XPath("//button[.='Enter product details']"));
        private IWebElement _productName => _seleniumDriver.FindElement(By.Name("name"));
        private IWebElement _productDescription => _seleniumDriver.FindElement(By.Name("description"));
        private IWebElement _nextButton => _seleniumDriver.FindElement(By.XPath("//button[.='Next Step']"));
        private IWebElement _datasourceSearchBar => _seleniumDriver.FindElement(By.XPath("//input[@placeholder='Search data source']"));
        private IReadOnlyList<IWebElement> _dataSourceRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class='ui radio checkbox']"));
        private IWebElement _tagsSearchBar => _seleniumDriver.FindElement(By.XPath("//input[@placeholder='Search tags']"));
        private IWebElement _themesSearchBar => _seleniumDriver.FindElement(By.XPath("//input[@placeholder='Search themes']"));
        private IReadOnlyList<IWebElement> _tagsMainButton => _seleniumDriver.FindElements(By.XPath("//i[@class='plus icon']"));
        private IReadOnlyList<IWebElement> _subtagsRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class='ui checkbox mr-5px']"));
        private IWebElement _firstThemeRadioButton => _seleniumDriver.FindElement(By.CssSelector(".mb-1:nth-child(1).textMedium"));
        private IReadOnlyList<IWebElement> _themesRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class='ui checkbox my-5px mr-5px']"));
        private IWebElement _dataProductCanDoTextBox => _seleniumDriver.FindElement(By.Name("dataProductCanDo"));
        private IWebElement _dataProductCannotDoTextBox => _seleniumDriver.FindElement(By.Name("dataProductCannotDo"));
        private IReadOnlyList<IWebElement> _publishButtons => _seleniumDriver.FindElements(By.XPath("//div[@class='ui radio checkbox']"));
        private IWebElement _publishImmediatelyRadioButton => _publishButtons[0];
        private IWebElement _publishScheduleRadioButton => _publishButtons[1];
        private IWebElement _retirementPolicyTextBox => _seleniumDriver.FindElement(By.Name("retirementPolicy"));
        private IReadOnlyList<IWebElement> _serviceLevelAgreementRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class='ui radio checkbox']"));
        private IWebElement _SLAYesRadioButton => _serviceLevelAgreementRadioButtons[0];
        private IWebElement _SLANoRadioButton => _serviceLevelAgreementRadioButtons[1];
        private IReadOnlyList<IWebElement> _SLAMetrics => _seleniumDriver.FindElements(By.XPath("//div[@class='ui checkbox py-5px']"));
        private IWebElement _SLAServiceUptimeRadioButton => _SLAMetrics[0];
        private IWebElement _SLAServiceUptimeTextBox => _seleniumDriver.FindElement(By.XPath("//input[@placeholder='Enter as a percentage']"));
        private IWebElement _SLAResolutionTimeRadioButton => _SLAMetrics[9];
        private IWebElement _SLAResolutionTimeTextBox => _seleniumDriver.FindElements(By.XPath("//input[@placeholder='Enter a duration in hours']"))[1];
        private IWebElement _SLAResponseTimeOutsideRadioButton => _SLAMetrics[5];
        private IWebElement _SLAResponseTimeOutsideTextBox => _seleniumDriver.FindElement(By.XPath("//input[@placeholder='Enter a duration in hours']"));
        private IReadOnlyList<IWebElement> _whoCanUseTheDataRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class ='ui radio checkbox']"));
        private IWebElement _whoCanUseTheDataAnyoneRadioButton => _whoCanUseTheDataRadioButtons[0];
        private IReadOnlyList<IWebElement> _whatCanTheDataBeUsedForRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class ='ui radio checkbox']"));
        private IWebElement _whatCanTheDataBeUsedForAcademia => _whatCanTheDataBeUsedForRadioButtons[0];
        private IReadOnlyList<IWebElement> _chargingModelRadioButtons => _seleniumDriver.FindElements(By.XPath("//div[@class ='ui radio checkbox']"));
        private IWebElement _chargingModelFree => _chargingModelRadioButtons[0];
        private IWebElement _noFairUsageLimitsRadioButton => _seleniumDriver.FindElements(By.XPath("//div[@class ='ui radio checkbox']"))[0];
        private IWebElement _yesRecommendedLicenceRadioButton => _seleniumDriver.FindElements(By.XPath("//div[@class ='ui radio checkbox']"))[0];
        private IReadOnlyList<IWebElement> _licencePageDropDowns => _seleniumDriver.FindElements(By.XPath("//div[@role ='listbox']"));
        private IWebElement _licenceTermDropDown => _licencePageDropDowns[3];
        private IWebElement _licenceNoticePeriodDropDown => _licencePageDropDowns[4];
        private IWebElement _licenceTerritorialPermissionDropDown => _licencePageDropDowns[5];
        private IWebElement _submitButton => _seleniumDriver.FindElement(By.XPath("//button[.='Submit']"));
       
        //Constructor
        public RDM_PublishAProductPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
            this.utils = new Utils(seleniumDriver);
            this.wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(5));
        }

        public void ClickProductDetails() => _enterProductDetaisLink.Click();
        public void InputDataProductName(string name) => _productName.SendKeys(name);
        public void InputDataProductDescription(string description) => _productDescription.SendKeys(description);
        public void ClickNextButton()
        {
            _nextButton.SendKeys(Keys.Enter);
        }
        public void SearchDataSource(string datasource) => _datasourceSearchBar.SendKeys(datasource);
        public void ClickDataSourceRadioButton(int input)
        {
            _dataSourceRadioButtons[input].Click();
        }
        public void SearchTags(string tag) => _tagsSearchBar.SendKeys(tag);
        public void SearchThemes(string theme) => _themesSearchBar.SendKeys(theme);
        public void ClickTagsRadioButton(int index, int subindex) 
        {
            new Actions(_seleniumDriver).MoveToElement(_tagsMainButton[index]).Click().Perform();
            _subtagsRadioButtons[subindex].Click();
        }
        public void ClickThemesRadioButton(int index)
        {
            int deltaY = _themesRadioButtons[index].Location.Y;
            new Actions(_seleniumDriver).ScrollByAmount(0, deltaY).Perform();
            new Actions(_seleniumDriver).MoveToElement(_themesRadioButtons[index]).Click().Perform();
        }
        public void InputDataProductCanDo(string description) => _dataProductCanDoTextBox.SendKeys(description);
        public void InputDataProductCantDo(string description) => _dataProductCannotDoTextBox.SendKeys(description);
        public void ClickPublishImmediatelyRadioButton() => _publishImmediatelyRadioButton.Click();
        public void InputRetirementPolicy(string description) => _retirementPolicyTextBox.SendKeys(description);
        public void ClickYesSLARadioButton() => _SLAYesRadioButton.Click();
        public void ClickSLAServiceUptimeRadioButton()
        {
            utils.MoveToLocation(_SLAServiceUptimeRadioButton);
            new Actions(_seleniumDriver).MoveToElement(_SLAServiceUptimeRadioButton).Click().Perform();
            //_SLAServiceUptimeRadioButton.Click();
        }
        public void InputSLAServiceUptimePercentage(int input) 
        {
            //Checks if value is higher than 100% if it it set it to 100
            int value = input;
            if(input > 100)
            {
                value = 100;
            }
            _SLAServiceUptimeTextBox.SendKeys(value.ToString());
        }
        public void ClickSLAResolutionTimeRadioButton()
        {
            utils.MoveToLocation(_SLAResolutionTimeRadioButton);
            new Actions(_seleniumDriver).MoveToElement(_SLAResolutionTimeRadioButton).Click().Perform();
            //_SLAResolutionTimeRadioButton.Click();
        }
        public void InputSLAResolutionTime(int input) => _SLAResolutionTimeTextBox.SendKeys(input.ToString());
        public void ClickSLAResponseTimeOutsideRadioButton()
        {
            utils.MoveToLocation(_SLAResponseTimeOutsideRadioButton);
            new Actions(_seleniumDriver).MoveToElement(_SLAResponseTimeOutsideRadioButton).Click().Perform();
            //_SLAResponseTimeOutsideRadioButton.Click();
        }
        public void InputSLAResponseTimeOutside(int input) => _SLAResponseTimeOutsideTextBox.SendKeys(input.ToString());
        public void ClickWhoCanUseTheDataRadioButton() => _whoCanUseTheDataAnyoneRadioButton.Click();
        public void ClickWhatCanTheDataBeUsedForRadioButton() => _whatCanTheDataBeUsedForAcademia.Click();
        public void ClickChargingModelRadioButton() => _chargingModelFree.Click();
        public void ClickNoFairUsageLimitsRadioButton() => _noFairUsageLimitsRadioButton.Click();
        public void ClickYesRecommendedLicenceRadioButton() => _yesRecommendedLicenceRadioButton.Click();
        /// <summary>
        /// Selecting the licence term using its name
        /// </summary>
        /// <param name="name">1 Week, 1 Year or 1 Year+</param>
        public void SelectDropDownLicenceTerm(string name)
        {
            //SelectElement dropDown = new SelectElement(_licenceTermDropDown
            //dropDown.SelectByIndex(index);
            int index = 0;
            switch (name)
            {
                case "1 Week":
                    index = 0;
                    break;
                case "1 Year":
                    index = 1;
                    break;
                case "1 Year+":
                    index = 2;
                    break;
            }
            _licenceTermDropDown.Click();
            _seleniumDriver.FindElements(By.XPath("//span[@class ='text']"))[index].Click();
        }

        public void SelectDropDownLicenceTerm(int index)
        {
            //SelectElement dropDown = new SelectElement(_licenceTermDropDown
            //dropDown.SelectByIndex(index);
            _licenceTermDropDown.Click();
            _seleniumDriver.FindElements(By.XPath("//span[@class ='text']"))[index].Click();
        }
        /// <summary>
        /// Selecting the licence notice period using its name
        /// </summary>
        /// <param name="name"> 1 Week or 1 Month</param>
        public void SelectDropDownLicenceNoticePeriod(string name)
        {
            //SelectElement dropDown = new SelectElement(_licenceNoticePeriodDropDown);
            //dropDown.SelectByIndex(index);
            int index = 0;
            switch (name)
            {
                case "1 Week":
                    index = 3;
                    break;
                case "1 Month":
                    index = 4;
                    break;
            }
            _licenceNoticePeriodDropDown.Click();
            _seleniumDriver.FindElements(By.XPath("//span[@class ='text']"))[index].Click();
        }
        public void SelectDropDownLicenceNoticePeriod(int index)
        {
            //SelectElement dropDown = new SelectElement(_licenceNoticePeriodDropDown);
            //dropDown.SelectByIndex(index);
            _licenceNoticePeriodDropDown.Click();
            _seleniumDriver.FindElements(By.XPath("//span[@class ='text']"))[index+3].Click();
        }

        /// <summary>
        /// Selecting the territorial permission using its name
        /// </summary>
        /// <param name="name">UK, UK and Europe, UK and US, UK,Europe and US, Global</param>
        public void SelectDropDownLicenceTerritorialPermission(string name)
        {
            //SelectElement dropDown = new SelectElement(_licenceTerritorialPermissionDropDown);
            //dropDown.SelectByIndex(index);
            int index = 0;
            switch (name)
            {
                case "UK":
                    index = 5;
                    break;
                case "UK and Europe":
                    index = 6;
                    break;
                case "UK and US":
                    index = 7;
                    break;
                case "UK, Europe and US":
                    index = 8;
                    break;
                case "Global":
                    index = 9;
                    break;
            }
            utils.MoveToLocation(_licenceTerritorialPermissionDropDown);
            _licenceTerritorialPermissionDropDown.Click();
            _seleniumDriver.FindElements(By.XPath("//span[@class ='text']"))[index].Click();
        }

        public void SelectDropDownLicenceTerritorialPermission(int index)
        {
            //SelectElement dropDown = new SelectElement(_licenceTerritorialPermissionDropDown);
            //dropDown.SelectByIndex(index);
            utils.MoveToLocation(_licenceTerritorialPermissionDropDown);
            _licenceTerritorialPermissionDropDown.Click();
            _seleniumDriver.FindElements(By.XPath("//span[@class ='text']"))[index+5].Click();
        }
        public void ClickSubmitButton() 
        {
            utils.MoveToLocation(_submitButton);
            _submitButton.Click();
        }

    }
}
