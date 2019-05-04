﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NogginBug.MvcSite.ViewModels;

namespace NogginBug.MvcSite.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
