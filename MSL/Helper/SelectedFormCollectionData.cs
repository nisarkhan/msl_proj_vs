using MSL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSL.Helper
{
    public class SelectedFormCollectionData
    {
        public List<ExcelViewModel> SelectedRowFormCollection(FormCollection formCollection)
        {
            //List<ExcelViewModel> formCollectionDataLoaded = new List<ExcelViewModel>();

            //var asDictionary = formCollection.Cast<string>()
            //    //.Where(key => key.StartsWith(prefix))
            //    .ToDictionary(key => key, key => formCollection[key])
            //    .ToList();

            //var newDictionary = asDictionary.ToDictionary(r => r.Key, r => r.Value);
            //var ordered = newDictionary.Keys.OrderByDescending(k => newDictionary[k]).ToList();

            //var ordered1 = asDictionary.GroupBy(n => n)
            //      .OrderByDescending(g => g.Count())
            //      .Select(g => g.Key)
            //      .ToList();
            //var ordered2 = (from n in asDictionary
            //               group n by n into g
            //               orderby g.Count() descending
            //               select g.Key).ToList();

            //int i = 0;
            //ExcelViewModel model = new ExcelViewModel();

            ExtractFormCollectionData xtract = new ExtractFormCollectionData();
            return xtract.XtractFormCollectionData(formCollection);

            //foreach (string formData in formCollection)
            //{
            //    if (formData == "rowNumber_" + i)
            //    {
            //        model.RowNumber = formCollection[formData];
            //    }
            //    else if (formData == "selectedRow_" + i)
            //    {
            //        model.SelectedRowId = formCollection[formData];
            //    }
            //    else if (formData == "Customer_" + i)
            //    {
            //        model.Customer = formCollection[formData];
            //    }
            //    else if (formData == "LocalName_" + i)
            //    {
            //        model.LocalName = formCollection[formData];
            //    }
            //    else if (formData == "SerialNumber_" + i)
            //    {
            //        model.SerialNumber = formCollection[formData];
            //    }
            //    else if (formData == "SystemState_" + i)
            //    {
            //        model.SystemState = formCollection[formData];
            //    }
            //    else if (formData == "ServerType_" + i)
            //    {
            //        model.ServerType = formCollection[formData];
            //    }
            //    else if (formData == "Category_" + i)
            //    {
            //        model.Category = formCollection[formData];
            //    }
            //    else if (formData == "ServiceCategory_" + i)
            //    {
            //        model.ServiceCategory = formCollection[formData];
            //    }
            //    else if (formData == "Country_" + i)
            //    {
            //        model.Country = formCollection[formData];
            //    }
            //    else if (formData == "Domain_" + i)
            //    {
            //        model.Domain = formCollection[formData];
            //    }
            //    else if (formData == "IsLocalSecurity_" + i)
            //    {
            //        model.IsLocalSecurity = formCollection[formData];
            //    }
            //    else if (formData == "SecurityWaiver_" + i)
            //    {
            //        model.SecurityWaiver = formCollection[formData];
            //    }
            //    else if (formData == "SecurityWaiverNotes_" + i)
            //    {
            //        model.SecurityWaiverNotes = formCollection[formData];
            //    }
            //    else if (formData == "OS_" + i)
            //    {
            //        model.OS = formCollection[formData];
            //    }
            //    else if (formData == "OSMinor_" + i)
            //    {
            //        model.OSMinor = formCollection[formData];
            //    }
            //    else if (formData == "OSPatchLevel_" + i)
            //    {
            //        model.OSPatchLevel = formCollection[formData];
            //    }
            //    else if (formData == "KernelPatch_" + i)
            //    {
            //        model.KernelPatch = formCollection[formData];
            //    }
            //    else if (formData == "PatchingGroup_" + i)
            //    {
            //        model.PatchingGroup = formCollection[formData];
            //    }
            //    else if (formData == "ServiceIP_" + i)
            //    {
            //        model.ServiceIP = formCollection[formData];
            //    }
            //    else if (formData == "ServiceFQDN_" + i)
            //    {
            //        model.ServiceFQDN = formCollection[formData];
            //    }
            //    else if (formData == "ConsoleAccess_" + i)
            //    {
            //        model.ConsoleAccess = formCollection[formData];
            //    }
            //    else if (formData == "CPUCores_" + i)
            //    {
            //        model.CPUCores = Convert.ToInt16(formCollection[formData]); //formCollection[formData];
            //    }
            //    else if (formData == "CPUCount_" + i)
            //    {
            //        model.CPUCount = Convert.ToInt16(formCollection[formData]);
            //    }
            //    else if (formData == "CPUModel_" + i)
            //    {
            //        model.CPUModel = formCollection[formData];
            //    }
            //    else if (formData == "CPUSpeed_" + i)
            //    {
            //        model.CPUSpeed = formCollection[formData];
            //    }
            //    else if (formData == "LocalDiskCapacity_" + i)
            //    {
            //        model.LocalDiskCapacity = formCollection[formData];
            //    }
            //    else if (formData == "LocalDiskSlotTotal_" + i)
            //    {
            //        model.LocalDiskSlotTotal = Convert.ToInt16(formCollection[formData]);
            //    }
            //    else if (formData == "LocalDiskInstalled_" + i)
            //    {
            //        model.LocalDiskInstalled = formCollection[formData];
            //    }
            //    else if (formData == "LocalRaidLevel_" + i)
            //    {
            //        model.LocalRaidLevel = formCollection[formData];
            //    }
            //    else if (formData == "PhysicalMemory_" + i)
            //    {
            //        model.PhysicalMemory = formCollection[formData];
            //    }
            //    else if (formData == "PurchaseDate_" + i)
            //    {
            //        model.PurchaseDate = Convert.ToDateTime(formCollection[formData]);
            //    }
            //    else if (formData == "Ownership_" + i)
            //    {
            //        model.Ownership = formCollection[formData];
            //    }
            //    else if (formData == "TimeZone_" + i)
            //    {
            //        model.TimeZone = formCollection[formData];
            //    }
            //    else if (formData == "StreetAddress_" + i)
            //    {
            //        model.StreetAddress = formCollection[formData];
            //    }
            //    else if (formData == "RegulationCompliance_" + i)
            //    {
            //        model.RegulationCompliance = formCollection[formData];
            //    }
            //    else if (formData == "InCluster_" + i)
            //    {
            //        model.InCluster = formCollection[formData];
            //    }
            //    else if (formData == "RebootAutomatic_" + i)
            //    {
            //        model.RebootAutomatic = formCollection[formData];
            //    }
            //    else if (formData == "RebootNotes_" + i)
            //    {
            //        model.RebootNotes = formCollection[formData];
            //    }
            //    else if (formData == "MasterBackupServer_" + i)
            //    {
            //        model.MasterBackupServer = formCollection[formData];
            //    }
            //    else if (formData == "BackupIP_" + i)
            //    {
            //        model.BackupIP = formCollection[formData];
            //    }
            //    else if (formData == "VMPlatform_" + i)
            //    {
            //        model.VMPlatform = formCollection[formData];
            //    }
            //    else if (formData == "VMHost_" + i)
            //    {
            //        model.VMHost = formCollection[formData];
            //    }
            //    else if (formData == "PrimaryApplication_" + i)
            //    {
            //        model.PrimaryApplication = formCollection[formData];
            //    }
            //    else if (formData == "BackupAgent_" + i)
            //    {
            //        model.BackupAgent = formCollection[formData];
            //    }
            //    else if (formData == "MonitorAgent_" + i)
            //    {
            //        model.MonitorAgent = formCollection[formData];
            //    }
            //    else if (formData == "Location_" + i)
            //    {
            //        model.Location = formCollection[formData];
            //    }
            //    else if (formData == "RackShelf_" + i)
            //    {
            //        model.RackShelf = Convert.ToInt16(formCollection[formData]);
            //    }
            //    else if (formData == "DCLocation_" + i)
            //    {
            //        model.DCLocation = formCollection[formData];
            //    }
            //    else if (formData == "Model_" + i)
            //    {
            //        model.Model = formCollection[formData];
            //    }
            //    else if (formData == "Vendor_" + i)
            //    {
            //        model.Vendor = formCollection[formData];
            //    }
            //    else if (formData == "AssetTag_" + i)
            //    {
            //        model.AssetTag = formCollection[formData];
            //    }
            //    else if (formData == "WarrantyEndDate_" + i)
            //    {
            //        model.WarrantyEndDate = Convert.ToDateTime(formCollection[formData]);

            //        i++;                    
            //        formCollectionDataLoaded.Add(model);
            //        model = new ExcelViewModel();
            //    } 
            //}
            //return formCollectionDataLoaded;
        }

    }
}