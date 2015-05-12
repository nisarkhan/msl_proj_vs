using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{
    public class MaintenanceViewModel
    {
        public bool CoveredDRContract { get; set; }
        public string HWWarrantyInformationContract  { get; set; }
        public string PatchingGroup { get; set; }
        public string RebootDescription { get; set; }
        public string SWSupportVendor { get; set; } 

    }
}