using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLP.Portal.MVC.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        NoticiaRepository noticiaRep = new NoticiaRepository();

        public ActionResult Home()
        {
            base.SessionHomeModel = new HomeModel();
            base.SessionHomeModel.CarrosselNoticias = noticiaRep.GetNoticiaCarrossel();
            base.SessionHomeModel.DestaqueNoticias = noticiaRep.GetNoticiaDestaque();


            return View(model: base.SessionHomeModel);
        }

    }
}
