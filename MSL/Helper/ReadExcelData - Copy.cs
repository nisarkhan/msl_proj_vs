using MSL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

namespace MSL.Helper
{
    public class ReadExcelData_backup
    {
        public List<ImportViewModel> LoadDataFromExcel(string fileLocation)
        {
            List<ImportViewModel> modelList = new List<ImportViewModel>();

            OleDbConnection oledbConn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet ds = new DataSet();

            int totalRowsCount = 0;
            string fileExtension = System.IO.Path.GetExtension(fileLocation);

            //need to pass relative path after deploying on server
            //string path = Request.Files["file"].FileName; //System.IO.Path.GetFullPath(Server.MapPath("~/InformationNew.xlsx"));
            /*connection string  to work with excel file. HDR=Yes - indicates 
            that the first row contains columnnames, not data. HDR=No - indicates 
            the opposite. "IMEX=1;" tells the driver to always read "intermixed" 
            (numbers, dates, strings etc) data columns as text. 
            Note that this option might affect excel sheet write access negative. */

            using (OleDbConnection connection = new OleDbConnection())
            {
                if (Path.GetExtension(fileExtension) == ".xls")
                {
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (Path.GetExtension(fileExtension) == ".xlsx")
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                }

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error: " + ex.Message);
                }

                //string sql = "SELECT [location],[rack_shelf],[dc_location],[customer],[serialnumber],[model],[use_state],[localname],[asset_tag] FROM [device$]";
                //string sql = "SELECT * FROM [device$]";
                string sql = ConfigurationManager.AppSettings["SQL_Statement"];

                if (sql == null)
                {
                    throw new Exception(String.Format("Could not find setting '{0}',", "SQL statement"));
                }

                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.Text;
                        oleda = new OleDbDataAdapter(command);
                        oleda.Fill(ds);

                        DataTable table = ds.Tables[0];
                        totalRowsCount = table.Rows.Count;

                        HttpContext.Current.Session.Add("ErrorReadingExcel", null);

                        if (totalRowsCount > 0)
                        {
                            int i = 0;
                            foreach (DataRow row in table.Rows) // Loop over the rows.
                            {
                                ImportViewModel model = new ImportViewModel();
                                for (int j = 0; j < row.ItemArray.Count(); j++)
                                {
                                    //device.SelectedRowId = row.Table.Rows[i]["location"].ToString();
                                    model.RowNumber = i.ToString();
                                    model.Location = row.Table.Rows[i]["location"].ToString();
                                    model.RackShelf = row.Table.Rows[i]["rack_shelf"].ToString();
                                    model.DCLocation = row.Table.Rows[i]["dc_location"].ToString();
                                    model.Customer = row.Table.Rows[i]["customer"].ToString();
                                    model.SerialNumber = row.Table.Rows[i]["serialnumber"].ToString();
                                    model.Model = row.Table.Rows[i]["model"].ToString();
                                    model.UseState = row.Table.Rows[i]["use_state"].ToString();
                                    model.LocalName = row.Table.Rows[i]["localname"].ToString();
                                    model.AssetTag = row.Table.Rows[i]["asset_tag"].ToString();
                                    modelList.Add(model);
                                    break;
                                }
                                i++;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        if(ex.Message.Contains("is not a valid name.  Make sure that it does not include invalid characters or punctuation and that it is not too long."))
                        {
                            HttpContext.Current.Session.Add("ErrorReadingExcel", "Its not a valid file.");
                        }
                    }
                }
            }
            return modelList;
        }

        public bool ValidateFileExtension(HttpPostedFileBase file)
        {
            String FileExtn = System.IO.Path.GetExtension(file.FileName).ToLower();
            if (!(FileExtn == ".xls" || FileExtn == ".xlsx"))
            {
                return false;
            }
            return true;
        }
    }
}