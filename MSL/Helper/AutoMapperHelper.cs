using AutoMapper;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Helper
{
    public static class AutoMapperHelper
    {
        public static List<ExcelViewModel> EntityToViewModelDb(List<tko_msl_master> dbData)
        {
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Customer, map => map.MapFrom(b => b.customer));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Country, map => map.MapFrom(b => b.country));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.AssetTag, map => map.MapFrom(b => b.asset_tag));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.BackupAgent, map => map.MapFrom(b => b.backup_agent));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.BackupIP, map => map.MapFrom(b => b.backup_ip));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Category, map => map.MapFrom(b => b.category));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ConsoleAccess, map => map.MapFrom(b => b.console_access));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Country, map => map.MapFrom(b => b.country));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUCores, map => map.MapFrom(b => b.cpu_cores));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUCount, map => map.MapFrom(b => b.cpu_count));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUModel, map => map.MapFrom(b => b.cpu_model));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUSpeed, map => map.MapFrom(b => b.cpu_speed));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Customer, map => map.MapFrom(b => b.customer));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.DCLocation, map => map.MapFrom(b => b.dc_location));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Domain, map => map.MapFrom(b => b.domain));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.InCluster, map => map.MapFrom(b => b.in_cluster));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.IsLocalSecurity, map => map.MapFrom(b => b.is_local_security));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.KernelPatch, map => map.MapFrom(b => b.kernel_patch));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalDiskCapacity, map => map.MapFrom(b => b.local_disk_capacity));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalDiskInstalled, map => map.MapFrom(b => b.local_disk_installed));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalDiskSlotTotal, map => map.MapFrom(b => b.local_disk_slot_total));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalRaidLevel, map => map.MapFrom(b => b.local_raid_level));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalName, map => map.MapFrom(b => b.localname));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Location, map => map.MapFrom(b => b.location));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.MasterBackupServer, map => map.MapFrom(b => b.master_backup_server));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Model, map => map.MapFrom(b => b.model));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.MonitorAgent, map => map.MapFrom(b => b.monitor_agent));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.OS, map => map.MapFrom(b => b.os));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.OSMinor, map => map.MapFrom(b => b.os_minor));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.OSPatchLevel, map => map.MapFrom(b => b.os_patch_level));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PatchingGroup, map => map.MapFrom(b => b.patching_group));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PhysicalMemory, map => map.MapFrom(b => b.physical_memory));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PrimaryApplication, map => map.MapFrom(b => b.primary_application));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PurchaseDate, map => map.MapFrom(b => b.purchase_date));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RackShelf, map => map.MapFrom(b => b.rack_shelf));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RebootAutomatic, map => map.MapFrom(b => b.reboot_automatic));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RebootNotes, map => map.MapFrom(b => b.reboot_notes));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RegulationCompliance, map => map.MapFrom(b => b.regulation_compliance));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SecurityWaiver, map => map.MapFrom(b => b.security_waiver));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SecurityWaiverNotes, map => map.MapFrom(b => b.security_waiver_notes));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SerialNumber, map => map.MapFrom(b => b.serialnumber));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServerType, map => map.MapFrom(b => b.server_type));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServiceCategory, map => map.MapFrom(b => b.service_category));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServiceFQDN, map => map.MapFrom(b => b.service_fqdn));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServiceIP, map => map.MapFrom(b => b.service_ip));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.StreetAddress, map => map.MapFrom(b => b.street_address));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SunHostId, map => map.MapFrom(b => b.sun_host_id));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SystemState, map => map.MapFrom(b => b.system_state));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.TimeZone, map => map.MapFrom(b => b.time_zone));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.UseState, map => map.MapFrom(b => b.use_state));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.VMHost, map => map.MapFrom(b => b.vm_host));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.VMPlatform, map => map.MapFrom(b => b.vm_platform));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.WarrantyEndDate, map => map.MapFrom(b => b.warranty_end_date));            
            List<ExcelViewModel> list = Mapper.Map<List<tko_msl_master>, List<ExcelViewModel>>(dbData).ToList();
            return list;
        }

        public static List<ExcelViewModel> EntityToViewModelExcel(List<ExcelViewModel> excelData)
        {
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Customer, map => map.MapFrom(b => b.customer));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Country, map => map.MapFrom(b => b.country));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.AssetTag, map => map.MapFrom(b => b.asset_tag));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.BackupAgent, map => map.MapFrom(b => b.backup_agent));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.BackupIP, map => map.MapFrom(b => b.backup_ip));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Category, map => map.MapFrom(b => b.category));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ConsoleAccess, map => map.MapFrom(b => b.console_access));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Country, map => map.MapFrom(b => b.country));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUCores, map => map.MapFrom(b => b.cpu_cores));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUCount, map => map.MapFrom(b => b.cpu_count));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUModel, map => map.MapFrom(b => b.cpu_model));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.CPUSpeed, map => map.MapFrom(b => b.cpu_speed));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Customer, map => map.MapFrom(b => b.customer));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.DCLocation, map => map.MapFrom(b => b.dc_location));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Domain, map => map.MapFrom(b => b.domain));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.InCluster, map => map.MapFrom(b => b.in_cluster));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.IsLocalSecurity, map => map.MapFrom(b => b.is_local_security));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.KernelPatch, map => map.MapFrom(b => b.kernel_patch));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalDiskCapacity, map => map.MapFrom(b => b.local_disk_capacity));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalDiskInstalled, map => map.MapFrom(b => b.local_disk_installed));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalDiskSlotTotal, map => map.MapFrom(b => b.local_disk_slot_total));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalRaidLevel, map => map.MapFrom(b => b.local_raid_level));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.LocalName, map => map.MapFrom(b => b.localname));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Location, map => map.MapFrom(b => b.location));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.MasterBackupServer, map => map.MapFrom(b => b.master_backup_server));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.Model, map => map.MapFrom(b => b.model));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.MonitorAgent, map => map.MapFrom(b => b.monitor_agent));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.OS, map => map.MapFrom(b => b.os));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.OSMinor, map => map.MapFrom(b => b.os_minor));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.OSPatchLevel, map => map.MapFrom(b => b.os_patch_level));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PatchingGroup, map => map.MapFrom(b => b.patching_group));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PhysicalMemory, map => map.MapFrom(b => b.physical_memory));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PrimaryApplication, map => map.MapFrom(b => b.primary_application));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.PurchaseDate, map => map.MapFrom(b => b.purchase_date));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RackShelf, map => map.MapFrom(b => b.rack_shelf));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RebootAutomatic, map => map.MapFrom(b => b.reboot_automatic));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RebootNotes, map => map.MapFrom(b => b.reboot_notes));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.RegulationCompliance, map => map.MapFrom(b => b.regulation_compliance));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SecurityWaiver, map => map.MapFrom(b => b.security_waiver));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SecurityWaiverNotes, map => map.MapFrom(b => b.security_waiver_notes));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SerialNumber, map => map.MapFrom(b => b.serialnumber));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServerType, map => map.MapFrom(b => b.server_type));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServiceCategory, map => map.MapFrom(b => b.service_category));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServiceFQDN, map => map.MapFrom(b => b.service_fqdn));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.ServiceIP, map => map.MapFrom(b => b.service_ip));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.StreetAddress, map => map.MapFrom(b => b.street_address));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SunHostId, map => map.MapFrom(b => b.sun_host_id));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.SystemState, map => map.MapFrom(b => b.system_state));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.TimeZone, map => map.MapFrom(b => b.time_zone));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.UseState, map => map.MapFrom(b => b.use_state));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.VMHost, map => map.MapFrom(b => b.vm_host));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.VMPlatform, map => map.MapFrom(b => b.vm_platform));
            Mapper.CreateMap<tko_msl_master, ExcelViewModel>().ForMember(a => a.WarrantyEndDate, map => map.MapFrom(b => b.warranty_end_date));
            List<ExcelViewModel> list = Mapper.Map<List<ExcelViewModel>, List<ExcelViewModel>>(excelData).ToList();
            return list;
        }

        public static List<tko_msl_master> ViewModelToEntityExcel(List<ExcelViewModel> excelData)
        {
            Mapper.CreateMap<ExcelViewModel, tko_msl_master>().ForMember(a => a.customer, map => map.MapFrom(b => b.Customer));
            Mapper.CreateMap<ExcelViewModel, tko_msl_master>().ForMember(a => a.country, map => map.MapFrom(b => b.Country));
            List<tko_msl_master> list = Mapper.Map<List<ExcelViewModel>, List<tko_msl_master>>(excelData).ToList();
            return list;
        } 
    }
}