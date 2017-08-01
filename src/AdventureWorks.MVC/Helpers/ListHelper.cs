using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AdventureWorks.MVC.Helpers
{
    public static class ListHelper
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> objs, List<KeyValuePair<string, StringValues>> filters)
        {
            filters.ForEach(f =>
            {
                if (objs.ElementType.GetProperties().Where(p => p.Name == ObjectHelper.GetPropertyNameByType(f.Key, objs.ElementType)).FirstOrDefault() != null)
                {
                    objs= objs.ApplySearch(f.Value, ObjectHelper.GetPropertyByType(f.Key, objs.ElementType));
                }
            });

            return objs;
        }
    }
}
