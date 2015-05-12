using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSL.Helper
{
    public class ExtractFormCollectionData
    {
        public List<ExcelViewModel> XtractFormCollectionData(FormCollection formCollection)
        {
            int i = 0;
            List<ExcelViewModel> excelDataList = new List<ExcelViewModel>();
            ExcelViewModel model = new ExcelViewModel(); 
          
            foreach (string formData in formCollection)
            {
                if (formData == "rowNumber_" + i)
                {
                    model.RowNumber = formCollection[formData].ToString();
                }
                else if (formData == "selectedRow_" + i)
                {
                    model.SelectedRowId = formCollection[formData].ToString();
                }
                else if (formData == "Customer_" + i)
                {
                    model.Customer = formCollection[formData].ToString();
                }
                else if (formData == "LocalName_" + i)
                {
                    model.LocalName = formCollection[formData].ToString();
                }
                else if (formData == "SerialNumber_" + i)
                {
                    model.SerialNumber = formCollection[formData].ToString();
                }
                else if (formData == "SystemState_" + i)
                {
                    model.SystemState = formCollection[formData].ToString();
                }
                else if (formData == "ServerType_" + i)
                {
                    model.ServerType = formCollection[formData].ToString();
                }
                else if (formData == "Category_" + i)
                {
                    model.Category = formCollection[formData].ToString();
                }
                else if (formData == "ServiceCategory_" + i)
                {
                    model.ServiceCategory = formCollection[formData].ToString();
                }
                else if (formData == "Country_" + i)
                {
                    model.Country = formCollection[formData].ToString();
                }
                else if (formData == "Domain_" + i)
                {
                    model.Domain = formCollection[formData].ToString();
                }
                else if (formData == "IsLocalSecurity_" + i)
                {
                    model.IsLocalSecurity = formCollection[formData].ToString();
                }
                else if (formData == "SecurityWaiver_" + i)
                {
                    model.SecurityWaiver = formCollection[formData].ToString();
                }
                else if (formData == "SecurityWaiverNotes_" + i)
                {
                    model.SecurityWaiverNotes = formCollection[formData].ToString();
                }
                else if (formData == "OS_" + i)
                {
                    model.OS = formCollection[formData].ToString();
                }
                else if (formData == "OSMinor_" + i)
                {
                    model.OSMinor = formCollection[formData].ToString();
                }
                else if (formData == "OSPatchLevel_" + i)
                {
                    model.OSPatchLevel = formCollection[formData].ToString();
                }
                else if (formData == "KernelPatch_" + i)
                {
                    model.KernelPatch = formCollection[formData].ToString();
                }
                else if (formData == "PatchingGroup_" + i)
                {
                    model.PatchingGroup = formCollection[formData].ToString();
                }
                else if (formData == "ServiceIP_" + i)
                {
                    model.ServiceIP = formCollection[formData].ToString();
                }
                else if (formData == "ServiceFQDN_" + i)
                {
                    model.ServiceFQDN = formCollection[formData].ToString();
                }
                else if (formData == "ConsoleAccess_" + i)
                {
                    model.ConsoleAccess = formCollection[formData].ToString();
                }
                else if (formData == "CPUCores_" + i)
                {
                    model.CPUCores = formCollection[formData].ToString(); //Convert.ToInt16(formCollection[formData]); 
                }
                else if (formData == "CPUCount_" + i)
                {
                    model.CPUCount = formCollection[formData].ToString();
                }
                else if (formData == "CPUModel_" + i)
                {
                    model.CPUModel = formCollection[formData].ToString();
                }
                else if (formData == "CPUSpeed_" + i)
                {
                    model.CPUSpeed = formCollection[formData].ToString();
                }
                else if (formData == "LocalDiskCapacity_" + i)
                {
                    model.LocalDiskCapacity = formCollection[formData].ToString();
                }
                else if (formData == "LocalDiskSlotTotal_" + i)
                {
                    model.LocalDiskSlotTotal = formCollection[formData].ToString();
                }
                else if (formData == "LocalDiskInstalled_" + i)
                {
                    model.LocalDiskInstalled = formCollection[formData].ToString();
                }
                else if (formData == "LocalRaidLevel_" + i)
                {
                    model.LocalRaidLevel = formCollection[formData].ToString();
                }
                else if (formData == "PhysicalMemory_" + i)
                {
                    model.PhysicalMemory = formCollection[formData].ToString();
                }
                else if (formData == "PurchaseDate_" + i)
                {
                    model.PurchaseDate = Convert.ToDateTime(formCollection[formData]);
                }
                else if (formData == "Ownership_" + i)
                {
                    model.Ownership = formCollection[formData].ToString();
                }
                else if (formData == "TimeZone_" + i)
                {
                    model.TimeZone = formCollection[formData].ToString();
                }
                else if (formData == "StreetAddress_" + i)
                {
                    model.StreetAddress = formCollection[formData].ToString();
                }
                else if (formData == "RegulationCompliance_" + i)
                {
                    model.RegulationCompliance = formCollection[formData].ToString();
                }
                else if (formData == "InCluster_" + i)
                {
                    model.InCluster = formCollection[formData].ToString();
                    //if (model.InCluster.Length > )
                }
                else if (formData == "RebootAutomatic_" + i)
                {
                    model.RebootAutomatic = formCollection[formData].ToString();
                }
                else if (formData == "RebootNotes_" + i)
                {
                    model.RebootNotes = formCollection[formData].ToString();
                }
                else if (formData == "MasterBackupServer_" + i)
                {
                    model.MasterBackupServer = formCollection[formData].ToString();
                }
                else if (formData == "BackupIP_" + i)
                {
                    model.BackupIP = formCollection[formData].ToString();
                }
                else if (formData == "VMPlatform_" + i)
                {
                    model.VMPlatform = formCollection[formData].ToString();
                }
                else if (formData == "VMHost_" + i)
                {
                    model.VMHost = formCollection[formData].ToString();
                }
                else if (formData == "PrimaryApplication_" + i)
                {
                    model.PrimaryApplication = formCollection[formData].ToString();
                }
                else if (formData == "BackupAgent_" + i)
                {
                    model.BackupAgent = formCollection[formData].ToString();
                }
                else if (formData == "MonitorAgent_" + i)
                {
                    model.MonitorAgent = formCollection[formData].ToString();
                }
                else if (formData == "Location_" + i)
                {
                    model.Location = formCollection[formData].ToString();
                }
                else if (formData == "RackShelf_" + i)
                {
                    model.RackShelf = formCollection[formData].ToString(); // Convert.ToInt16(formCollection[formData]);
                }
                else if (formData == "DCLocation_" + i)
                {
                    model.DCLocation = formCollection[formData].ToString();
                }
                else if (formData == "Model_" + i)
                {
                    model.Model = formCollection[formData].ToString();
                }
                else if (formData == "Vendor_" + i)
                {
                    model.Vendor = formCollection[formData].ToString();
                }
                else if (formData == "AssetTag_" + i)
                {
                    model.AssetTag = formCollection[formData].ToString();
                }
                else if (formData == "SunHostId_" + i) //new
                {
                    model.SunHostId = formCollection[formData].ToString();
                }
                else if (formData == "UseState_" + i) //new
                {
                    model.UseState = formCollection[formData].ToString();
                }
                else if (formData == "WarrantyEndDate_" + i)
                {
                    model.WarrantyEndDate = Convert.ToDateTime(formCollection[formData]);

                    i++;
                    excelDataList.Add(model);
                    model = new ExcelViewModel();
                }
            }
            return excelDataList;
        }

    }
}