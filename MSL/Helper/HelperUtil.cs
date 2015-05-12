using AutoMapper;
using MSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MSL.Helper
{
    public static class HelperUtil
    {
        public static string HTML_ICON_DB_LENGTH(string titleDB, string titleLength)
        {
            return string.Format("<span class=\"fa fa-database redcolor\" title=\"{0}\"</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=\"fa fa-chain-broken redcolor\" title=\"{1}\"</span>", titleDB, titleLength);
        }

        public static string HTML_ICON_DB(string titleDB)
        {
            return string.Format("<span class=\"fa fa-database redcolor\" title=\"{0}\"</span>", titleDB);
        }

        public static string HTML_ICON_LENGTH(string titleLength)
        {
            return string.Format("<span class=\"fa fa-chain-broken redcolor\" title=\"{0}\"</span>", titleLength);
        }

        public static object GetPropValue(object src, string propName)
        {
            object obj = src.GetType().GetProperty(propName);//.GetValue(src);
            if (obj != null)
            {
                return src.GetType().GetProperty(propName).GetValue(src);
            }
            return null;
        }

        public static void SetPropertyValue(object obj, string propName, object value, object newModel)
        {
            //obj.GetType().GetProperty(propName).SetValue(obj, value, null);
            object newObj = newModel.GetType().GetProperty(propName);//.SetValue(newModel, value, null);
            if (newObj != null)
            {
                newModel.GetType().GetProperty(propName).SetValue(newModel, value, null);
            }
        }

        public static void SetPropertyValue(object obj, string propName, object value)
        {
            //obj.GetType().GetProperty(propName).SetValue(obj, value, null);
            object newObj = obj.GetType().GetProperty(propName);//.SetValue(newModel, value, null);
            if (newObj != null)
            {
                obj.GetType().GetProperty(propName).SetValue(obj, value, null);
            }
        }
        public static void CopyIfDifferent(Object db, Object excel, Object newModel)
        {
            foreach (var prop in excel.GetType().GetProperties())
            {
                string[] stringArray = { "ValidationFailed", "ValidationPassed", "SetValidationFailed", "Validations", "IsValidationError", "RowNumber", "SelectedRowId" };

                int pos = Array.IndexOf(stringArray, prop.Name);
                if (pos > -1)
                {
                    // the array contains the string and the pos variable
                    // will have its position in the array
                }
                else
                {
                    var dbValue = GetPropValue(db, prop.Name);
                    var excelValue = GetPropValue(excel, prop.Name);
                    if (!dbValue.Equals(excelValue))
                    {
                        SetPropertyValue(db, prop.Name, excelValue, newModel);
                    }
                }
            }
        }

        public static void CopyIfDifferent(Object db, Object excel)
        {
            foreach (var prop in excel.GetType().GetProperties())
            {
                string[] stringArray = { "ValidationFailed", "ValidationPassed", "SetValidationFailed", "Validations", "IsValidationError", "RowNumber", "SelectedRowId" };

                int pos = Array.IndexOf(stringArray, prop.Name);
                if (pos > -1)
                {
                    // the array contains the string and the pos variable
                    // will have its position in the array
                }
                else
                {
                    var dbValue = GetPropValue(db, prop.Name);
                    var excelValue = GetPropValue(excel, prop.Name);
                    if (!dbValue.Equals(excelValue))
                    {
                        SetPropertyValue(db, prop.Name, excelValue);
                    }
                }
            }
        }

        public static  bool IsAnyNullOrEmpty(object myObject)
        {
            bool isnullempty = false;
            bool isnotnullempty = false;
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.Name != "id")
                {
                    string value = (string)pi.GetValue(myObject);
                    if (String.IsNullOrEmpty(value))
                    {
                        isnullempty = false;
                    }
                    else
                    {
                        isnotnullempty = true;
                    }
                }
            }
            if (isnotnullempty)
            {
                return isnotnullempty;
            }

            return isnullempty;
        }

    }
}