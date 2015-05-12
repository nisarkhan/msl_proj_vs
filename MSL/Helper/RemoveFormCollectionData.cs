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
    public class RemoveFormCollectionData //: BaseController
    {
        //public RemoveFormCollectionData(MSL.Helper.Session.ISessionState sessionState) : base(sessionState) { }

        //RemoveItemFromGrid
        public ImportViewModelManager RemoveItemFromGrid(FormCollection formCollection)
        {
            ImportViewModelManager fm = ((ImportViewModelManager)HttpContext.Current.Session["model"]);

            //int i = 0;
            ExcelViewModel _gridData = new ExcelViewModel();
            List<ExcelViewModel> selectedRows = new List<ExcelViewModel>();

            var appSettings = formCollection.AllKeys
                //.Where(k => k.StartsWith("selectedRow_"))
                    .ToDictionary(k => k, k => formCollection[k]);

            //var asDictionary = formCollection.Cast<string>()
            //    //.Where(key => key.StartsWith(prefix))
            //    .ToDictionary(key => key, key => formCollection[key])
            //    .ToList();

            //var afterRemoveItem = fm.DataModel.Cast<string>()
            //    //.Where(key => key.StartsWith("selectedRow_"))
            //   .ToDictionary(key => key, key => formCollection[key])
            //   .ToList();

            SelectedFormCollectionData selectedRow = new SelectedFormCollectionData();
            selectedRows = selectedRow.SelectedRowFormCollection(formCollection);

            if (selectedRows.Count > 0)
            {
                foreach (var item in selectedRows)
                {
                    if (!string.IsNullOrEmpty(item.SelectedRowId))
                    {
                        foreach (var item1 in fm.DataModel.ToList())
                        {
                            if (item.LocalName == item1.LocalName)
                            {
                                // remove
                                bool removed = fm.DataModel.Remove(fm.DataModel.SingleOrDefault(x => x.LocalName == item.LocalName));
                            }
                        }
                    }
                }
            }
            return fm;
        }
    }
}