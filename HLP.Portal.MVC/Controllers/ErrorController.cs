﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLP.Portal.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult GenericError(HandleErrorInfo exception)
        {
            return View("Error", exception);
        }

        public ViewResult NotFound(HandleErrorInfo exception)
        {
            ViewBag.Title = "Page Not Found";
            return View("Error", exception);
        }
    }
}
