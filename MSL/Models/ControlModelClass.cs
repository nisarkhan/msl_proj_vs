using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{
    public partial class MSLMasterViewModel
        {
            public int id { get; set; }
            public string customer { get; set; }
            public string localname { get; set; }
            public string serialnumber { get; set; }
            public string system_state { get; set; }
            public string server_type { get; set; }
            public string category { get; set; }
            public string service_category { get; set; }
            public string country { get; set; }
            public string domain { get; set; }
            public string is_local_security { get; set; }
            public string security_waiver { get; set; }
            public string security_waiver_notes { get; set; }
            public string os { get; set; }
            public string os_minor { get; set; }
            public string os_patch_level { get; set; }
            public string kernel_patch { get; set; }
            public string patching_group { get; set; }
            public string service_ip { get; set; }
            public string service_fqdn { get; set; }
            public string console_access { get; set; }
            public Nullable<int> cpu_cores { get; set; }
            public Nullable<int> cpu_count { get; set; }
            public string cpu_model { get; set; }
            public string cpu_speed { get; set; }
            public string local_disk_capacity { get; set; }
            public Nullable<int> local_disk_slot_total { get; set; }
            public string local_disk_installed { get; set; }
            public string local_raid_level { get; set; }
            public string physical_memory { get; set; }
            public Nullable<System.DateTime> purchase_date { get; set; }
            public string sun_host_id { get; set; }
            public string time_zone { get; set; }
            public string street_address { get; set; }
            public string regulation_compliance { get; set; }
            public string in_cluster { get; set; }
            public string reboot_automatic { get; set; }
            public string reboot_notes { get; set; }
            public string master_backup_server { get; set; }
            public string backup_ip { get; set; }
            public string vm_platform { get; set; }
            public string vm_host { get; set; }
            public string primary_application { get; set; }
            public string backup_agent { get; set; }
            public string monitor_agent { get; set; }
            public string location { get; set; }
            public Nullable<int> rack_shelf { get; set; }
            public string dc_location { get; set; }
            public string model { get; set; }
            public string use_state { get; set; }
            public string asset_tag { get; set; }
            public Nullable<System.DateTime> warranty_end_date { get; set; }
        }
  
    public partial class ClientCostCenterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CostCenter { get; set; }
        public int Count { get; set; }
    }

    public partial class ServerStatesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
    }

    public partial class ServerTypesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
    }

    public partial class ServerCategoriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
    }

    public partial class ServiceCateogoriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
        public string Impact { get; set; }
        public string Urgency { get; set; }
    }

    public partial class OSTypesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OSVendor { get; set; }
        public string OSType { get; set; }
        public string OSCategory { get; set; }
        public string Count { get; set; }
    }

    public partial class VMPlatFormsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
    }

    public partial class BackupAgentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
    }

    public partial class MonitoringAgentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }

    }

    public partial class SiteLocationsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
        public string TotalMeasured { get; set; }
        public string KWHMeasured { get; set; }
        public string GoogleMapAddress { get; set; }
    }

    public partial class ModelTypesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public string KW { get; set; }
        public string PlatForm { get; set; }

    }
}