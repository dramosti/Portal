using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLP.Portal.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        NoticiaRepository noticiaRep = new NoticiaRepository();

        public ActionResult Home()
        {
            HomeModel home = new HomeModel();
            home.CarrosselNoticias = noticiaRep.GetNoticiaCarrossel();

            return View(model: home);
        }

    }
}
