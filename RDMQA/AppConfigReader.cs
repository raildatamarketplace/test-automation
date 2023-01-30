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
        public static readonly string DataProductNumber = ConfigurationManager.AppSettings["dataproduct_number"];
        public static readonly string ProductApprovalURL = ConfigurationManager.AppSettings["dataapproval_url"];

        public static void UpdateValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var entry = config.AppSettings.Settings[key];
            if(entry == null)
            {
                config.AppSettings.Settings.Add(key, value);
            } else
            {
                config.AppSettings.Settings[key].Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);

        }
    }
}
