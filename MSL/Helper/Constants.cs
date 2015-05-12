using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Helper
{
    public class Constants
    {

        const string _select_records = ("show all records, show invalid records, show valid records" );
        const string _select_page_size = ("10, 25, 50, all");
        public static readonly string[] SELECT_RECORD_ARRAY_LIST = _select_records.Split(',');
        public static readonly string[] SELECT_PAGE_SIZE_ARRAY_LIST = _select_page_size.Split(',');

        public const string PAGE_SIZE_ALL = "ALL";

        public const string SAVE_TO_DB = "save to db";
        public const string REMOVE_ITEM_FROM_GRID = "remove item from grid";
        public const string VALIDATE_DATA = "validate data";
        
        public const string REFRESH_GRID = "refresh grid";
        public const string SHOW_ALL_RECORDS = "show all records";
        public const string SHOW_INVALID_RECORDS = "show invalid records";
        public const string SHOW_VALID_RECORDS = "show valid records";


        public const string ICON_DB_LENGTH = "<span class=\"fa fa-database redcolor\" </span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=\"fa fa-chain-broken redcolor\" </span>";
        public const string ICON_DB = "<span class=\"fa fa-database redcolor\" </span>";
        public const string ICON_LENGTH = "<span class=\"fa fa-chain-broken redcolor\" </span>";


        public const string ERROR_DB = "does not exists in the db";
        public const string ERROR_LENGTH = "cannot be longer than"; 



        public const string Customer = "Customer";
        public const string LocalName = "LocalName";
        public const string SerialNumber = "SerialNumber";
        public const string SystemState = "SystemState";
        public const string ServerType = "ServerType";
        public const string Category = "Category";
        public const string ServiceCategory = "ServiceCategory";
        public const string Country = "Country";
        public const string Domain = "Domain";
        public const string IsLocalSecurity = "IsLocalSecurity";
        public const string SecurityWaiver = "SecurityWaiver";         
        public const string SecurityWaiverNotes = "SecurityWaiverNotes";         
        public const string OS = "OS";         
        public const string OSMinor = "OSMinor";         
        public const string OSPatchLevel = "OSPatchLevel";         
        public const string KernelPatch = "KernelPatch";         
        public const string PatchingGroup = "PatchingGroup";         
        public const string ServiceIP = "ServiceIP";         
        public const string ServiceFQDN = "ServiceFQDN";         
        public const string ConsoleAccess = "ConsoleAccess";
        public const string CPUCores = "CPUCores";
        public const string CPUCount = "CPUCount";         
        public const string CPUModel = "CPUModel";         
        public const string CPUSpeed = "CPUSpeed";         
        public const string LocalDiskCapacity = "LocalDiskCapacity";
        public const string LocalDiskSlotTotal = "LocalDiskSlotTotal";         
        public const string LocalDiskInstalled = "LocalDiskInstalled";         
        public const string LocalRaidLevel = "LocalRaidLevel";         
        public const string PhysicalMemory = "PhysicalMemory";
        public const string PurchaseDate = "Customer"; 
        public const string Ownership = "Ownership";
        public const string SunHostId = "SunHostId";
        public const string UseState = "UseState";
        public const string TimeZone = "TimeZone";
        public const string StreetAddress = "StreetAddress";
        public const string RegulationCompliance = "RegulationCompliance";
        public const string InCluster = "InCluster";
        public const string RebootAutomatic = "RebootAutomatic";
        public const string RebootNotes = "RebootNotes";
        public const string MasterBackupServer = "MasterBackupServer";
        public const string BackupIP = "BackupIP";
        public const string VMPlatform = "VMPlatform";
        public const string VMHost = "VMHost";
        public const string PrimaryApplication = "PrimaryApplication";
        public const string BackupAgent = "BackupAgent";
        public const string MonitorAgent = "MonitorAgent";
        public const string Location = "Location";
        public const string RackShelf = "RackShelf";
        public const string DCLocation = "DCLocation";
        public const string Model = "Model";
        public const string Vendor = "Vendor";
        public const string AssetTag = "AssetTag";
        public const string WarrantyEndDate = "WarrantyEndDate"; 
         
    }
}