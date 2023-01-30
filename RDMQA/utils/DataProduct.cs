using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDMQA
{
    public class DataProduct
    {
        public string DataProductName { get; set; }
        public string DataProductDescription { get; set;}
        public string DataSourceName { get; set; }
        public string TagName { get; set; }
        public int SubTagNumber { get; set; }
        public string ThemeName { get; set; }
        public string DataProductCanDescription { get; set; }
        public string DataProductCantDescription { get; set; }
        public string DataProductRetirementDescription { get; set; }
        public int SLAServiceUptimeNumber { get; set; }
        public int SLAResponseTimeOutsideBusinessHoursNumber { get;  set; }
        public int SLAResolutionTimeOutsideBusinessHoursNumber { get; set; }
        public string LicenceTermLength { get; set; }
        public string NoticePeriodLength { get; set; }
        public string TerritorialPermissions { get; set; }

    }
}
