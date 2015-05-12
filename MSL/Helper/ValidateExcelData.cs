using MSL.Helper.Session;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Helper
{
    public  class ValidateExcelData  
    {        
        public ValidateExcelData()
        {
            SessionWrapper.ServerTypes();
            SessionWrapper.ServerStates();
            SessionWrapper.Customer();
            SessionWrapper.ServerCategories();

            SessionWrapper.ServiceCateogories();
            SessionWrapper.OSTypes();
            SessionWrapper.VMPlatForms();
            SessionWrapper.BackupAgents();
            SessionWrapper.MonitoringAgents();
            SessionWrapper.SiteLocations();
            SessionWrapper.ModelTypes();
        }

        public  void RunValidationCheck(List<ExcelViewModel> data)
        {
            List<ExcelViewModel> _validationFailed = new List<ExcelViewModel>();
            List<ExcelViewModel> _validationPassed = new List<ExcelViewModel>();
            List<ValidateDataViewModel> vdList = new List<ValidateDataViewModel>();

            ImportViewModelManager model = new ImportViewModelManager();

            RunValidationForDataSet rv = new RunValidationForDataSet();
            //validate the data exists in the db...
            foreach (ExcelViewModel subItem in data)
            {                 
                ExcelViewModel excelModel = new ExcelViewModel();

                foreach (var item in subItem.GetType().GetProperties())
                {
                    string name = (item).Name;
                    ValidateDataViewModel isValidationFailed = new ValidateDataViewModel();

                    int _length = DataAnnotation.GetMaxLengthFromStringLengthAttribute(typeof(ExcelViewModel), name);

                    #region validation checks

                    if (name == Constants.Customer)
                    {
                        bool isDbNotFound = false;
                        ClientCostCenterViewModel dbObject = (ClientCostCenterViewModel)SessionWrapper.GetSession_Customer().Find(s => s.Name.Trim() == subItem.Customer.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true; 
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);

                        #region backup
                        //bool isLengthValid = false;
                        //bool isExistsInDb = false;

                        ////to capture all error desc
                        ////List<String> errorMsgList = new List<String>(); 

                        //isValidationFailed = ValidatatingLength(subItem.Customer, _length, name, Constants.Customer);
                        //AddToValidationErrorList(vdList, subItem, isValidationFailed);

                        ////length add error msg.
                        ////errorMsgList.Add(isValidationFailed.Desc);

                        ////chk length
                        //isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);


                        //ClientCostCenterViewModel dbObject = (ClientCostCenterViewModel)SessionWrapper.GetSession_Customer().Find(s => s.Name.Trim() == subItem.Customer.Trim());
                        //if (dbObject == null)
                        //{
                        //    isValidationFailed = ValidateDBValue(name, Constants.Customer);
                        //    AddToValidationErrorList(vdList, subItem, isValidationFailed);
                        //}

                        ////db add error msg.
                        ////errorMsgList.Add(isValidationFailed.Desc);

                        ////chk db 
                        //isExistsInDb = ValidateDbValue(isValidationFailed.Name, isValidationFailed.Desc);                        

                        // string htmlTag =  GetHtmlTag(isLengthValid, isExistsInDb);
                        // if (!string.IsNullOrEmpty(htmlTag))
                        // {
                        //     subItem.SetValidationFailed.Customer_ValidationFailed = htmlTag;
                        //     //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
                        //     isExistsInDb = false;
                        //     isLengthValid = false;
                        // } 
                        #endregion
                    }
                    if (name == Constants.AssetTag)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.LocalName)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);           
                    }
                    if (name == Constants.SerialNumber)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.SystemState)
                    {
                        bool isDbNotFound = false;
                        ServerStatesViewModel dbObject = (ServerStatesViewModel)SessionWrapper.GetSession_ServerStates().Find(s => s.Name.Trim() == subItem.SystemState.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);

                    }
                    if (name == Constants.ServerType)
                    {
                        bool isDbNotFound = false;
                        ServerTypesViewModel dbObject = (ServerTypesViewModel)SessionWrapper.GetSession_ServerTypes().Find(s => s.Name.Trim() == subItem.ServerType.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);
                         
                    }
                    if (name == Constants.Category)
                    {
                        bool isDbNotFound = false;
                        ServerCategoriesViewModel dbObject = (ServerCategoriesViewModel)SessionWrapper.GetSession_ServerCategories().Find(s => s.Name.Trim() == subItem.Category.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);  
                    }
                    if (name == Constants.ServiceCategory)
                    {
                        bool isDbNotFound = false;
                        ServiceCateogoriesViewModel dbObject = (ServiceCateogoriesViewModel)SessionWrapper.GetSession_ServiceCateogories().Find(s => s.Name.Trim() == subItem.ServiceCategory.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);   
                    }
                    if (name == Constants.Country)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.Domain)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.IsLocalSecurity)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.SecurityWaiver)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.SecurityWaiverNotes)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.OS)
                    {
                        bool isDbNotFound = false;
                        OSTypesViewModel dbObject = (OSTypesViewModel)SessionWrapper.GetSession_OSTypes().Find(s => s.Name.Trim() == subItem.OS.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);  
                    }
                    if (name == Constants.OSMinor)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.OSPatchLevel)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.KernelPatch)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.PatchingGroup)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.ServiceIP)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.ServiceFQDN)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.ConsoleAccess)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.CPUCores)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.CPUCount)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.CPUModel)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.CPUSpeed)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.LocalDiskCapacity)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.LocalDiskSlotTotal)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.LocalDiskInstalled)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.LocalRaidLevel)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.PhysicalMemory)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.PurchaseDate)
                    {
                        DateTime value;
                        if (!DateTime.TryParse(subItem.PurchaseDate.ToShortDateString(), out value))
                        {
                            //make sure the format is correct                            
                            isValidationFailed = ValidatatingLength(subItem.PurchaseDate.ToShortDateString(), _length, name, Constants.PurchaseDate);
                            AddToValidationErrorList(vdList, subItem, isValidationFailed);
                        }
                    }
                    if (name == Constants.SunHostId)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.TimeZone)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.StreetAddress)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.RegulationCompliance)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.InCluster)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.RebootAutomatic) //boolean????
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.RebootNotes)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.MasterBackupServer)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.BackupIP)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.VMPlatform)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.VMHost)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.PrimaryApplication)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.BackupAgent)
                    {
                        bool isDbNotFound = false;
                        BackupAgentsViewModel dbObject = (BackupAgentsViewModel)SessionWrapper.GetSession_BackupAgents().Find(s => s.Name.Trim() == subItem.BackupAgent.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);   
                    }
                    if (name == Constants.MonitorAgent)
                    {
                        bool isDbNotFound = false;
                        MonitoringAgentsViewModel dbObject = (MonitoringAgentsViewModel)SessionWrapper.GetSession_MonitoringAgents().Find(s => s.Name.Trim() == subItem.MonitorAgent.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);                           
                    }
                    if (name == Constants.Location)
                    {
                        bool isDbNotFound = false;
                        SiteLocationsViewModel dbObject = (SiteLocationsViewModel)SessionWrapper.GetSession_SiteLocations().Find(s => s.Name.Trim() == subItem.Location.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);   
                    }
                    if (name == Constants.RackShelf)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.DCLocation)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.Model)
                    {
                        bool isDbNotFound = false;
                        ModelTypesViewModel dbObject = (ModelTypesViewModel)SessionWrapper.GetSession_ModelTypes().Find(s => s.Name.Trim() == subItem.Model.Trim());
                        if (dbObject == null)
                        {
                            isDbNotFound = true;
                        }

                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, isDbNotFound);    
                    }
                    if (name == Constants.AssetTag)
                    {
                        rv.Run_Validation(isValidationFailed, vdList, subItem, _length, name, false);
                    }
                    if (name == Constants.WarrantyEndDate)
                    {
                        DateTime value;
                        if (!DateTime.TryParse(subItem.WarrantyEndDate.ToShortDateString(), out value))
                        {
                            //make sure the format is correct                            
                            isValidationFailed = ValidatatingLength(subItem.WarrantyEndDate.ToShortDateString(), _length, name, Constants.WarrantyEndDate);
                            AddToValidationErrorList(vdList, subItem, isValidationFailed);
                        }
                    }
                    #endregion 
                }
            } 

            _validationFailed = data.Where(x => x.Validations.Count > 0).ToList(); //copy the error item list
            _validationPassed = data.Where(x => x.Validations.Count == 0).ToList(); //copy the passed item list

            SessionWrapper.StoreSession_ShowInvalidRecords(_validationFailed);
            SessionWrapper.StoreSession_ShowValidRecords(_validationPassed);

            //ExcelViewModel excelViewModel = new ExcelViewModel();
            //List<ExcelViewModel> excelViewModelList = new List<ExcelViewModel>();
            //excelViewModel.ValidationFailed =_validationFailed;
            //excelViewModel.ValidationPassed = _validationPassed;           

            model.DataModel = data.OrderBy(x => x.LocalName).ToList();
            model.ValidationFailed = _validationFailed;
            model.ValidationPassed = _validationPassed;

            model.ValidationPassCount = _validationPassed.Count();
            model.ValidationErrorCount = _validationFailed.Count();

            SessionWrapper.StoreSession_Model(model);             
        }

        //private void Run_AssetTag_Validation1(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
        //{
        //    bool isLengthValid = false;
        //    bool isExistsInDb = false;

        //    //to capture all error desc
        //    //List<String> errorMsgList = new List<String>(); 

        //    isValidationFailed = ValidatatingLength(subItem.AssetTag, _length, name, Constants.AssetTag);
        //    AddToValidationErrorList(vdList, subItem, isValidationFailed);

        //    //length add error msg.
        //    //errorMsgList.Add(isValidationFailed.Desc);

        //    //chk length
        //    isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);

        //    string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
        //    if (!string.IsNullOrEmpty(htmlTag))
        //    {
        //        subItem.SetValidationFailed.AssetTag_ValidationFailed = htmlTag;
        //        //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
        //        isExistsInDb = false;
        //        isLengthValid = false;
        //    }
        //}

        //private void Run_LocalName_Validation1(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
        //{
        //    bool isLengthValid = false;
        //    bool isExistsInDb = false;

        //    //to capture all error desc
        //    //List<String> errorMsgList = new List<String>(); 

        //    isValidationFailed = ValidatatingLength(subItem.LocalName, _length, name, Constants.LocalName);
        //    AddToValidationErrorList(vdList, subItem, isValidationFailed);

        //    //length add error msg.
        //    //errorMsgList.Add(isValidationFailed.Desc);

        //    //chk length
        //    isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);


        //    //ClientCostCenterViewModel dbObject = (ClientCostCenterViewModel)SessionWrapper.GetSession_Customer().Find(s => s.Name.Trim() == subItem.Customer.Trim());
        //    //if (dbObject == null)
        //    //{
        //    //    isValidationFailed = ValidateDBValue(name, Constants.Customer);
        //    //    AddToValidationErrorList(vdList, subItem, isValidationFailed);
        //    //}

        //    //db add error msg.
        //    //errorMsgList.Add(isValidationFailed.Desc);

        //    //chk db 
        //    //isExistsInDb = ValidateDbValue(isValidationFailed.Name, isValidationFailed.Desc);

        //    string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
        //    if (!string.IsNullOrEmpty(htmlTag))
        //    {
        //        subItem.SetValidationFailed.LocalName_ValidationFailed = htmlTag;
        //        //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
        //        isExistsInDb = false;
        //        isLengthValid = false;
        //    }
        //}

        //private void Run_Customer_Validation1(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
        //{
        //    bool isLengthValid = false;
        //    bool isExistsInDb = false;

        //    //to capture all error desc
        //    //List<String> errorMsgList = new List<String>(); 

        //    isValidationFailed = ValidatatingLength(subItem.Customer, _length, name, Constants.Customer);
        //    AddToValidationErrorList(vdList, subItem, isValidationFailed);

        //    //length add error msg.
        //    //errorMsgList.Add(isValidationFailed.Desc);

        //    //chk length
        //    isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);


        //    ClientCostCenterViewModel dbObject = (ClientCostCenterViewModel)SessionWrapper.GetSession_Customer().Find(s => s.Name.Trim() == subItem.Customer.Trim());
        //    if (dbObject == null)
        //    {
        //        isValidationFailed = ValidateDBValue(name, Constants.Customer);
        //        AddToValidationErrorList(vdList, subItem, isValidationFailed);
        //    }

        //    //db add error msg.
        //    //errorMsgList.Add(isValidationFailed.Desc);

        //    //chk db 
        //    isExistsInDb = ValidateDbValue(isValidationFailed.Name, isValidationFailed.Desc);

        //    string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
        //    if (!string.IsNullOrEmpty(htmlTag))
        //    {
        //        subItem.SetValidationFailed.Customer_ValidationFailed = htmlTag;
        //        //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
        //        isExistsInDb = false;
        //        isLengthValid = false;
        //    }
        //}

        //private string GetHtmlTag(bool isLengthValid, bool isExistsInDb)
        //{            
        //    if (isLengthValid && isExistsInDb)
        //    {
        //        return Constants.ICON_DB_LENGTH;
        //    }
        //    else if (isLengthValid)
        //    {
        //        return Constants.ICON_LENGTH;
                
        //    }
        //    else if (isExistsInDb)
        //    {
        //        return Constants.ICON_DB; 
        //    }
        //    return string.Empty;
        //}

        private bool ValidateDbValue(string name, string desc)
        {
            if (name != null)
            {
                if (desc.Contains(Constants.ERROR_DB))
                {
                    return true;
                }
            }
            return false;
        }

        //private bool ValidateLengthValue(string name, string desc)
        //{
        //    if (name != null)
        //    {
        //        if (desc.Contains(Constants.ERROR_LENGTH))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private ValidateDataViewModel ValidatatingLength(string subItem, int length, string name, string constName)
        {
            ValidateDataViewModel _vd = new ValidateDataViewModel();
            if (name == constName)
            {
                if (!string.IsNullOrEmpty(subItem))
                {
                    //int _length = DataAnnotation.GetMaxLengthFromStringLengthAttribute(ExcelViewModel, "AssetTag");
                    if (subItem.Length > length)
                    {
                        ValidateDataViewModel vd = new ValidateDataViewModel
                        {
                            Name = constName,
                            Desc = string.Format("{0} cannot be longer than {1} characters.", name, length)
                        };
                        _vd = vd;
                    }
                }
            }
            return _vd;
        }

        private void AddToValidationErrorList(List<ValidateDataViewModel> vdList, ExcelViewModel subItem, ValidateDataViewModel validateData)
        {
            if (validateData.Name != null)
            {
                vdList.Add(validateData);
                subItem.Validations.Add(validateData);
            }
        }

        private ValidateDataViewModel ValidateDBValue(string name, string constName)
        {
            ValidateDataViewModel _vd = new ValidateDataViewModel();
            if (name == constName)
            {
                ValidateDataViewModel vd = new ValidateDataViewModel
                {
                    Name = constName,
                    Desc = string.Format("{0} does not exists in the db.", name)
                };
                _vd = vd;
            }
            return _vd;
        }

    }
}