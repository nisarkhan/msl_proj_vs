using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{
    public class ImportViewModelManager
    {
        public ImportViewModelManager()
        {
            DataModel = new List<ExcelViewModel>();
            ValidationFailed = new List<ExcelViewModel>();
            ValidationPassed = new List<ExcelViewModel>();
        }

        public List<ExcelViewModel> DataModel { get; set; }
        public List<ExcelViewModel> ValidationFailed { get; set; }
        public List<ExcelViewModel> ValidationPassed { get; set; }

        private int _pageSize = 10;
        private int _page = 1;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private string _showRecords = "Show All Records";
        public string ShowRecords
        {
            get { return _showRecords; }
            set { _showRecords = value; }
        }

        public int Page
        {
            get { return _page; }
            set { _page = value; }
        }
        public int TotalCount { get; set; }

        public int ValidationErrorCount { get; set; }
        public int ValidationPassCount { get; set; }
        public bool IsValidationError { get; set; }        
    }
}