using MSL.Helper;
using MSL.Helper.Session;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSL.Controllers
{
    public class MSLSystemAdminController : BaseController
    {
        //ImportViewModelManager storedevices1 = new ImportViewModelManager();
        //List<ImportViewModel> gridToDBRecordList = new List<ImportViewModel>();
        //List<ImportViewModel> dbRecordList = new List<ImportViewModel>();

        //public List<ImportViewModel> GridToDBRecordList { get; set; }
        //public List<ImportViewModel> FromDBToGrid { get; set; }
        
       // public MSLSystemAdminController(ISessionState sessionState) : base(sessionState) { }

        public ActionResult Index(string PageSizeSelect)
        {
            TempData["message"] = string.Empty;

            if (SessionWrapper.GetSession_Model() == null)
            {
                ImportViewModelManager modelManager = new ImportViewModelManager();
                SessionWrapper.StoreSession_Model(modelManager);
            }
            return View(SessionWrapper.GetSession_Model());
        }
       
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, FormCollection formCollection, string submitButton)
        {
            if (submitButton != null) { submitButton = submitButton.ToLower().Trim(); }
            
            string pageSizeDDL = string.Empty; 

            if (file == null && formCollection.Count == 0 && submitButton == null)
            {
                InvalidFileSelected();
            }
            else if (file != null)
            {
                if (Request.Files["file"].ContentLength > 0)
                { 
                    if (!ValidateExtension(file))
                    {
                        InvalidFileSelected();
                    }
                    else
                    { 
                        if (!CheckAnyErrorReadingFile())
                        {
                            //extract from excel file....
                            ReadExcelData loadExcelData = new ReadExcelData();
                            List<ExcelViewModel> loadedData = loadExcelData.LoadDataFromExcel(FileLocationPath());
                            if (loadedData.Count() > 0) { ValidateExcelData(loadedData); }
                        }
                    }                                          
                }
            }
            else if (submitButton != null)
            {
                SubmitButton(formCollection, submitButton); 
            }

            return View(SessionWrapper.GetSession_Model());
        }

        private string FileLocationPath()
        {
            string fileLocation = Server.MapPath("~/Excel/") + Request.Files["file"].FileName;
            Session.Add("fileLocation", fileLocation);
            return fileLocation;
        }

        private static bool ValidateExtension(HttpPostedFileBase file)
        {
            ReadExcelData validateEXT = new ReadExcelData();
            bool extValidate = validateEXT.ValidateFileExtension(file);
            return extValidate;
        }

        private void SubmitButton(FormCollection formCollection, string submitButton)
        {
            if (submitButton == Constants.SAVE_TO_DB)
            {
                if (formCollection.Count > 0 && formCollection != null)
                {
                    if (SessionWrapper.GetSession_Model() != null)
                    {
                        //save to db....
                    }
                }
            }
            else if (submitButton == Constants.REMOVE_ITEM_FROM_GRID)
            {
                RemoveItems(formCollection);
            }
            else if (Constants.SELECT_RECORD_ARRAY_LIST.Select(x => x.Trim()).Contains(submitButton))
            {
                //AFTER POST THE PAGE IT LOOSES THE PREVIOUS SELECTION...!!! NEEDS TO FIND OUT HOW TO PERSIST THE RECORDS..
                ShowRecords(submitButton);
            }
            else if (Constants.SELECT_PAGE_SIZE_ARRAY_LIST.Select(x => x.Trim()).Contains(submitButton))
            {
                if (SessionWrapper.GetSession_Model() != null)
                {
                    if (((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel.Count > 10)
                    {
                        SetPageSize(submitButton);
                    }
                }
            }
        }

        #region local helper private methods

        private void RemoveItems(FormCollection formCollection)
        {
            if (formCollection.Count > 0 && formCollection != null)
            {
                RemoveFormCollectionData removeItemFC = new RemoveFormCollectionData();

                //get the updated data after it remove the items from the list.
                SessionWrapper.StoreSession_Model(removeItemFC.RemoveItemFromGrid(formCollection)); 
            }
        }

        private void ShowRecords(string submitButton)
        {
            if (((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel.Count > 0)
            {
                //set the dropdownlist
                ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).ShowRecords = submitButton;

                if (submitButton == Constants.SHOW_INVALID_RECORDS)
                {

                    ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel = SessionWrapper.GetSession_ShowInvalidRecords();
                }
                else if (submitButton == Constants.SHOW_VALID_RECORDS)
                {
                    ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel = SessionWrapper.GetSession_ShowValidRecords();
                }
                else if (submitButton == Constants.SHOW_ALL_RECORDS)
                {
                    ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel = SessionWrapper.GetSession_Model().DataModel;
                }
            }  
        }

        private void SetPageSize(string submitButton)
        {
            var pageSize = 10;
            if (submitButton == "all")
            {
                pageSize = ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel.Count();
            }
            else
            {
                pageSize = Convert.ToInt16(submitButton);
            }
            ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).PageSize = pageSize; 
        }

        private void ValidateExcelData(List<ExcelViewModel> getExcelDataList)
        {
            ImportViewModelManager model = new ImportViewModelManager();
            ValidationFailedModel validationModel = new ValidationFailedModel();
           
            //foreach (var item in getExcelDataList)
            //{
            //    if (item.SerialNumber.Length < 10 || item.SerialNumber.Length > 10 || item.Location.Contains("DATA CENTER PITTSBURGH"))
            //    {
            //        if (item.Location.Contains("DATA CENTER PITTSBURGH"))
            //        {
            //            item.ValidationViewModel.LocationValidationFailed = "its not exists, wrong location name...";
            //            validationModel.LocalNameValidationFailed = "its not exists, wrong location name..."; 

            //        }
            //        if (item.SerialNumber.Length < 10 || item.SerialNumber.Length > 10)
            //        {
            //            item.ValidationViewModel.SerialNumberValidationFailed = "serial number failed row";
            //            validationModel.SerialNumberValidationFailed = "serial number failed row";
            //            //
            //        }
            //        item.IsValidationError = true;
            //    }
            //}

            List<ExcelViewModel> _validationFailed = new List<ExcelViewModel>();
            List<ExcelViewModel> _validationPassed = new List<ExcelViewModel>();

            foreach (var item1 in getExcelDataList)
            {
                if (item1.IsValidationError)
                {
                    ExcelViewModel fail = new ExcelViewModel
                    {
                        Location = item1.Location
                    };

                    _validationFailed.Add(fail);
                }
                else
                {
                    ExcelViewModel pass = new ExcelViewModel
                    {
                        Location = item1.Location
                    };

                    _validationPassed.Add(pass);
                }
            }

            SessionWrapper.StoreSession_ShowInvalidRecords(_validationFailed);
            SessionWrapper.StoreSession_ShowValidRecords(_validationPassed);

            model.DataModel = getExcelDataList;
            model.ValidationFailed = _validationFailed;
            model.ValidationPassed = _validationPassed;

            model.ValidationPassCount = _validationPassed.Count();
            model.ValidationErrorCount = _validationFailed.Count();

            SessionWrapper.StoreSession_Model(model);
            //StoreSession_DataModel(model.DataModel);
        }

        private bool CheckAnyErrorReadingFile()
        {
            string errorReadingExcel = (string)Session["ErrorReadingExcel"];
            if (!string.IsNullOrEmpty(errorReadingExcel))
            {
                if (Session["ErrorReadingExcel"] != null)
                {
                    TempData["type"] = "danger";
                    TempData["title"] = "Invalid file!";
                    TempData["message"] = "Its not a valid file.";
                    return true;
                }
            }
            return false;
        }      

        private void InvalidFileSelected()
        {
            TempData["type"] = "danger";
            TempData["title"] = "Invalid file selected";
            TempData["message"] = "valid files are of xls/xlxs types are allowed!";
        }


        #endregion

    }
}