using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{ 
    public class ImportViewModel
    {
        public ImportViewModel()
        {
            ValidationViewModel = new ImportValidationModel();
        }

        public string Location { get; set; }
        public string RackShelf { get; set; }
        public string DCLocation { get; set; }
        public string Customer { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string UseState { get; set; }
        public string LocalName { get; set; }
        public string AssetTag { get; set; }

        public string RowNumber { get; set; }
        public string SelectedRowId { get; set; }

        public ImportValidationModel ValidationViewModel { get; set; }
        //public int ValidationErrorCount { get; set; }
        //public int ValidationPassCount { get; set; }
        public bool IsValidationError { get; set; }
    }

   
}