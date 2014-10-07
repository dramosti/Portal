using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models;
using HLP.Portal.MVC.Models.Adm;
using HLP.Portal.MVC.Models.Registration;
using HLP.Portal.MVC.Util;
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

        public HomeController()
        {
            Log.xPath = @"C:\logPortal";
        }

        NoticiaRepository noticiaRep = new NoticiaRepository();

        public ActionResult Home()
        {           
            try
            {
                var getUser = this.SessionUserModel;
                base.SessionHomeModel = new HomeModel();
                base.SessionHomeModel.CarrosselNoticias = noticiaRep.GetNoticiaCarrossel();
                base.SessionHomeModel.DestaqueNoticias = noticiaRep.GetNoticiaDestaque();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }

            return View(model: base.SessionHomeModel);
        }

    }
}
