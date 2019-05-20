using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Code_Project.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this List<T> list, string valueProp, string textProp) where T : class
        {
            foreach (var item in list)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = typeof(T).GetProperty(valueProp).GetValue(item).ToString(),
                    Text = typeof(T).GetProperty(textProp).GetValue(item).ToString()
                };
                yield return selectListItem;
            }
        }
    }
}