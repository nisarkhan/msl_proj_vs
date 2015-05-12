using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{
    public class DataEntryViewModel
    {
        public DataEntryViewModel()
        {
            ClientSystemViewModel = new List<ClientSystemViewModel>();
            MaintenanceViewModel = new List<MaintenanceViewModel>();
            SystemComplianceViewModel = new List<SystemComplianceViewModel>(); 
        }

        public List<ClientSystemViewModel> ClientSystemViewModel { get; set; }
        public List<MaintenanceViewModel> MaintenanceViewModel { get; set; }
        public List<SystemComplianceViewModel> SystemComplianceViewModel { get; set; }

    }
}