﻿using System.Web;
using System.Web.Mvc;

namespace MVCWebApplication22
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(System.IndexOutOfRangeException), View = "_IndexOutOfRangeExceptionView" });
        }
    }
}
