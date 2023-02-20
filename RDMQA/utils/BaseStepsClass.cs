using log4net;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA
{
    [Binding]
    public class BaseStepsClass
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;
        private ILog log;

        protected void UITest(Action action, ScenarioContext scenarioContext, IWebDriver driver, ILog log)
        {
            this.scenarioContext= scenarioContext;
            this.driver = driver;
            this.log = log;
            try
            {
                action();
            }
            catch (Exception ex)
            {            
                Screenshot screenshot = driver.TakeScreenshot();

                string dir = $@"({scenarioContext.ScenarioInfo.Title}) - {DateTime.UtcNow.Date.ToString("dd-MM-yyyy")}";
                string imageName = Log4NetHelper.GetFileName();
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);
                string imagePath = Path.Combine(path, imageName);
                // If directory does not exist, create it
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                screenshot.SaveAsFile($@"{imagePath}.png", ScreenshotImageFormat.Png);

                log.Error(ex);
                // This would be a good place to log the exception message and
                // save together with the screenshot

                throw;
            }
        }
    }
}
