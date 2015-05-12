using AutoMapper;
using MSL.Helper;
using MSL.Helper.Session;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MSL.Controllers
{
    public class BulkUploadController : Controller
    {
        //private mls_dbEntities db = new mls_dbEntities();

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
                    ReadExcelData validateEXT = new ReadExcelData();
                    bool extValidate = validateEXT.ValidateFileExtension(file);

                    if (!extValidate)
                    {
                        InvalidFileSelected();
                    }
                    else
                    {
                        string fileLocation = FileLocationPath();
                        Session.Add("fileLocation", fileLocation);

                        if (!CheckAnyErrorReadingFile())
                        {
                            //extract from excel file....
                            ReadExcelData loadExcelData = new ReadExcelData();
                            List<ExcelViewModel> loadedData = loadExcelData.LoadDataFromExcel(fileLocation); 

                            if (loadedData.Count() > 0) 
                            {
                                if (!CheckForInvalidDataInExcel())
                                {
                                    ValidateExcelData validateExcelData = new ValidateExcelData();
                                    validateExcelData.RunValidationCheck(loadedData); 
                                }
                            }                            
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
            return Server.MapPath(ConfigurationManager.AppSettings["FileLocation"]) + Request.Files["file"].FileName;
        }

        private void SubmitButton(FormCollection formCollection, string submitButton)
        {
            if (submitButton == Constants.SAVE_TO_DB)
            {
                if (formCollection.Count > 0 && formCollection != null)
                {
                    if (SessionWrapper.GetSession_Model() != null)
                    {
                        if (IsValidationGridDataFailed(formCollection))
                        {
                            DisplayInvalidData();
                        }
                        else
                        {
                            


                            ImportViewModelManager model = new ImportViewModelManager();
                            model = SessionWrapper.GetSession_Model();
                            ExtractFormCollectionData extractFrmCollection = new ExtractFormCollectionData();
                            model.DataModel = extractFrmCollection.XtractFormCollectionData(formCollection);
                            SessionWrapper.StoreSession_Model(model);

                            //save to db....                        
                            List<DisplayMessage> successMSG = UpsertClass.UpsertData();

                            DisplayStatus(successMSG);
                        }
                    }
                }
            }
            else if (submitButton == Constants.REFRESH_GRID)
            {
                Session.RemoveAll();
            }
            else if (submitButton == Constants.REMOVE_ITEM_FROM_GRID)
            {
                RemoveItems(formCollection);
            }
            else if (submitButton == Constants.VALIDATE_DATA)
            {
                bool isValid = IsValidationGridDataFailed(formCollection);
                if (isValid)
                {
                    DisplayInvalidData();
                }
                else
                {
                    DisplayValidData();
                }

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

        private void DisplayInvalidData()
        {
            TempData["type"] = "danger";
            TempData["title"] = "Invalid data";
            TempData["message"] = "Invalid data please correct the data and try again!";
        }

        private void DisplayValidData()
        {
            TempData["type"] = "successr";
            TempData["title"] = "Valid data";
            TempData["message"] = "Validation passed!";
        }
        private void DisplayStatus(List<DisplayMessage> msg)
        {
            if (msg.Count > 0)
            {
                foreach (var item in msg)
                {
                    TempData["type"] = item.Type;
                    TempData["title"] = item.Title;
                    TempData["message"] = item.Message;
                }
            }            
        }

        private static bool IsValidationGridDataFailed(FormCollection formCollection)
        {            
            ImportViewModelManager model = new ImportViewModelManager();
            model = SessionWrapper.GetSession_Model();
            ExtractFormCollectionData extractFrmCollection = new ExtractFormCollectionData();
            model.DataModel = extractFrmCollection.XtractFormCollectionData(formCollection);

            ValidateExcelData validateExcelData = new ValidateExcelData();
            validateExcelData.RunValidationCheck(model.DataModel);

            //get the latest model data after validation done.
            model = SessionWrapper.GetSession_Model();

            if (model.ValidationFailed.Count > 0) { return true; }

            return false;
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
                    //var result = list1.Concat(list2).OrderBy(x => x.Elevation).ToList();
                    var result = SessionWrapper.GetSession_ShowInvalidRecords().Concat(SessionWrapper.GetSession_ShowValidRecords()).OrderBy(x => x.LocalName).ToList();
                    ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel = result;
  
                }
            }
        }

        private void SetPageSize(string submitButton)
        {
            int pageSize = 10;
            int all = ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel.Count();

            if (submitButton == "all")
            {
                pageSize = ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).DataModel.Count();
            }
            else
            {
                pageSize = Convert.ToInt32(submitButton);
            }

            if (submitButton == "all")
            {
                ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).PageSize = all;
            }
            else
            {
                ((ImportViewModelManager)(SessionWrapper.GetSession_Model())).PageSize = pageSize;
            }
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

        private bool CheckForInvalidDataInExcel()
        {
            string errorReadingExcel = (string)Session["ErrorInvalidReadingExcel"];
            if (!string.IsNullOrEmpty(errorReadingExcel))
            {
                if (Session["ErrorInvalidReadingExcel"] != null)
                {
                    TempData["type"] = "danger";
                    TempData["title"] = "Invalid datafile!";
                    TempData["message"] = "Specified cast is not valid.";
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