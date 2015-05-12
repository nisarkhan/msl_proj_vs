using MSL.Helper.Session;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web; 

namespace MSL.Helper
{
    public static class UpsertClass
    {
        public static List<DisplayMessage> UpsertData()
        {
            List<ExcelViewModel> excelData = SessionWrapper.GetSession_Model().DataModel.OrderBy(x => x.LocalName).ToList();

            List<DisplayMessage> messages = new List<DisplayMessage>();
            DisplayMessage msg = new DisplayMessage();

            //reset
            msg.NoChangesCount = 0;

            using (var context = new mls_dbEntities())
            {
                var dbData = context.tko_msl_master.OrderBy(x => x.localname).ToList();

                if (dbData.Count > 0)
                {
                    foreach (var dbItem in dbData)
                    {
                        foreach (var xlData in excelData)
                        {
                            var dbEntity = dbData.Find(x => x.localname == xlData.LocalName);
                            bool isChanged = false;

                            //List<ExcelViewModel> entityToViewModelDb = AutoMapperHelper.EntityToViewModelDb(dbData);
                            //List<ExcelViewModel> entityToViewModelExcel = AutoMapperHelper.EntityToViewModelExcel(excelData);
                            //var diffListOfData = entityToViewModelDb.Where(x => !entityToViewModelExcel.Any(x1 => x1.LocalName == x.LocalName)).ToList();

                            //update on the field/column/cell that has been modified or changed
                            if (dbItem.localname == xlData.LocalName)
                            {
                                #region
                                if (!dbItem.asset_tag.Equals(xlData.AssetTag))
                                {
                                    dbEntity.asset_tag = xlData.AssetTag;
                                    isChanged = true; 
                                }
                                else if (!dbItem.backup_agent.Equals(xlData.BackupAgent))
                                {
                                    dbEntity.backup_agent = xlData.BackupAgent;
                                    isChanged = true; 
                                }
                                else if (!dbItem.backup_ip.Equals(xlData.BackupIP))
                                {
                                    dbEntity.backup_ip = xlData.BackupIP;
                                    isChanged = true; 
                                }
                                else if (!dbItem.category.Equals(xlData.Category))
                                {
                                    dbEntity.category = xlData.Category;
                                    isChanged = true; 
                                }
                                else if (!dbItem.console_access.Equals(xlData.ConsoleAccess))
                                {
                                    dbEntity.console_access = xlData.ConsoleAccess;
                                    isChanged = true; 
                                }
                                else if (!dbItem.country.Equals(xlData.Country))
                                {
                                    dbEntity.country = xlData.Country;
                                    isChanged = true; 
                                }
                                else if (!dbItem.cpu_cores.Equals(xlData.CPUCores))
                                {
                                    dbEntity.cpu_cores = xlData.CPUCores;
                                    isChanged = true; 
                                }
                                else if (!dbItem.cpu_count.Equals(xlData.CPUCount))
                                {
                                    dbEntity.cpu_count = xlData.CPUCount;
                                    isChanged = true; 
                                }
                                else if (!dbItem.cpu_model.Equals(xlData.CPUModel))
                                {
                                    dbEntity.cpu_model = xlData.CPUModel;
                                }
                                else if (!dbItem.cpu_speed.Equals(xlData.CPUSpeed))
                                {
                                    dbEntity.cpu_speed = xlData.CPUSpeed;
                                    isChanged = true; 
                                }
                                if (!dbItem.customer.Equals(xlData.Customer))
                                {
                                    dbEntity.customer = xlData.Customer;
                                    isChanged = true; 
                                }
                                else if (!dbItem.dc_location.Equals(xlData.DCLocation))
                                {
                                    dbEntity.dc_location = xlData.DCLocation;
                                    isChanged = true; 
                                }
                                else if (!dbItem.domain.Equals(xlData.Domain))
                                {
                                    dbEntity.domain = xlData.Domain;
                                    isChanged = true; 
                                }
                                else if (!dbItem.in_cluster.Equals(xlData.InCluster))
                                {
                                    dbEntity.in_cluster = xlData.InCluster;
                                    isChanged = true; 
                                }
                                else if (!dbItem.is_local_security.Equals(xlData.IsLocalSecurity))
                                {
                                    dbEntity.is_local_security = xlData.IsLocalSecurity;
                                    isChanged = true; 
                                }
                                else if (!dbItem.kernel_patch.Equals(xlData.KernelPatch))
                                {
                                    dbEntity.kernel_patch = xlData.KernelPatch;
                                    isChanged = true; 
                                }
                                else if (!dbItem.local_disk_capacity.Equals(xlData.LocalDiskCapacity))
                                {
                                    dbEntity.local_disk_capacity = xlData.LocalDiskCapacity;
                                    isChanged = true; 
                                }
                                else if (!dbItem.local_disk_installed.Equals(xlData.LocalDiskInstalled))
                                {
                                    dbEntity.local_disk_installed = xlData.LocalDiskInstalled;
                                    isChanged = true; 
                                }
                                else if (!dbItem.local_disk_slot_total.Equals(xlData.LocalDiskSlotTotal))
                                {
                                    dbEntity.local_disk_slot_total = xlData.LocalDiskSlotTotal;
                                    isChanged = true; 
                                }
                                else if (!dbItem.local_raid_level.Equals(xlData.LocalRaidLevel))
                                {
                                    dbEntity.local_raid_level = xlData.LocalRaidLevel;
                                    isChanged = true; 
                                }
                                else if (!dbItem.localname.Equals(xlData.LocalName))
                                {
                                    dbEntity.localname = xlData.LocalName;
                                    isChanged = true; 
                                }
                                else if (!dbItem.location.Equals(xlData.Location))
                                {
                                    dbEntity.location = xlData.Location;
                                    isChanged = true; 
                                }
                                else if (!dbItem.master_backup_server.Equals(xlData.MasterBackupServer))
                                {
                                    dbEntity.master_backup_server = xlData.MasterBackupServer;
                                    isChanged = true; 
                                }
                                else if (!dbItem.model.Equals(xlData.Model))
                                {
                                    dbEntity.model = xlData.Model;
                                    isChanged = true; 
                                }
                                else if (!dbItem.monitor_agent.Equals(xlData.MonitorAgent))
                                {
                                    dbEntity.monitor_agent = xlData.MonitorAgent;
                                    isChanged = true; 
                                }
                                else if (!dbItem.os.Equals(xlData.OS))
                                {
                                    dbEntity.os = xlData.OS;
                                    isChanged = true; 
                                }
                                else if (!dbItem.os_minor.Equals(xlData.OSMinor))
                                {
                                    dbEntity.os_minor = xlData.OSMinor;
                                    isChanged = true; 
                                }
                                else if (!dbItem.os_patch_level.Equals(xlData.OSPatchLevel))
                                {
                                    dbEntity.os_patch_level = xlData.OSPatchLevel;
                                    isChanged = true; 
                                }
                                else if (!dbItem.patching_group.Equals(xlData.PatchingGroup))
                                {
                                    dbEntity.patching_group = xlData.PatchingGroup;
                                    isChanged = true; 
                                }
                                else if (!dbItem.physical_memory.Equals(xlData.PhysicalMemory))
                                {
                                    dbEntity.physical_memory = xlData.PhysicalMemory;
                                    isChanged = true; 
                                }
                                else if (!dbItem.primary_application.Equals(xlData.PrimaryApplication))
                                {
                                    dbEntity.primary_application = xlData.PrimaryApplication;
                                    isChanged = true; 
                                }
                                else if (!dbItem.purchase_date.Value.Equals(xlData.PurchaseDate))
                                {
                                    dbEntity.purchase_date = xlData.PurchaseDate;
                                    isChanged = true; 
                                }
                                else if (!dbItem.rack_shelf.Equals(xlData.RackShelf))
                                {
                                    dbEntity.rack_shelf = xlData.RackShelf;
                                    isChanged = true; 
                                }
                                else if (!dbItem.reboot_automatic.Equals(xlData.RebootAutomatic))
                                {
                                    dbEntity.reboot_automatic = xlData.RebootAutomatic;
                                    isChanged = true; 
                                }
                                else if (!dbItem.reboot_notes.Equals(xlData.RebootNotes))
                                {
                                    dbEntity.reboot_notes = xlData.RebootNotes;
                                    isChanged = true; 
                                }
                                else if (!dbItem.regulation_compliance.Equals(xlData.RegulationCompliance))
                                {
                                    dbEntity.regulation_compliance = xlData.RegulationCompliance;
                                    isChanged = true; 
                                }
                                else if (!dbItem.security_waiver.Equals(xlData.SecurityWaiver))
                                {
                                    dbEntity.security_waiver = xlData.SecurityWaiver;
                                    isChanged = true; 
                                }
                                else if (!dbItem.security_waiver_notes.Equals(xlData.SecurityWaiverNotes))
                                {
                                    dbEntity.security_waiver_notes = xlData.SecurityWaiverNotes;
                                    isChanged = true; 
                                }
                                else if (!dbItem.serialnumber.Equals(xlData.SerialNumber))
                                {
                                    dbEntity.serialnumber = xlData.SerialNumber;
                                    isChanged = true;
                                }
                                else if (!dbItem.server_type.Equals(xlData.ServerType))
                                {
                                    dbEntity.server_type = xlData.ServerType;
                                    isChanged = true; 
                                }
                                else if (!dbItem.service_category.Equals(xlData.ServiceCategory))
                                {
                                    dbEntity.service_category = xlData.ServiceCategory;
                                    isChanged = true; 
                                }
                                else if (!dbItem.service_fqdn.Equals(xlData.ServiceFQDN))
                                {
                                    dbEntity.service_fqdn = xlData.ServiceFQDN;
                                    isChanged = true; 
                                }
                                else if (!dbItem.service_ip.Equals(xlData.ServiceIP))
                                {
                                    dbEntity.service_ip = xlData.ServiceIP;
                                    isChanged = true; 
                                }
                                else if (!dbItem.street_address.Equals(xlData.StreetAddress))
                                {
                                    dbEntity.street_address = xlData.StreetAddress;
                                    isChanged = true; 
                                }
                                else if (dbItem.sun_host_id != null)
                                { 
                                    if (!dbItem.sun_host_id.Equals(xlData.SunHostId))
                                    {
                                        dbEntity.sun_host_id = xlData.SunHostId;
                                        isChanged = true; 
                                    }
                                }
                                else if (!dbItem.system_state.Equals(xlData.SystemState))
                                {
                                    dbEntity.system_state = xlData.SystemState;
                                    isChanged = true; 
                                }
                                else if (!dbItem.time_zone.Equals(xlData.TimeZone))
                                {
                                    dbEntity.time_zone = xlData.TimeZone;
                                    isChanged = true; 
                                }
                                else if (dbItem.use_state != null)
                                {
                                    if (!dbItem.use_state.Equals(xlData.UseState))
                                    {
                                        dbEntity.use_state = xlData.UseState;
                                        isChanged = true; 
                                    }
                                }
                                else if (!dbItem.vm_host.Equals(xlData.VMHost))
                                {
                                    dbEntity.vm_host = xlData.VMHost;
                                    isChanged = true; 
                                }
                                else if (!dbItem.vm_platform.Equals(xlData.VMPlatform))
                                {
                                    dbEntity.vm_platform = xlData.VMPlatform;
                                    isChanged = true; 
                                }
                                else if (!dbItem.warranty_end_date.Equals(xlData.WarrantyEndDate))
                                {
                                    dbEntity.warranty_end_date = xlData.WarrantyEndDate;
                                    isChanged = true;
                                }
                                #endregion

                                if (isChanged)
                                {
                                    context.Entry(dbEntity).State = EntityState.Modified;
                                    context.SaveChanges();
                                    msg.Count++;
                                } 
                            }
                        }
                    }

                    if (msg.Count > 0)
                    {
                        msg.UpdateMessageCount = msg.Count;
                        msg.Type = "success";
                        msg.Title = "Updated Existing Record's";
                        msg.Message = string.Format("Successfully updated {0} existsing record's", msg.UpdateMessageCount);
                        messages.Add(msg);
                    }

                    msg.Count = 0;
                    //inserting new row (if find any in the excel)
                    List<ExcelViewModel> entityToViewModelDb = AutoMapperHelper.EntityToViewModelDb(dbData);
                    List<ExcelViewModel> entityToViewModelExcel = AutoMapperHelper.EntityToViewModelExcel(excelData); 

                    //check for new entry:
                    var diff = entityToViewModelExcel.Where(x => !entityToViewModelDb.Any(x1 => x1.LocalName == x.LocalName)).ToList();
                    List<tko_msl_master> fromViewModelToTKOMSL = AutoMapperHelper.ViewModelToEntityExcel(diff);

                    foreach (var newRecordAdd in fromViewModelToTKOMSL)
                    {
                        context.Entry(newRecordAdd).State = EntityState.Modified;
                        context.tko_msl_master.Add(newRecordAdd);
                        context.SaveChanges();
                        msg.Count++;
                    }

                    if (msg.Count > 0)
                    {
                        msg.AddNewRecordMessageCount = msg.Count;
                        msg.Type = "success";
                        msg.Title = "Add New Record's";
                        msg.Message = string.Format("Successfully added {0} new record's", msg.AddNewRecordMessageCount);
                        messages.Add(msg);
                    }

                    if (msg.AddNewRecordMessageCount == 0 && msg.UpdateMessageCount == 0)
                    {
                        msg.NoChangesCount = 1;
                        msg.Type = "warning";
                        msg.Title = "No Changes";
                        msg.Message = string.Format("No changes made {0} record's update", msg.AddNewRecordMessageCount);
                        messages.Add(msg);
                    }                    
                }
                else
                {
                    msg.Count = 0;

                    #region First time inserting records
                    //insert all the rows if there is non in the DB...
                    if (excelData.Count > 0)
                    {
                        try
                        {
                            List<tko_msl_master> fromViewModelToTKOMSL = AutoMapperHelper.ViewModelToEntityExcel(excelData);
                            foreach (var insertNewRecord in fromViewModelToTKOMSL)
                            {
                                context.Entry(insertNewRecord).State = EntityState.Modified;
                                context.tko_msl_master.Add(insertNewRecord);
                                context.SaveChanges();
                                msg.Count++;
                            }

                            if (msg.Count > 0)
                            {
                                msg.InsertFirstTimeMessageCount = msg.Count;
                                msg.Type = "success";
                                msg.Title = "Insert New Record's";
                                msg.Message = string.Format("Successfully inserted {0} record's", msg.InsertFirstTimeMessageCount);
                                messages.Add(msg);
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            #region errors list
                            foreach (var eve in ex.EntityValidationErrors)
                            {
                                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);

                                    //ModelState.AddModelError("", ve.PropertyName + " " + ve.ErrorMessage);
                                }
                            }
                            #endregion
                            //throw;
                        }
                    }
                    #endregion
                } 
            }
            return messages;
        }
    }
}