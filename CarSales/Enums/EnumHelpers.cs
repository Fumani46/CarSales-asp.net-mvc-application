using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CarSales.Enums
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Display the name set in annotation DisplayName on top of enum value
        /// </summary>
        /// <param name="value">Enum Value</param>
        /// <returns>String Display Enum value</returns>
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
    }
}
