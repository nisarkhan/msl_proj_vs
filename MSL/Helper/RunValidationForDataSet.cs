using MSL.Helper.Session;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MSL.Helper
{
    public class RunValidationForDataSet
    {
     
        //Setting a property by reflection with a string value
        //setting/getting the class properties by string name
        public void Run_Validation(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name, bool dbExists)
        {
            bool isLengthValid = false;
            bool isExistsInDb = false;  

            string value = string.Empty;// obj.ToString();

            PropertyInfo propertyInfo = subItem.GetType().GetProperty(name);
            //get the value
            object obj = propertyInfo.GetValue(subItem);//, Convert.ChangeType(value, propertyInfo.PropertyType));
            if (obj != null)
            {
                value = obj.ToString();
            }

            isValidationFailed = AddLengthError(value, _length, name, name);
            AddToValidationErrorList(vdList, subItem, isValidationFailed);

            //chk length
            isLengthValid = IsLengthError(isValidationFailed.Name, isValidationFailed.Desc);


            //chk db            
            if (dbExists)
            {
                isValidationFailed = AddDbError(name, propertyInfo.Name);//Constants.Customer);
                AddToValidationErrorList(vdList, subItem, isValidationFailed);
            }

            isExistsInDb = IsDbError(isValidationFailed.Name, isValidationFailed.Desc);
             

            string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
            if (!string.IsNullOrEmpty(htmlTag))
            {
                ValidationFailedModel vfm = new ValidationFailedModel();  
                //set the value
                PropertyInfo _htmltagValue = vfm.GetType().GetProperty(name + "_ValidationFailed");
                _htmltagValue.SetValue(subItem.SetValidationFailed, Convert.ChangeType(htmlTag, _htmltagValue.PropertyType), null); 

                isExistsInDb = false;
                isLengthValid = false;
            }   
        }

        public void Run_Validation(ValidateDataViewModel isValidationFailed, List<ValidateDataViewModel> vdList, ExcelViewModel subItem, int _length, string name)
        {
            bool isLengthValid = false;
            bool isExistsInDb = false;

            string value = string.Empty;// obj.ToString();

            PropertyInfo propertyInfo = subItem.GetType().GetProperty(name);
            //get the value
            object obj = propertyInfo.GetValue(subItem);//, Convert.ChangeType(value, propertyInfo.PropertyType));
            if (obj != null)
            {
                value = obj.ToString();
            }

            isValidationFailed = AddLengthError(value, _length, name, name);
            AddToValidationErrorList(vdList, subItem, isValidationFailed);

            //chk length
            isLengthValid = IsLengthError(isValidationFailed.Name, isValidationFailed.Desc);


            ////chk db            
            //if (dbExists)
            //{
            //    isValidationFailed = ValidateDBValue(name, Constants.Customer);
            //    AddToValidationErrorList(vdList, subItem, isValidationFailed);
            //}

            isExistsInDb = IsDbError(isValidationFailed.Name, isValidationFailed.Desc);

            //string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
            //if (!string.IsNullOrEmpty(htmlTag))
            //{
            //    subItem.SetValidationFailed.Customer_ValidationFailed = htmlTag;
            //    //HelperUtil.HTML_ICON_DB_LENGTH(errorMsgList.)
            //    isExistsInDb = false;
            //    isLengthValid = false;
            //}


            string htmlTag = GetHtmlTag(isLengthValid, isExistsInDb);
            if (!string.IsNullOrEmpty(htmlTag))
            {
                ValidationFailedModel vfm = new ValidationFailedModel();
                //set the value
                PropertyInfo _htmltagValue = vfm.GetType().GetProperty(name + "_ValidationFailed");
                _htmltagValue.SetValue(subItem.SetValidationFailed, Convert.ChangeType(htmlTag, _htmltagValue.PropertyType), null);

                isExistsInDb = false;
                isLengthValid = false;
            }
        }

      

        #region helper methods

        //private bool ValidateDBValue(string name, string desc)
        //{
        //    if (name != null)
        //    {
        //        if (desc.Contains(Constants.ERROR_DB))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private ValidateDataViewModel AddDbError(string name, string constName)
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

        public static ValidateDataViewModel AddLengthError(string subItem, int length, string name, string constName)
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

        public static void AddToValidationErrorList(List<ValidateDataViewModel> vdList, ExcelViewModel subItem, ValidateDataViewModel validateData)
        {
            if (validateData.Name != null)
            {
                vdList.Add(validateData);
                subItem.Validations.Add(validateData);
            }
        }

        public static bool IsLengthError(string name, string desc)
        {
            if (name != null)
            {
                if (desc.Contains(Constants.ERROR_LENGTH))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetHtmlTag(bool isLengthValid, bool isExistsInDb)
        {
            if (isLengthValid && isExistsInDb)
            {
                return Constants.ICON_DB_LENGTH;
            }
            else if (isLengthValid)
            {
                return Constants.ICON_LENGTH;
            }
            else if (isExistsInDb)
            {
                return Constants.ICON_DB;
            }
            return string.Empty;
        }

        //public static ValidateDataViewModel CheckDBValue(string name, string constName)
        //{
        //    ValidateDataViewModel _vd = new ValidateDataViewModel();
        //    if (name == constName)
        //    {
        //        ValidateDataViewModel vd = new ValidateDataViewModel
        //        {
        //            Name = constName,
        //            Desc = string.Format("{0} does not exists in the db.", name)
        //        };
        //        _vd = vd;
        //    }
        //    return _vd;
        //}

        public static bool IsDbError(string name, string desc)
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

        #endregion
    }

  
}