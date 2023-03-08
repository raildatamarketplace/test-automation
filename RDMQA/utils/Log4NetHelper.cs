using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TechTalk.SpecFlow;
using System.Runtime.CompilerServices;

namespace RDMQA
{
    public class Log4NetHelper
    {
        private static readonly string _layout = "%date{dd MMM yyyy HH:mm:ss} [%level] - %message%newline";
        private static readonly string _appenderName = "FileAppender";
        private static ScenarioContext scenarioContext;
        private static FeatureContext featureContext;   
        private static string fileName;

        private static PatternLayout GetPatternLayout()
        {
            PatternLayout patternLayout = new PatternLayout
            {
                ConversionPattern = _layout
            };

            patternLayout.ActivateOptions();

            return patternLayout;
        }

        private static FileAppender GetFileAppender()
        {
            string featureDir = $@"({featureContext.FeatureInfo.Title}) - {DateTime.UtcNow.Date.ToString("dd-MM-yyyy")}";
            string scenarioDir = $@"({scenarioContext.ScenarioInfo.Title}) - {DateTime.UtcNow.Date.ToString("dd-MM-yyyy")}";
            string scenarioFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log Files", featureDir, scenarioDir);
            string filePath = Path.Combine(scenarioFolderPath, fileName);
            var fileAppender = new FileAppender
            {
                Name = _appenderName,
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = false,
                File = $@"{filePath}.log"
                //Do we want seperate log files by date? 
                //This needs to go into their own folders
            };

            fileAppender.ActivateOptions();

            return fileAppender;
        }

        public static ILog GetLogger(string _fileName, ScenarioContext _scenarioContext, FeatureContext _featureContext)
        { 
            fileName = _fileName;
            // Remember to clear old logger
            Logger root = ((Hierarchy)LogManager.GetRepository()).Root;
            root.RemoveAppender(_appenderName);
            scenarioContext = _scenarioContext;
            featureContext = _featureContext;

            BasicConfigurator.Configure(GetFileAppender());

            return LogManager.GetLogger(fileName);
        }

        public static string GetFileName()
        {
            return fileName;
        }

        public static void SetFileName(string _fileName)
        {
            fileName = _fileName;
        }
    }
}
