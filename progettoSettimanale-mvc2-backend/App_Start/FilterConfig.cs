﻿using System.Web;
using System.Web.Mvc;

namespace progettoSettimanale_mvc2_backend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
