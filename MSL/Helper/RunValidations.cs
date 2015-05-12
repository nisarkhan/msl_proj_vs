using MSL.Helper.Session;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MSL.Helper
{
    //NOT USING...
    //public static class RunValidations
    //{

    //    public static void Run_Customer_Validation(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
    //    {
    //        bool isLengthValid = false;
    //        bool isExistsInDb = false;

    //        //to capture all error desc
    //        //List<String> errorMsgList = new List<String>(); 

    //        isValidationFailed = ValidatatingLength(subItem.Customer, _length, name, Constants.Customer);
    //        AddToValidationErrorList(vdList, subItem, isValidationFailed);

    //        //length add error msg.
    //        //errorMsgList.Add(isValidationFailed.Desc);

    //        //chk length
    //        isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);


    //        ClientCostCenterViewModel dbObject = (ClientCostCenterViewModel)SessionWrapper.GetSession_Customer().Find(s => s.Name.Trim() == subItem.Customer.Trim());
    //        if (dbObject == null)
    //        {
    //            isValidationFailed = CheckDBValue(name, Constants.Customer);
    //            AddToValidationErrorList(vdList, subItem, isValidationFailed);
    //        }

    //        //db add error msg.
    //        //errorMsgList.Add(isValidationFailed.Desc);

    //        //chk db 
    //        isExistsInDb = ValidateDbValue(isValidationFailed.Name, isValidationFailed.Desc);

    //        string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
    //        if (!string.IsNullOrEmpty(htmlTag))
    //        {
    //            subItem.SetValidationFailed.Customer_ValidationFailed = htmlTag;
    //            //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
    //            isExistsInDb = false;
    //            isLengthValid = false;
    //        }
    //    }

    //    public static void Run_LocalName_Validation(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
    //    {
    //        bool isLengthValid = false;
    //        bool isExistsInDb = false;

    //        //to capture all error desc
    //        //List<String> errorMsgList = new List<String>(); 

    //        isValidationFailed = ValidatatingLength(subItem.LocalName, _length, name, Constants.LocalName);
    //        AddToValidationErrorList(vdList, subItem, isValidationFailed);

    //        //length add error msg.
    //        //errorMsgList.Add(isValidationFailed.Desc);

    //        //chk length
    //        isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);


    //        //ClientCostCenterViewModel dbObject = (ClientCostCenterViewModel)SessionWrapper.GetSession_Customer().Find(s => s.Name.Trim() == subItem.Customer.Trim());
    //        //if (dbObject == null)
    //        //{
    //        //    isValidationFailed = ValidateDBValue(name, Constants.Customer);
    //        //    AddToValidationErrorList(vdList, subItem, isValidationFailed);
    //        //}

    //        //db add error msg.
    //        //errorMsgList.Add(isValidationFailed.Desc);

    //        //chk db 
    //        //isExistsInDb = ValidateDbValue(isValidationFailed.Name, isValidationFailed.Desc);

    //        string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
    //        if (!string.IsNullOrEmpty(htmlTag))
    //        {
    //            subItem.SetValidationFailed.LocalName_ValidationFailed = htmlTag;
    //            //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
    //            isExistsInDb = false;
    //            isLengthValid = false;
    //        }
    //    }

    //    public static void Run_AssetTag_Validation(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
    //    {
    //        bool isLengthValid = false;
    //        bool isExistsInDb = false;

    //        //to capture all error desc
    //        //List<String> errorMsgList = new List<String>(); 

    //        isValidationFailed = ValidatatingLength(subItem.AssetTag, _length, name, Constants.AssetTag);
    //        AddToValidationErrorList(vdList, subItem, isValidationFailed);

    //        //length add error msg.
    //        //errorMsgList.Add(isValidationFailed.Desc);

    //        //chk length
    //        isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);

    //        string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
    //        if (!string.IsNullOrEmpty(htmlTag))
    //        {
    //            subItem.SetValidationFailed.AssetTag_ValidationFailed = htmlTag;
    //            //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
    //            isExistsInDb = false;
    //            isLengthValid = false;
    //        }
    //    }

    //    //Run_SerialNumber_Validation
    //    public static void Run_Validation(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
    //    {
    //        bool isLengthValid = false;
    //        bool isExistsInDb = false; 

    //        isValidationFailed = ValidatatingLength(name, _length, name, name);
    //        AddToValidationErrorList(vdList, subItem, isValidationFailed);

    //        //chk length
    //        isLengthValid = ValidateLengthValue(isValidationFailed.Name, isValidationFailed.Desc);

    //        string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
    //        if (!string.IsNullOrEmpty(htmlTag))
    //        {
    //            subItem.SetValidationFailed.AssetTag_ValidationFailed = htmlTag;
    //            //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
    //            isExistsInDb = false;
    //            isLengthValid = false;
    //        }  
           
    //    }


    //    #region helper methods

       

    //    public static ValidateDataViewModel ValidatatingLength(string subItem, int length, string name, string constName)
    //    {
    //        ValidateDataViewModel _vd = new ValidateDataViewModel();
    //        if (name == constName)
    //        {
    //            if (!string.IsNullOrEmpty(subItem))
    //            {
    //                //int _length = DataAnnotation.GetMaxLengthFromStringLengthAttribute(ExcelViewModel, "AssetTag");
    //                if (subItem.Length > length)
    //                {
    //                    ValidateDataViewModel vd = new ValidateDataViewModel
    //                    {
    //                        Name = constName,
    //                        Desc = string.Format("{0} cannot be longer than {1} characters.", name, length)
    //                    };
    //                    _vd = vd;
    //                }
    //            }
    //        }
    //        return _vd;
    //    }

    //    public static void AddToValidationErrorList(List<ValidateDataViewModel> vdList, ExcelViewModel subItem, ValidateDataViewModel validateData)
    //    {
    //        if (validateData.Name != null)
    //        {
    //            vdList.Add(validateData);
    //            subItem.Validations.Add(validateData);
    //        }
    //    }

    //    public static bool ValidateLengthValue(string name, string desc)
    //    {
    //        if (name != null)
    //        {
    //            if (desc.Contains(Constants.ERROR_LENGTH))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public static string GetHtmlTag(bool isLengthValid, bool isExistsInDb)
    //    {
    //        if (isLengthValid && isExistsInDb)
    //        {
    //            return Constants.ICON_DB_LENGTH;
    //        }
    //        else if (isLengthValid)
    //        {
    //            return Constants.ICON_LENGTH;

    //        }
    //        else if (isExistsInDb)
    //        {
    //            return Constants.ICON_DB;
    //        }
    //        return string.Empty;
    //    }

    //    public static ValidateDataViewModel CheckDBValue(string name, string constName)
    //    {
    //        ValidateDataViewModel _vd = new ValidateDataViewModel();
    //        if (name == constName)
    //        {
    //            ValidateDataViewModel vd = new ValidateDataViewModel
    //            {
    //                Name = constName,
    //                Desc = string.Format("{0} does not exists in the db.", name)
    //            };
    //            _vd = vd;
    //        }
    //        return _vd;
    //    }

    //    public static bool ValidateDbValue(string name, string desc)
    //    {
    //        if (name != null)
    //        {
    //            if (desc.Contains(Constants.ERROR_DB))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    #endregion

    //}
}