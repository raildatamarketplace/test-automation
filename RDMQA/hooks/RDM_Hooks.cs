using BoDi;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using RDMQA.steps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA.hooks
{
    [Binding]
    public class RDM_Hooks
    {

        private IObjectContainer _objectContainer;
        public RDM_Website<ChromeDriver> RDM_Website;
        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private ILog log;

        public RDM_Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }
        
        [BeforeScenario]
        public void InitWebDriver()
        {
            string featureDir = $@"({featureContext.FeatureInfo.Title}) - {DateTime.UtcNow.Date.ToString("dd-MM-yyyy")}";
            string featureFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log Files", featureDir);

            // If directory does not exist, create it
            if (!Directory.Exists(featureFolderPath))
            {
                Directory.CreateDirectory(featureFolderPath);
            }
            log = Log4NetHelper.GetLogger($@"{scenarioContext.ScenarioInfo.Title} - {DateTime.UtcNow.ToString("HH-mm-ss")}", scenarioContext, featureContext);
            RDM_Website = new RDM_Website<ChromeDriver>(log);
            _objectContainer.RegisterInstanceAs<RDM_Website<ChromeDriver>>(RDM_Website);
        }
        
        [AfterScenario]
        public void DisposeWebDriver()
        {
            string featureDir = $@"({featureContext.FeatureInfo.Title}) - {DateTime.UtcNow.Date.ToString("dd-MM-yyyy")}";
            string scenarioDir = $@"({scenarioContext.ScenarioInfo.Title}) - {DateTime.UtcNow.Date.ToString("dd-MM-yyyy")}";
            string imageName = Log4NetHelper.GetFileName();
            string scenarioFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log Files", featureDir, scenarioDir);
            string imagePath = Path.Combine(scenarioFolderPath, imageName);
            
            // If directory does not exist, create it
            if (!Directory.Exists(scenarioFolderPath))
            {
                Directory.CreateDirectory(scenarioFolderPath);
            }

            //Checking if Test has passed or failed for screenshot.
            if (scenarioContext.TestError == null)
            {
                //Test Passed
                log.Info("Test Passed");
            } else
            {
                //Test Failed
                Screenshot screenshot = RDM_Website.SeleniumDriver.TakeScreenshot();
                screenshot.SaveAsFile($@"{imagePath}.png", ScreenshotImageFormat.Png);
                log.Error(scenarioContext.TestError);
            }

            RDM_Website.SeleniumDriver.Quit();
            RDM_Website.SeleniumDriver.Dispose();
        }
    }
}
