using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSL.Models
{ 
    public class ExcelViewModel
    {
        public ExcelViewModel()
        {
            //ViewIconOnView = new List<ViewIconDisplay>();
            SetValidationFailed = new ValidationFailedModel();

            Validations = new List<ValidateDataViewModel>();

            //used for holding the failed and passed data validation.
            ValidationFailed = new List<ExcelViewModel>();
            ValidationPassed = new List<ExcelViewModel>();
        }

        public List<ExcelViewModel> ValidationFailed { get; set; }
        public List<ExcelViewModel> ValidationPassed { get; set; }  
        public ValidationFailedModel SetValidationFailed { get; set; } 
        public List<ValidateDataViewModel> Validations { get; set; }
        public bool IsValidationError { get; set; }

        public string RowNumber { get; set; }
        public string SelectedRowId { get; set; }

        [StringLength(80, ErrorMessage = "Customer cannot be longer than 80 characters.")] 
        public string Customer { get; set; }

        [StringLength(60, ErrorMessage = "LocalName cannot be longer than 60 characters.")] 
        public string LocalName { get; set; }

        [StringLength(128, ErrorMessage = "SerialNumber cannot be longer than 128 characters.")] 
        public string SerialNumber { get; set; }

        [StringLength(20, ErrorMessage = "SystemState cannot be longer than 20 characters.")] 
        public string SystemState { get; set; }

        [StringLength(30, ErrorMessage = "ServerType cannot be longer than 30 characters.")] 
        public string ServerType { get; set; }

        [StringLength(60, ErrorMessage = "Category cannot be longer than 60 characters.")] 
        public string Category { get; set; }

        [StringLength(60, ErrorMessage = "ServiceCategory cannot be longer than 60 characters.")] 
        public string ServiceCategory { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters.")] 
        public string Country { get; set; }

        [StringLength(128, ErrorMessage = "Domain cannot be longer than 128 characters.")] 
        public string Domain { get; set; }

        [StringLength(10, ErrorMessage = "IsLocalSecurity cannot be longer than 10 characters.")] 
        public string IsLocalSecurity { get; set; }

        [StringLength(60, ErrorMessage = "SecurityWaiver cannot be longer than 60 characters.")] 
        public string SecurityWaiver { get; set; }

        [StringLength(128, ErrorMessage = "SecurityWaiverNotes cannot be longer than 128 characters.")] 
        public string SecurityWaiverNotes { get; set; }

        [StringLength(80, ErrorMessage = "OS cannot be longer than 80 characters.")] 
        public string OS { get; set; }

        [StringLength(60, ErrorMessage = "OSMinor cannot be longer than 60 characters.")] 
        public string OSMinor { get; set; }

        [StringLength(160, ErrorMessage = "OSPatchLevel cannot be longer than 160 characters.")] 
        public string OSPatchLevel { get; set; }

        [StringLength(100, ErrorMessage = "KernelPatch cannot be longer than 100 characters.")] 
        public string KernelPatch { get; set; }

        [StringLength(60, ErrorMessage = "PatchingGroup cannot be longer than 60 characters.")] 
        public string PatchingGroup { get; set; }

        [StringLength(60, ErrorMessage = "ServiceIP cannot be longer than 60 characters.")] 
        public string ServiceIP { get; set; }

        [StringLength(128, ErrorMessage = "ServiceFQDN cannot be longer than 128 characters.")] 
        public string ServiceFQDN { get; set; }

        [StringLength(128, ErrorMessage = "ConsoleAccess cannot be longer than 128 characters.")] 
        public string ConsoleAccess { get; set; }

        [StringLength(5, ErrorMessage = "CPUCores cannot be longer than 5 characters.")]
        public string CPUCores { get; set; }

        [StringLength(5, ErrorMessage = "CPUCount cannot be longer than 5 characters.")]
        public string CPUCount { get; set; }

        [StringLength(80, ErrorMessage = "CPUModel cannot be longer than 80 characters.")] 
        public string CPUModel { get; set; }

        [StringLength(60, ErrorMessage = "CPUSpeed cannot be longer than 60 characters.")] 
        public string CPUSpeed { get; set; }

        [StringLength(255, ErrorMessage = "LocalDiskCapacity cannot be longer than 255 characters.")] 
        public string LocalDiskCapacity { get; set; }

        [StringLength(5, ErrorMessage = "LocalDiskSlotTotal cannot be longer than 5 characters.")]
        public string LocalDiskSlotTotal { get; set; }

        [StringLength(40, ErrorMessage = "LocalDiskInstalled cannot be longer than 40 characters.")] 
        public string LocalDiskInstalled { get; set; }

        [StringLength(30, ErrorMessage = "LocalRaidLevel cannot be longer than 30 characters.")] 
        public string LocalRaidLevel { get; set; }

        [StringLength(20, ErrorMessage = "PhysicalMemory cannot be longer than 20 characters.")] 
        public string PhysicalMemory { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PurchaseDate { get; set; }

        [StringLength(80, ErrorMessage = "Ownership cannot be longer than 80 characters.")] 
        public string Ownership { get; set; }

        [StringLength(128, ErrorMessage = "SunHostId cannot be longer than 128 characters.")]
        public string SunHostId { get; set; }

        [StringLength(20, ErrorMessage = "UseState cannot be longer than 20 characters.")]
        public string UseState { get; set; }

        [StringLength(80, ErrorMessage = "TimeZone cannot be longer than 80 characters.")] 
        public string TimeZone { get; set; }

        [StringLength(200, ErrorMessage = "StreetAddress cannot be longer than 200 characters.")] 
        public string StreetAddress { get; set; }


        [StringLength(60, ErrorMessage = "RegulationCompliance cannot be longer than 60 characters.")] 
        public string RegulationCompliance { get; set; }

        [StringLength(10, ErrorMessage = "InCluster cannot be longer than 10 characters.")] 
        public string InCluster { get; set; }

        [StringLength(10, ErrorMessage = "RebootAutomatic cannot be longer than 10 characters.")] 
        public string RebootAutomatic { get; set; }

        [StringLength(100, ErrorMessage = "RebootNotes cannot be longer than 100 characters.")] 
        public string RebootNotes { get; set; }

        [StringLength(128, ErrorMessage = "MasterBackupServer cannot be longer than 128 characters.")] 
        public string MasterBackupServer { get; set; }

        [StringLength(15, ErrorMessage = "BackupIP cannot be longer than 15 characters.")] 
        public string BackupIP { get; set; }

        [StringLength(60, ErrorMessage = "VMPlatform cannot be longer than 60 characters.")] 
        public string VMPlatform { get; set; }

        [StringLength(128, ErrorMessage = "VMHost cannot be longer than 128 characters.")] 
        public string VMHost { get; set; }

        [StringLength(255, ErrorMessage = "PrimaryApplication cannot be longer than 255 characters.")] 
        public string PrimaryApplication { get; set; }

        [StringLength(60, ErrorMessage = "BackupAgent cannot be longer than 60 characters.")] 
        public string BackupAgent { get; set; }

        [StringLength(60, ErrorMessage = "MonitorAgent cannot be longer than 60 characters.")] 
        public string MonitorAgent { get; set; }

        [StringLength(60, ErrorMessage = "Location cannot be longer than 60 characters.")] 
        public string Location { get; set; }

        [StringLength(10, ErrorMessage = "RackShelf cannot be longer than 10 characters.")] 
        public string RackShelf { get; set; }

        [StringLength(128, ErrorMessage = "DCLocation cannot be longer than 128 characters.")] 
        public string DCLocation { get; set; }

        [StringLength(60, ErrorMessage = "Model cannot be longer than 60 characters.")] 
        public string Model { get; set; }

        [StringLength(80, ErrorMessage = "Vendor cannot be longer than 80 characters.")] 
        public string Vendor { get; set; }

        [StringLength(30, ErrorMessage = "AssetTag cannot be longer than 30 characters.")] 
        public string AssetTag { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WarrantyEndDate { get; set; }
        
    }

   
}