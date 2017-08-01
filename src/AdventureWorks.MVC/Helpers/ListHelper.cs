using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AdventureWorks.MVC.Helpers
{
    public class ListHelper
    {
        public static IQueryable<T> ApplyFilters<T>(IQueryable<T> objs, List<KeyValuePair<string, StringValues>> filters)
        {
            filters.ForEach(f =>
            {
                if (objs.ElementType.GetProperties().Where(p => p.Name == ObjectHelper.GetPropertyByType(f.Key, objs.ElementType)).FirstOrDefault() != null)
                {
                    objs = objs.Where(o => Convert.ToString(ObjectHelper.GetPropertyValueByName(f.Key, o)).Contains(Convert.ToString(f.Value)));
                }
            });

            return objs;
        }
    }
}
