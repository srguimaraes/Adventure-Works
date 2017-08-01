using System;
using System.Reflection;

namespace AdventureWorks.MVC.Helpers
{
    public class ObjectHelper
    {
        public static object GetPropertyValueByName(string prop, object obj)
        {
            var property = obj.GetType().GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return property.GetValue(obj, null);
        }
        public static string GetPropertyByType(string prop, Type type)
        {
            var property = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return property?.Name;
        }        
    }
}
