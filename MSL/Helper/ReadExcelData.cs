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
    public class ReadExcelData
    {
        public List<ExcelViewModel> LoadDataFromExcel(string fileLocation)
        {
            List<ExcelViewModel> modelList = new List<ExcelViewModel>();

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
                        HttpContext.Current.Session.Add("ErrorInvalidReadingExcel", null);
                        

                        if (totalRowsCount > 0)
                        {
                            int i = 0;
                            foreach (DataRow row in table.Rows) // Loop over the rows.
                            {
                                ExcelViewModel model = new ExcelViewModel();
                                for (int j = 0; j < row.ItemArray.Count(); j++)
                                {
                                    model.RowNumber = i.ToString();

                                    
                                    model.Customer=  row.Table.Rows[i]["Customer"].ToString();
                                    model.LocalName =  row.Table.Rows[i]["LocalName"].ToString();
                                    model.SerialNumber =  row.Table.Rows[i]["SerialNumber"].ToString();
                                    model.SystemState = row.Table.Rows[i]["System_State"].ToString();
                                    model.ServerType = row.Table.Rows[i]["Server_Type"].ToString();
                                    model.Category = row.Table.Rows[i]["Category"].ToString();
                                    model.ServiceCategory = row.Table.Rows[i]["Service_Category"].ToString();
                                    model.Country = row.Table.Rows[i]["Country"].ToString();
                                    model.Domain = row.Table.Rows[i]["Domain"].ToString();
                                    model.IsLocalSecurity = row.Table.Rows[i]["Is_Local_Security"].ToString();
                                    model.SecurityWaiver = row.Table.Rows[i]["Security_Waiver"].ToString();
                                    model.SecurityWaiverNotes = row.Table.Rows[i]["Security_Waiver_Notes"].ToString();
                                    model.OS = row.Table.Rows[i]["OS"].ToString();
                                    model.OSMinor = row.Table.Rows[i]["OS_Minor"].ToString();

                                    model.OSPatchLevel = row.Table.Rows[i]["OS_Patch_Level"].ToString();
                                    model.KernelPatch = row.Table.Rows[i]["Kernel_Patch"].ToString();
                                    model.PatchingGroup = row.Table.Rows[i]["Patching_Group"].ToString();
                                    model.ServiceIP = row.Table.Rows[i]["Service_IP"].ToString();
                                    model.ServiceFQDN = row.Table.Rows[i]["Service_FQDN"].ToString();
                                    model.ConsoleAccess = row.Table.Rows[i]["Console_Access"].ToString();
                                    model.CPUCores = row.Table.Rows[i]["CPU_Cores"].ToString(); //row.Table.Rows[i]["CPU_Cores"] as int? ?? 0; 
                                    model.CPUCount =  row.Table.Rows[i]["CPU_Count"].ToString();
                                    model.CPUModel = row.Table.Rows[i]["CPU_Model"].ToString();
                                    model.CPUSpeed = row.Table.Rows[i]["CPU_Speed"].ToString();
                                    model.LocalDiskCapacity = row.Table.Rows[i]["Local_Disk_Capacity"].ToString();
                                    model.LocalDiskSlotTotal = row.Table.Rows[i]["Local_Disk_Slot_Total"].ToString();
                                    //model.LocalDiskSlotTotal = row.Table.Rows[i]["Local_Disk_Slot_Total"] as int? ?? 0;                                    
                                   
                                    model.LocalDiskInstalled = row.Table.Rows[i]["Local_Disk_Installed"].ToString();
                                    model.LocalRaidLevel = row.Table.Rows[i]["Local_Raid_Level"].ToString();

                                    model.PhysicalMemory = row.Table.Rows[i]["Physical_Memory"].ToString();
                                    model.PurchaseDate = (DateTime)row.Table.Rows[i]["Purchase_Date"];
                                    model.Ownership = row.Table.Rows[i]["Ownership"].ToString();
                                    model.TimeZone = row.Table.Rows[i]["Time_Zone"].ToString();
                                    model.StreetAddress = row.Table.Rows[i]["Street_Address"].ToString();
                                    model.RegulationCompliance = row.Table.Rows[i]["Regulation_Compliance"].ToString();
                                    model.InCluster = row.Table.Rows[i]["In_Cluster"].ToString();
                                    model.RebootAutomatic = row.Table.Rows[i]["Reboot_Automatic"].ToString();
                                    model.RebootNotes = row.Table.Rows[i]["Reboot_Notes"].ToString();
                                    model.MasterBackupServer = row.Table.Rows[i]["Master_Backup_Server"].ToString();
                                    model.BackupIP = row.Table.Rows[i]["Backup_IP"].ToString();
                                    model.VMPlatform = row.Table.Rows[i]["VM_Platform"].ToString();
                                    model.VMHost = row.Table.Rows[i]["VM_Host"].ToString();
                                    model.PrimaryApplication = row.Table.Rows[i]["Primary_Application"].ToString();

                                    model.BackupAgent = row.Table.Rows[i]["Backup_Agent"].ToString();
                                    model.MonitorAgent = row.Table.Rows[i]["Monitor_Agent"].ToString();
                                    model.Location = row.Table.Rows[i]["Location"].ToString();
                                    model.RackShelf = row.Table.Rows[i]["Rack_Shelf"].ToString();  //row.Table.Rows[i]["Rack_Shelf"] as int? ?? 0;// (int)row.Table.Rows[i]["Rack_Shelf"];
                                    model.DCLocation = row.Table.Rows[i]["DC_Location"].ToString();
                                    model.Model = row.Table.Rows[i]["Model"].ToString();
                                    model.Vendor = row.Table.Rows[i]["Vendor"].ToString();
                                    model.AssetTag = row.Table.Rows[i]["Asset_Tag"].ToString();
                                    model.WarrantyEndDate = (DateTime)row.Table.Rows[i]["Warranty_End_Date"]; 

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
                            throw;
                        }
                        else if(ex.Message.Contains("Specified cast is not valid."))
                        {
                            HttpContext.Current.Session.Add("ErrorInvalidReadingExcel", "Specified cast is not valid.");
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