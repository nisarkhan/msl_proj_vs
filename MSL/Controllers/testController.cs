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
    public class testController : Controller
    {
        ImportViewModelManager storedevices = new ImportViewModelManager();
        List<ImportViewModel> gridToDBRecordList = new List<ImportViewModel>();
        List<ImportViewModel> dbRecordList = new List<ImportViewModel>();
        public List<ImportViewModel> GridToDBRecordList { get; set; }
        public List<ImportViewModel> FromDBToGrid { get; set; }

         

        [HttpPost]
        public ActionResult PageSizeSelect(string PageSizeSelect)
        {
            return View("Index", Session["storedevices"]);
        }

        public ActionResult Index(string PageSizeSelect)
        {
            TempData["message"] = string.Empty;

            if (Session["storedevices"] == null)
            {
                ImportViewModelManager fm = new ImportViewModelManager();
                fm = storedevices;
                Session["storedevices"] = fm;
            }
            else if (!string.IsNullOrEmpty(PageSizeSelect))
            {
                if (Session["storedevices"] == null) { return View("Index"); }
                Int16 pageSize = Convert.ToInt16(PageSizeSelect);
                ((ImportViewModelManager)(Session["storedevices"])).PageSize = pageSize;
                PageSizeSelect = null;
            }
            return View(Session["storedevices"]);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, FormCollection formCollection, string submitButton, IEnumerable<ImportViewModel> model1)
        {
            bool isPageSizeChange = false;
            string pageSizeDDL = string.Empty;
            if (formCollection.Count > 0)
            {
                if (string.IsNullOrEmpty(submitButton))
                {
                    foreach (string _formData in formCollection)
                    {
                        if (_formData == "PageSizeSelect")
                        {
                            pageSizeDDL = formCollection[_formData];
                            isPageSizeChange = true;
                            break;
                        }
                    }
                }
            }
            if (isPageSizeChange)
            {
                if (Session["storedevices"] == null) { return View("Index"); }
                Int16 pageSize = Convert.ToInt16(pageSizeDDL);
                ((ImportViewModelManager)(Session["storedevices"])).PageSize = pageSize;
            }
            else
            {
                if (file == null && formCollection.Count == 0 && submitButton == null)
                {
                    InvalidFileSelected();
                }
                else if (file != null)
                {
                    if (Request.Files["file"].ContentLength > 0)
                    {
                        ReadExcelData_backup helper = new ReadExcelData_backup();
                        bool validate = helper.ValidateFileExtension(file);

                        if (!validate)
                        {
                            InvalidFileSelected();
                        }
                        else
                        {
                            string fileLocation = Server.MapPath("~/Excel/") + Request.Files["file"].FileName;
                            //store the file name in session...
                            Session.Add("fileLocation", fileLocation);

                            //extract from excel file....
                            ReadExcelData_backup loadExcelData = new ReadExcelData_backup();
                            List<ImportViewModel> loadExcelDataList = loadExcelData.LoadDataFromExcel(fileLocation);

                            if (Session["ErrorReadingExcel"] != null)
                            {
                                TempData["type"] = "danger";
                                TempData["title"] = "Invalid file!";
                                TempData["message"] = "Its not a valid file.";
                            }

                            ImportViewModelManager model = new ImportViewModelManager();

                            //validate the data...
                            foreach (var item in loadExcelDataList)
                            {
                                if (item.Location.Contains("DATA CENTER PITTSBURGH"))
                                {
                                    item.ValidationViewModel.LocationValidationFailed = "its not exists, wrong location name...";
                                }
                                if (item.SerialNumber.Length < 10 || item.SerialNumber.Length > 10)
                                {
                                    item.ValidationViewModel.SerialNumberValidationFailed = "serial number failed row";
                                }
                            }
                            model.DataModel = loadExcelDataList;
                            Session["storedevices"] = model;
                        }
                    }
                }
                if (submitButton != null)
                {
                    RemoveFormCollectionData removeItemFC = new RemoveFormCollectionData();
                    if (submitButton.ToLower() == "save to db")
                    {
                        if (formCollection.Count > 0 && formCollection != null)
                        {
                            if (Session["storedevices"] == null) { return View("Index"); }
                            //helper.LoadDataFormCollection(formCollection);
                        }
                    }
                    else if (submitButton.ToLower() == "remove item from grid")
                    {
                        if (formCollection.Count > 0 && formCollection != null)
                        {
                            if (Session["storedevices"] == null) { return View("Index"); }

                            //get the updated data after it remove the items from the list.
                            Session["storedevices"] = removeItemFC.RemoveItemFromGrid(formCollection);
                        }
                    }
                    else
                    {
                        if (Session["storedevices"] == null) { return View("Index"); }
                        Int16 pageSize = Convert.ToInt16(submitButton);
                        ((ImportViewModelManager)(Session["storedevices"])).PageSize = pageSize;
                        submitButton = null;

                    }
                }
            }

            return View(Session["storedevices"]);
        }

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase file, FormCollection formCollection, string pageSizeDDL, string saveToDB, string removeItems, string PageList)
        //{
        //    if (file == null && formCollection.Count == 0 && pageSizeDDL == null && saveToDB == null && removeItems == null)
        //    {
        //        InvalidFileSelected();
        //    }
        //    else if (file != null)
        //    {
        //        if (Request.Files["file"].ContentLength > 0)
        //        {
        //            LoadDataHelper helper = new LoadDataHelper();
        //            bool validate = helper.ValidateFileExtension(file);

        //            if (!validate)
        //            {
        //                InvalidFileSelected();
        //            }
        //            else
        //            {
        //                //List<ImportViewModel> deviceData = new List<ImportViewModel>();

        //                string fileLocation = Server.MapPath("~/Excel/") + Request.Files["file"].FileName;
        //                //store the file name in session...
        //                Session.Add("fileLocation", fileLocation);

        //                //extract from excel file....
        //                LoadExcelData loadExcelData = new LoadExcelData();
        //                List<ImportViewModel> deviceData = loadExcelData.LoadDataFromExcel(fileLocation);
        //                ImportViewModelManager fm = new ImportViewModelManager();

        //                //validate the data...
        //                foreach (var item in deviceData)
        //                {
        //                    //bool exists = item.Location.All(element => Char.IsLetter(element));
        //                    //string myString = "Random String Of Letters";
        //                    //bool allLetters = myString.All(c => Char.IsLetter(c));
        //                    //bool onlyAlphas = item.Location.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

        //                    if (item.Location.Contains("DATA CENTER PITTSBURGH"))
        //                    {
        //                        item.ValidationFailed.LocationValidationFailed = "its not exists, wrong location name...";
        //                    }
        //                    if (item.SerialNumber.Length < 10 || item.SerialNumber.Length > 10)
        //                    {
        //                        item.ValidationFailed.SerialNumberValidationFailed = "serial number failed row";
        //                    }
        //                }
        //                fm.DataModel = deviceData;
        //                Session["storedevices"] = fm;
        //            }
        //        }
        //    }
        //    if (saveToDB != null)
        //    {
        //        if (saveToDB.ToLower() == "save to db")
        //        {
        //            LoadDataHelper helper = new LoadDataHelper();
        //            if (formCollection.Count > 0 && formCollection != null)
        //            {
        //                if (Session["storedevices"] == null) { return View("Index"); }
        //                //helper.LoadDataFormCollection(formCollection);
        //            }
        //        }
        //    }
        //    if (removeItems != null)
        //    {
        //        if (removeItems.ToLower() == "remove item from grid")
        //        {
        //            if (formCollection.Count > 0 && formCollection != null)
        //            {
        //                LoadDataHelper helper = new LoadDataHelper();
        //                if (Session["storedevices"] == null) { return View("Index"); }

        //                //ImportViewModelManager _removeItems = helper.RemoveItemFromGrid(formCollection);
        //                Session["storedevices"] = helper.RemoveItemFromGrid(formCollection);
        //            }
        //        }
        //    }
        //    else if (!string.IsNullOrEmpty(pageSizeDDL))
        //    {
        //        if (Session["storedevices"] == null) { return View("Index"); }
        //        Int16 pageSize = Convert.ToInt16(pageSizeDDL);
        //        ((ImportViewModelManager)(Session["storedevices"])).PageSize = pageSize;
        //        pageSizeDDL = null;
        //    }
        //    return View(Session["storedevices"]);
        //} 

        #region local helper private methods

        private void InvalidFileSelected()
        {
            TempData["type"] = "danger";
            TempData["title"] = "Invalid file selected";
            TempData["message"] = "valid files are of xls/xlxs types are allowed!";
        }


        #endregion

    }
}