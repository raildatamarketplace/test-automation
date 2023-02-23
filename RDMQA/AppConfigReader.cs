using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDMQA
{
    class AppConfigReader
    {
        public static readonly string HomepageURL = ConfigurationManager.AppSettings["homepage_url"];
        public static readonly string LoginURL = ConfigurationManager.AppSettings["login_url"];
        public static readonly string DataProductURL = ConfigurationManager.AppSettings["dataproduct_url"];
        public static readonly string PublishAProductURL = ConfigurationManager.AppSettings["publishaproduct_url"];
        public static readonly string ProductApprovalURL = ConfigurationManager.AppSettings["dataapproval_url"];
        public static readonly string DashboardHomepageURL = ConfigurationManager.AppSettings["dashboardHomepage_url"];
    }
}
