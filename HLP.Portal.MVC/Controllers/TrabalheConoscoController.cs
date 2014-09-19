using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;

namespace HLP.Portal.MVC.Controllers
{
    public class TrabalheConoscoController : Controller
    {
        public ActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Formulario(CurriculumModel objCurriculum)
        {
            TrabalheConoscoRepository rep = new TrabalheConoscoRepository();

            if(rep.Save(objCurriculum: objCurriculum))
            {
                TempData["Sucesso"] = "Curriculum cadastrado com sucesso!";
                return RedirectToAction("Home", "Home");
            }

            return View();
        }
    }
}
