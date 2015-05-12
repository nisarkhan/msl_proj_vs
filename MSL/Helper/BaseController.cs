using AutoMapper;
using MSL.Helper.Session;
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
    public class BaseController : Controller
    {
        //private readonly ISessionState _sessionState;        
        //private mls_dbEntities db = new mls_dbEntities(); 

        protected BaseController()
        {
            //_sessionState = sessionState;

            //SessionWrapper.ServerTypes();
            //SessionWrapper.ServerStates();
            //SessionWrapper.Customer();
            //SessionWrapper.ServerCategories();

            //SessionWrapper.ServiceCateogories();
            //SessionWrapper.OSTypes();
            //SessionWrapper.VMPlatForms();
            //SessionWrapper.BackupAgents();
            //SessionWrapper.MonitoringAgents();
            //SessionWrapper.SiteLocations();
            //SessionWrapper.ModelTypes();

        }
        #region MyRegion

        //#region ServerTypes

        //private void ServerTypes()
        //{
        //    if (GetSession_ServerTypes() == null)
        //    {
        //        var _data = db.server_types.ToList();
        //        Mapper.CreateMap<server_types, ServerTypesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.server_type_id));
        //        Mapper.CreateMap<server_types, ServerTypesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.server_type_name));
        //        List<ServerTypesViewModel> modelList = Mapper.Map<List<server_types>, List<ServerTypesViewModel>>(_data).ToList();
        //        StoreSession_ServerTypes(modelList);
        //    }
        //}
        ////Server Types:
        //public void StoreSession_ServerTypes(List<ServerTypesViewModel> list)
        //{
        //    SessionState.Store("ServerTypes", list);
        //}

        //public List<ServerTypesViewModel> GetSession_ServerTypes()
        //{
        //    return ((List<ServerTypesViewModel>)SessionState.Get("ServerTypes"));
        //}

        //#endregion

        //#region ServerStates
        //private void ServerStates()
        //{
        //    if (GetSession_ServerStates() == null)
        //    {
        //        var _data = db.server_state.ToList();
        //        Mapper.CreateMap<server_state, ServerStatesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.server_state_id));
        //        Mapper.CreateMap<server_state, ServerStatesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.server_state_name));
        //        List<ServerStatesViewModel> modelList = Mapper.Map<List<server_state>, List<ServerStatesViewModel>>(_data).ToList();
        //        StoreSession_ServerStates(modelList);
        //    }
        //}

        ////Server States:
        //public void StoreSession_ServerStates(List<ServerStatesViewModel> list)
        //{
        //    SessionState.Store("ServerStates", list);
        //}

        //public List<ServerStatesViewModel> GetSession_ServerStates()
        //{
        //    return ((List<ServerStatesViewModel>)SessionState.Get("ServerStates"));
        //}

        //#endregion

        //#region Customer

        //private void Customer()
        //{
        //    if (GetSession_Customer() == null)
        //    {
        //        var _data = db.client_cost_center.ToList();
        //        Mapper.CreateMap<client_cost_center, ClientCostCenterViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.client_account_id));
        //        Mapper.CreateMap<client_cost_center, ClientCostCenterViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.client_account_name));
        //        List<ClientCostCenterViewModel> modelList = Mapper.Map<List<client_cost_center>, List<ClientCostCenterViewModel>>(_data).ToList();
        //        StoreSession_Customer(modelList);
        //    }
        //}

        ////Server States:
        //public void StoreSession_Customer(List<ClientCostCenterViewModel> list)
        //{
        //    SessionState.Store("Customer", list);
        //}

        //public List<ClientCostCenterViewModel> GetSession_Customer()
        //{
        //    return ((List<ClientCostCenterViewModel>)SessionState.Get("Customer"));
        //}

        //#endregion

        //#region Server Categories

        //private void ServerCategories()
        //{
        //    if (GetSession_ServerCategories() == null)
        //    {
        //        var _data = db.server_categories.ToList();
        //        Mapper.CreateMap<server_categories, ServerCategoriesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.category_id));
        //        Mapper.CreateMap<server_categories, ServerCategoriesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.category_name));
        //        List<ServerCategoriesViewModel> modelList = Mapper.Map<List<server_categories>, List<ServerCategoriesViewModel>>(_data).ToList();
        //        StoreSession_ServerCategories(modelList);
        //    }
        //}

        //public void StoreSession_ServerCategories(List<ServerCategoriesViewModel> list)
        //{
        //    SessionState.Store("ServerCategories", list);
        //}

        //public List<ServerCategoriesViewModel> GetSession_ServerCategories()
        //{
        //    return ((List<ServerCategoriesViewModel>)SessionState.Get("ServerCategories"));
        //}

        //#endregion

        //#region Service Cateogories

        //private void ServiceCateogories()
        //{
        //    if (GetSession_ServiceCateogories() == null)
        //    {
        //        var _data = db.service_category.ToList();
        //        Mapper.CreateMap<service_category, ServiceCateogoriesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.service_category_id));
        //        Mapper.CreateMap<service_category, ServiceCateogoriesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.service_category_name));
        //        List<ServiceCateogoriesViewModel> modelList = Mapper.Map<List<service_category>, List<ServiceCateogoriesViewModel>>(_data).ToList();
        //        StoreSession_ServiceCateogories(modelList);
        //    }
        //}

        //public void StoreSession_ServiceCateogories(List<ServiceCateogoriesViewModel> list)
        //{
        //    SessionState.Store("ServiceCateogories", list);
        //}

        //public List<ServiceCateogoriesViewModel> GetSession_ServiceCateogories()
        //{
        //    return ((List<ServiceCateogoriesViewModel>)SessionState.Get("ServiceCateogories"));
        //}

        //#endregion

        //#region OS Types

        //private void OSTypes()
        //{
        //    if (GetSession_OSTypes() == null)
        //    {
        //        var _data = db.os_types.ToList();
        //        Mapper.CreateMap<os_types, OSTypesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.os_type_id));
        //        Mapper.CreateMap<os_types, OSTypesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.os_name));
        //        List<OSTypesViewModel> modelList = Mapper.Map<List<os_types>, List<OSTypesViewModel>>(_data).ToList();
        //        StoreSession_OSTypes(modelList);
        //    }
        //}

        ////BackupAgents:
        //public void StoreSession_OSTypes(List<OSTypesViewModel> list)
        //{
        //    SessionState.Store("OSTypes", list);
        //}

        //public List<OSTypesViewModel> GetSession_OSTypes()
        //{
        //    return ((List<OSTypesViewModel>)SessionState.Get("OSTypes"));
        //}

        //#endregion

        //#region VMPlat Forms

        //private void VMPlatForms()
        //{
        //    if (GetSession_VMPlatForms() == null)
        //    {
        //        var _data = db.vm_platform.ToList();
        //        Mapper.CreateMap<vm_platform, VMPlatFormsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.vm_platform_id));
        //        Mapper.CreateMap<vm_platform, VMPlatFormsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.vm_platform_name));
        //        List<VMPlatFormsViewModel> modelList = Mapper.Map<List<vm_platform>, List<VMPlatFormsViewModel>>(_data).ToList();
        //        StoreSession_VMPlatForms(modelList);
        //    }
        //}

        ////BackupAgents:
        //public void StoreSession_VMPlatForms(List<VMPlatFormsViewModel> list)
        //{
        //    SessionState.Store("VMPlatForms", list);
        //}

        //public List<VMPlatFormsViewModel> GetSession_VMPlatForms()
        //{
        //    return ((List<VMPlatFormsViewModel>)SessionState.Get("VMPlatForms"));
        //}

        //#endregion 

        //#region Backup Agent

        //private void BackupAgents()
        //{
        //    if (GetSession_BackupAgents() == null)
        //    {
        //        var _data = db.backup_agent.ToList();
        //        Mapper.CreateMap<backup_agent, BackupAgentsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.backup_agent_id));
        //        Mapper.CreateMap<backup_agent, BackupAgentsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.backup_agent_name));
        //        List<BackupAgentsViewModel> modelList = Mapper.Map<List<backup_agent>, List<BackupAgentsViewModel>>(_data).ToList();
        //        StoreSession_BackupAgents(modelList);
        //    }
        //}

        ////BackupAgents:
        //public void StoreSession_BackupAgents(List<BackupAgentsViewModel> list)
        //{
        //    SessionState.Store("BackupAgents", list);
        //}

        //public List<BackupAgentsViewModel> GetSession_BackupAgents()
        //{
        //    return ((List<BackupAgentsViewModel>)SessionState.Get("BackupAgents"));
        //}

        //#endregion

        //#region  Monitoring Agents

        //private void MonitoringAgents()
        //{
        //    if (GetSession_MonitoringAgents() == null)
        //    {
        //        var _data = db.monitoring_agent.ToList();
        //        Mapper.CreateMap<monitoring_agent, MonitoringAgentsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.monitor_agent_id));
        //        Mapper.CreateMap<monitoring_agent, MonitoringAgentsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.monitor_agent_name));
        //        List<MonitoringAgentsViewModel> modelList = Mapper.Map<List<monitoring_agent>, List<MonitoringAgentsViewModel>>(_data).ToList();
        //        StoreSession_MonitoringAgents(modelList);
        //    }
        //}

        ////BackupAgents:
        //public void StoreSession_MonitoringAgents(List<MonitoringAgentsViewModel> list)
        //{
        //    SessionState.Store("MonitoringAgents", list);
        //}

        //public List<MonitoringAgentsViewModel> GetSession_MonitoringAgents()
        //{
        //    return ((List<MonitoringAgentsViewModel>)SessionState.Get("MonitoringAgents"));
        //}

        //#endregion

        //#region  Site Locations

        //private void SiteLocations()
        //{
        //    if (GetSession_SiteLocations() == null)
        //    {
        //        var _data = db.site_location.ToList();
        //        Mapper.CreateMap<site_location, SiteLocationsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.site_location_id));
        //        Mapper.CreateMap<site_location, SiteLocationsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.site_location_name));
        //        List<SiteLocationsViewModel> modelList = Mapper.Map<List<site_location>, List<SiteLocationsViewModel>>(_data).ToList();
        //        StoreSession_SiteLocations(modelList);
        //    }
        //}

        ////BackupAgents:
        //public void StoreSession_SiteLocations(List<SiteLocationsViewModel> list)
        //{
        //    SessionState.Store("SiteLocations", list);
        //}

        //public List<SiteLocationsViewModel> GetSession_SiteLocations()
        //{
        //    return ((List<SiteLocationsViewModel>)SessionState.Get("SiteLocations"));
        //}

        //#endregion

        //#region  Model Types

        //private void ModelTypes()
        //{
        //    if (GetSession_ModelTypes() == null)
        //    {
        //        var _data = db.model_types_power.ToList();
        //        Mapper.CreateMap<model_types_power, ModelTypesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.model_type_id));
        //        Mapper.CreateMap<model_types_power, ModelTypesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.model_name));
        //        List<ModelTypesViewModel> modelList = Mapper.Map<List<model_types_power>, List<ModelTypesViewModel>>(_data).ToList();
        //        StoreSession_ModelTypes(modelList);
        //    }
        //}

        ////BackupAgents:
        //public void StoreSession_ModelTypes(List<ModelTypesViewModel> list)
        //{
        //    SessionState.Store("ModelTypes", list);
        //}

        //public List<ModelTypesViewModel> GetSession_ModelTypes()
        //{
        //    return ((List<ModelTypesViewModel>)SessionState.Get("ModelTypes"));
        //}

        //#endregion

        //internal protected ISessionState SessionState
        //{
        //    get { return _sessionState; }
        //}

        //public void StoreSession_ShowInvalidRecords(List<ExcelViewModel> list)
        //{
        //    SessionState.Store("ShowInvalidRecords", list);
        //}

        //public List<ExcelViewModel> GetSession_ShowInvalidRecords()
        //{
        //    return ((List<ExcelViewModel>)SessionState.Get("ShowInvalidRecords"));//.ToList();

        //}

        //public void StoreSession_ShowValidRecords(List<ExcelViewModel> list)
        //{
        //    SessionState.Store("ShowValidRecords", list);
        //}

        //public List<ExcelViewModel> GetSession_ShowValidRecords()
        //{
        //    return ((List<ExcelViewModel>)SessionState.Get("ShowValidRecords"));//.ToList();

        //}

        ////public void StoreSession_DataModel(List<ExcelViewModel> list)
        ////{
        ////    SessionState.Store("datamodel", list);
        ////}

        ////public List<ExcelViewModel> GetSession_DataModel()
        ////{
        ////    return ((List<ExcelViewModel>)SessionState.Get("datamodel"));
        ////}

        //public void StoreSession_Model(ImportViewModelManager list)
        //{
        //    SessionState.Store("model", list);
        //}

        //public ImportViewModelManager GetSession_Model()
        //{
        //    return ((ImportViewModelManager)SessionState.Get("model"));
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //} 
        #endregion
    }
}