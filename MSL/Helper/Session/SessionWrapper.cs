using AutoMapper;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Helper.Session
{
    public static class SessionWrapper
    {
          #region ServerTypes

        public static List<ServerTypesViewModel> GetSession_ServerTypes()
        {
            return (List<ServerTypesViewModel>)HttpContext.Current.Session["ServerTypes"] as List<ServerTypesViewModel>;             
        }

        public static void StoreSession_ServerTypes(List<ServerTypesViewModel> list)
        {
            HttpContext.Current.Session["ServerTypes"] = list; 
        }

        public static void ServerTypes()
        {
            if (GetSession_ServerTypes() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.server_types.ToList();
                    Mapper.CreateMap<server_types, ServerTypesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.server_type_id));
                    Mapper.CreateMap<server_types, ServerTypesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.server_type_name));
                    List<ServerTypesViewModel> modelList = Mapper.Map<List<server_types>, List<ServerTypesViewModel>>(_data).ToList();
                    StoreSession_ServerTypes(modelList);
                }
            }
        } 
        #endregion

        #region ServerStates
        //Server States: 
        public static List<ServerStatesViewModel> GetSession_ServerStates()
        {
            return (List<ServerStatesViewModel>)HttpContext.Current.Session["ServerStates"] as List<ServerStatesViewModel>;
        }

        public static void StoreSession_ServerStates(List<ServerStatesViewModel> list)
        {
            HttpContext.Current.Session["ServerStates"] = list;
        }

        public static void ServerStates()
        {
            if (GetSession_ServerStates() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.server_state.ToList();
                    Mapper.CreateMap<server_state, ServerStatesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.server_state_id));
                    Mapper.CreateMap<server_state, ServerStatesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.server_state_name));
                    List<ServerStatesViewModel> modelList = Mapper.Map<List<server_state>, List<ServerStatesViewModel>>(_data).ToList();
                    StoreSession_ServerStates(modelList);
                }
            }
        } 
        #endregion

        #region Customer
        //Server States:

        public static List<ClientCostCenterViewModel> GetSession_Customer()
        {
            return (List<ClientCostCenterViewModel>)HttpContext.Current.Session["Customer"] as List<ClientCostCenterViewModel>;
        }

        public static void StoreSession_Customer(List<ClientCostCenterViewModel> list)
        {
            HttpContext.Current.Session["Customer"] = list;
        }

        public static void Customer()
        {
            if (GetSession_Customer() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.client_cost_center.ToList();
                    Mapper.CreateMap<client_cost_center, ClientCostCenterViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.client_account_id));
                    Mapper.CreateMap<client_cost_center, ClientCostCenterViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.client_account_name));
                    List<ClientCostCenterViewModel> modelList = Mapper.Map<List<client_cost_center>, List<ClientCostCenterViewModel>>(_data).ToList();
                    StoreSession_Customer(modelList);
                }
            }
        }  
        #endregion

        #region Server Categories

        public static List<ServerCategoriesViewModel> GetSession_ServerCategories()
        {
            return (List<ServerCategoriesViewModel>)HttpContext.Current.Session["ServerCategories"] as List<ServerCategoriesViewModel>;
        }

        public static void StoreSession_ServerCategories(List<ServerCategoriesViewModel> list)
        {
            HttpContext.Current.Session["ServerCategories"] = list;
        }

        public static void ServerCategories()
        {
            if (GetSession_ServerCategories() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.server_categories.ToList();
                    Mapper.CreateMap<server_categories, ServerCategoriesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.category_id));
                    Mapper.CreateMap<server_categories, ServerCategoriesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.category_name));
                    List<ServerCategoriesViewModel> modelList = Mapper.Map<List<server_categories>, List<ServerCategoriesViewModel>>(_data).ToList();
                    StoreSession_ServerCategories(modelList);
                }
            }
        }

        //public void StoreSession_ServerCategories(List<ServerCategoriesViewModel> list)
        //{
        //    SessionState.Store("ServerCategories", list);
        //}

        //public List<ServerCategoriesViewModel> GetSession_ServerCategories()
        //{
        //    return ((List<ServerCategoriesViewModel>)SessionState.Get("ServerCategories"));
        //}

        #endregion

        #region Service Cateogories

        public static List<ServiceCateogoriesViewModel> GetSession_ServiceCateogories()
        {
            return (List<ServiceCateogoriesViewModel>)HttpContext.Current.Session["ServiceCateogories"] as List<ServiceCateogoriesViewModel>;
        }

        public static void StoreSession_ServiceCateogories(List<ServiceCateogoriesViewModel> list)
        {
            HttpContext.Current.Session["ServiceCateogories"] = list;
        }

        public static void ServiceCateogories()
        {
            if (GetSession_ServiceCateogories() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.service_category.ToList();
                    Mapper.CreateMap<service_category, ServiceCateogoriesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.service_category_id));
                    Mapper.CreateMap<service_category, ServiceCateogoriesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.service_category_name));
                    List<ServiceCateogoriesViewModel> modelList = Mapper.Map<List<service_category>, List<ServiceCateogoriesViewModel>>(_data).ToList();
                    StoreSession_ServiceCateogories(modelList);
                }
            }
        }

        //public void StoreSession_ServiceCateogories(List<ServiceCateogoriesViewModel> list)
        //{
        //    SessionState.Store("ServiceCateogories", list);
        //}

        //public List<ServiceCateogoriesViewModel> GetSession_ServiceCateogories()
        //{
        //    return ((List<ServiceCateogoriesViewModel>)SessionState.Get("ServiceCateogories"));
        //}

        #endregion

        #region OS Types

        public static List<OSTypesViewModel> GetSession_OSTypes()
        {
            return (List<OSTypesViewModel>)HttpContext.Current.Session["OSTypes"] as List<OSTypesViewModel>;
        }

        public static void StoreSession_OSTypes(List<OSTypesViewModel> list)
        {
            HttpContext.Current.Session["OSTypes"] = list;
        }

        public static void OSTypes()
        {
            if (GetSession_OSTypes() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.os_types.ToList();
                    Mapper.CreateMap<os_types, OSTypesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.os_type_id));
                    Mapper.CreateMap<os_types, OSTypesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.os_name));
                    List<OSTypesViewModel> modelList = Mapper.Map<List<os_types>, List<OSTypesViewModel>>(_data).ToList();
                    StoreSession_OSTypes(modelList);
                }
            }
        }

        //BackupAgents:
        //public void StoreSession_OSTypes(List<OSTypesViewModel> list)
        //{
        //    SessionState.Store("OSTypes", list);
        //}

        //public List<OSTypesViewModel> GetSession_OSTypes()
        //{
        //    return ((List<OSTypesViewModel>)SessionState.Get("OSTypes"));
        //}

        #endregion

        #region VMPlat Forms

        public static List<VMPlatFormsViewModel> GetSession_VMPlatForms()
        {
            return (List<VMPlatFormsViewModel>)HttpContext.Current.Session["VMPlatForms"] as List<VMPlatFormsViewModel>;
        }

        public static void StoreSession_VMPlatForms(List<VMPlatFormsViewModel> list)
        {
            HttpContext.Current.Session["VMPlatForms"] = list;
        }

        public static void VMPlatForms()
        {
            if (GetSession_VMPlatForms() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.vm_platform.ToList();
                    Mapper.CreateMap<vm_platform, VMPlatFormsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.vm_platform_id));
                    Mapper.CreateMap<vm_platform, VMPlatFormsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.vm_platform_name));
                    List<VMPlatFormsViewModel> modelList = Mapper.Map<List<vm_platform>, List<VMPlatFormsViewModel>>(_data).ToList();
                    StoreSession_VMPlatForms(modelList);
                }
            }
        }

        //BackupAgents:
        //public void StoreSession_VMPlatForms(List<VMPlatFormsViewModel> list)
        //{
        //    SessionState.Store("VMPlatForms", list);
        //}

        //public List<VMPlatFormsViewModel> GetSession_VMPlatForms()
        //{
        //    return ((List<VMPlatFormsViewModel>)SessionState.Get("VMPlatForms"));
        //}

        #endregion

        #region Backup Agent

        public static List<BackupAgentsViewModel> GetSession_BackupAgents()
        {
            return (List<BackupAgentsViewModel>)HttpContext.Current.Session["BackupAgents"] as List<BackupAgentsViewModel>;
        }

        public static void StoreSession_BackupAgents(List<BackupAgentsViewModel> list)
        {
            HttpContext.Current.Session["BackupAgents"] = list;
        }

        public static void BackupAgents()
        {
            if (GetSession_BackupAgents() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.backup_agent.ToList();
                    Mapper.CreateMap<backup_agent, BackupAgentsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.backup_agent_id));
                    Mapper.CreateMap<backup_agent, BackupAgentsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.backup_agent_name));
                    List<BackupAgentsViewModel> modelList = Mapper.Map<List<backup_agent>, List<BackupAgentsViewModel>>(_data).ToList();
                    StoreSession_BackupAgents(modelList);
                }
            }
        }

        //BackupAgents:
        //public void StoreSession_BackupAgents(List<BackupAgentsViewModel> list)
        //{
        //    SessionState.Store("BackupAgents", list);
        //}

        //public List<BackupAgentsViewModel> GetSession_BackupAgents()
        //{
        //    return ((List<BackupAgentsViewModel>)SessionState.Get("BackupAgents"));
        //}

        #endregion

        #region  Monitoring Agents

        public static List<MonitoringAgentsViewModel> GetSession_MonitoringAgents()
        {
            return (List<MonitoringAgentsViewModel>)HttpContext.Current.Session["MonitoringAgents"] as List<MonitoringAgentsViewModel>;
        }

        public static void StoreSession_MonitoringAgents(List<MonitoringAgentsViewModel> list)
        {
            HttpContext.Current.Session["MonitoringAgents"] = list;
        }

        public static void MonitoringAgents()
        {
            if (GetSession_MonitoringAgents() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.monitoring_agent.ToList();
                    Mapper.CreateMap<monitoring_agent, MonitoringAgentsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.monitor_agent_id));
                    Mapper.CreateMap<monitoring_agent, MonitoringAgentsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.monitor_agent_name));
                    List<MonitoringAgentsViewModel> modelList = Mapper.Map<List<monitoring_agent>, List<MonitoringAgentsViewModel>>(_data).ToList();
                    StoreSession_MonitoringAgents(modelList);
                }
            }
        }

        //BackupAgents:
        //public void StoreSession_MonitoringAgents(List<MonitoringAgentsViewModel> list)
        //{
        //    SessionState.Store("MonitoringAgents", list);
        //}

        //public List<MonitoringAgentsViewModel> GetSession_MonitoringAgents()
        //{
        //    return ((List<MonitoringAgentsViewModel>)SessionState.Get("MonitoringAgents"));
        //}

        #endregion

        #region  Site Locations

        public static List<SiteLocationsViewModel> GetSession_SiteLocations()
        {
            return (List<SiteLocationsViewModel>)HttpContext.Current.Session["SiteLocations"] as List<SiteLocationsViewModel>;
        }

        public static void StoreSession_SiteLocations(List<SiteLocationsViewModel> list)
        {
            HttpContext.Current.Session["SiteLocations"] = list;
        }

        public static void SiteLocations()
        {
            if (GetSession_SiteLocations() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.site_location.ToList();
                    Mapper.CreateMap<site_location, SiteLocationsViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.site_location_id));
                    Mapper.CreateMap<site_location, SiteLocationsViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.site_location_name));
                    List<SiteLocationsViewModel> modelList = Mapper.Map<List<site_location>, List<SiteLocationsViewModel>>(_data).ToList();
                    StoreSession_SiteLocations(modelList);
                }
            }
        }

        //BackupAgents:
        //public void StoreSession_SiteLocations(List<SiteLocationsViewModel> list)
        //{
        //    SessionState.Store("SiteLocations", list);
        //}

        //public List<SiteLocationsViewModel> GetSession_SiteLocations()
        //{
        //    return ((List<SiteLocationsViewModel>)SessionState.Get("SiteLocations"));
        //}

        #endregion

        #region  Model Types

        public static List<ModelTypesViewModel> GetSession_ModelTypes()
        {
            return (List<ModelTypesViewModel>)HttpContext.Current.Session["ModelTypes"] as List<ModelTypesViewModel>;
        }

        public static void StoreSession_ModelTypes(List<ModelTypesViewModel> list)
        {
            HttpContext.Current.Session["ModelTypes"] = list;
        }

        public static void ModelTypes()
        {
            if (GetSession_ModelTypes() == null)
            {
                using (var context = new mls_dbEntities())
                {
                    var _data = context.model_types_power.ToList();
                    Mapper.CreateMap<model_types_power, ModelTypesViewModel>().ForMember(a => a.Id, map => map.MapFrom(b => b.model_type_id));
                    Mapper.CreateMap<model_types_power, ModelTypesViewModel>().ForMember(a => a.Name, map => map.MapFrom(b => b.model_name));
                    List<ModelTypesViewModel> modelList = Mapper.Map<List<model_types_power>, List<ModelTypesViewModel>>(_data).ToList();
                    StoreSession_ModelTypes(modelList);
                }
            }
        }

        //BackupAgents:
        //public void StoreSession_ModelTypes(List<ModelTypesViewModel> list)
        //{
        //    SessionState.Store("ModelTypes", list);
        //}

        //public List<ModelTypesViewModel> GetSession_ModelTypes()
        //{
        //    return ((List<ModelTypesViewModel>)SessionState.Get("ModelTypes"));
        //}

        #endregion

        //internal protected ISessionState SessionState
        //{
        //    get { return _sessionState; }
        //}


      
        //public static void StoreSession_ShowInvalidRecords(List<ExcelViewModel> list)
        //{
        //    HttpContext.Current.Session["ShowInvalidRecords"] = list;
        //}

        //public static List<ExcelViewModel> GetSession_ModelTypes()
        //{
        //    return (List<ExcelViewModel>)HttpContext.Current.Session["ShowInvalidRecords"] as List<ExcelViewModel>;
        //}


        //public void StoreSession_ShowInvalidRecords(List<ExcelViewModel> list)
        //{
        //    SessionState.Store("ShowInvalidRecords", list);
        //}

        //public List<ExcelViewModel> GetSession_ShowInvalidRecords()
        //{
        //    return ((List<ExcelViewModel>)SessionState.Get("ShowInvalidRecords"));//.ToList();

        //}

        public static void StoreSession_ShowInvalidRecords(List<ExcelViewModel> list)
        {
            HttpContext.Current.Session["ShowInvalidRecords"] = list;
        }

        public static List<ExcelViewModel> GetSession_ShowInvalidRecords()
        {
            return (List<ExcelViewModel>)HttpContext.Current.Session["ShowInvalidRecords"] as List<ExcelViewModel>;
        }

        //public void StoreSession_ShowValidRecords(List<ExcelViewModel> list)
        //{
        //    SessionState.Store("ShowValidRecords", list);
        //}

        //public List<ExcelViewModel> GetSession_ShowValidRecords()
        //{
        //    return ((List<ExcelViewModel>)SessionState.Get("ShowValidRecords"));//.ToList(); 
        //}

        public static void StoreSession_ShowValidRecords(List<ExcelViewModel> list)
        {
            HttpContext.Current.Session["ShowValidRecords"] = list;
        }

        public static List<ExcelViewModel> GetSession_ShowValidRecords()
        {
            return (List<ExcelViewModel>)HttpContext.Current.Session["ShowValidRecords"] as List<ExcelViewModel>;
        }

        //public void StoreSession_Model(ImportViewModelManager list)
        //{
        //    SessionState.Store("model", list);
        //}

        //public ImportViewModelManager GetSession_Model()
        //{
        //    return ((ImportViewModelManager)SessionState.Get("model"));
        //}

        public static void StoreSession_Model(ImportViewModelManager list)
        {
            HttpContext.Current.Session["model"] = list;
        }

        public static ImportViewModelManager GetSession_Model()
        {
            return (ImportViewModelManager)HttpContext.Current.Session["model"] as ImportViewModelManager;
        }

        
    }
}