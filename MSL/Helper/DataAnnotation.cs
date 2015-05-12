using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MSL.Helper
{
    public static class DataAnnotation
    {
        public static int GetMaxLengthFromStringLengthAttribute(Type modelClass, string propertyName)
        {
            int maxLength = 0;
            StringLengthAttribute strLenAttr = modelClass.GetProperty(propertyName).GetCustomAttributes(typeof(StringLengthAttribute), false).Cast<StringLengthAttribute>().SingleOrDefault();

            if (strLenAttr != null)
            {
                maxLength = strLenAttr.MaximumLength;
            }
            return maxLength;
        }
    }
}