using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RDMQA
{
    public class RDM_Website<T> where T : IWebDriver, new()
    {
        public IWebDriver SeleniumDriver { get; set; }
        public RDM_Homepage RDM_Homepage { get; set; }
        public RDM_LoginPage RDM_LoginPage { get; set; }
        public RDM_MyDataProductPage RDM_MyDataProductPage { get; set; }    
        public RDM_PublishAProductPage RDM_PublishAProductPage { get; set; }
        public RDM_DataProductApprovalPage RDM_DataProductApprovalPage { get; set; }
        public RDM_OrganisationProfilePage RDM_OrganisationProfilePage { get; set; }
        public RDM_RegistrationPage RDM_RegistrationPage { get; set; }

        public RDM_Website(ILog log, int pageLoadInSecs = 30, int impicitWaitInSecs = 30)
        {
            //Setup Selenium Driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, impicitWaitInSecs).Driver;

            //Setup page objects with selenium driver
            RDM_Homepage = new RDM_Homepage(SeleniumDriver, log);
            RDM_LoginPage = new RDM_LoginPage(SeleniumDriver, log);
            RDM_MyDataProductPage = new RDM_MyDataProductPage(SeleniumDriver);
            RDM_PublishAProductPage = new RDM_PublishAProductPage(SeleniumDriver);
            RDM_DataProductApprovalPage = new RDM_DataProductApprovalPage(SeleniumDriver);
            RDM_OrganisationProfilePage = new RDM_OrganisationProfilePage(SeleniumDriver, log);
            RDM_RegistrationPage = new RDM_RegistrationPage(SeleniumDriver, log);
        }
    }
}
