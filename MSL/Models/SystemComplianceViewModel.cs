using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{
    public class SystemComplianceViewModel
    {
        public string ServerState { get; set; }
        public string ApplicationSystemUse { get; set; }
       
        public string AssetTag { get; set; }
        public string BackupClientAgentNameVersion { get; set; }
        public string BackupMaster { get; set; }
        public string BackupType { get; set; }
        public string Comment { get; set; }
        public string CPUCoresCPU { get; set; }


     
        public string NumberCPUs { get; set; }
        public string CPUSockets { get; set; }
        public string CPUSpeedMHz { get; set; }
        public string DataCenterLocation { get; set; }
        public string DNSDomain { get; set; }
        public string GlobalSupportAccessRestriction { get; set; }

        public string GridLocation { get; set; }
        public string HardwareModel { get; set; }
        public string Manufacturer { get; set; }
        public string HostID { get; set; }
        public string InternalDrivesDriveCapacity { get; set; }
        public string IPAddress { get; set; }
        public string ClusterName { get; set; }
        public string KernelPatch { get; set; }
        public string MemoryGB { get; set; }
        public string PrescriptiveServiceLevel { get; set; }
        public string Processor { get; set; }
        public string InitialDeploymentDate { get; set; }
        public string RAIDLevel { get; set; }
        public string RoomFloor { get; set; }
        public string NetworkSpaceStorageSANName { get; set; }
        public string NetworkSpaceStorageAllocatedGB { get; set; }
        public string FunctionalDescription { get; set; }
        public string ServerCategory { get; set; }
        public string ServerUsageType { get; set; }
        public string StreetAddress { get; set; }
        public string SupportOrganization { get; set; }
        public string SupportTeam { get; set; }
        public string TimeZone { get; set; }
        public string XENHOST { get; set; }

    }
}