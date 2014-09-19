using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLP.Portal.MVC.Models
{
    public class BaseController : Controller
    {
        public HomeModel SessionHomeModel
        {
            get { return Session["home"] != null ? Session["home"] as HomeModel : new HomeModel(); }
            set { Session.Add("home", value); }
        }

       
    }
}