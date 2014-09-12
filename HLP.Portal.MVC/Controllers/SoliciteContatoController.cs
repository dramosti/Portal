using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLP.Portal.MVC.Controllers
{
    public class SoliciteContatoController : Controller
    {
        //
        // GET: /SoliciteContato/

        public ActionResult Solicitar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Solicitar(SoliciteContatoModel obj)
        {
            SoliciteContatoRepository rep = new SoliciteContatoRepository();

            rep.Save(obj: obj);

            return View();
        }
    }
}
