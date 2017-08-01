using System.Reflection;

namespace AdventureWorks.MVC.Helpers
{
    public class ObjectHelper
    {
        public static object GetPropertyByName(string prop, object obj)
        {
            return obj.GetType().GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(obj, null);
        }
    }
}
