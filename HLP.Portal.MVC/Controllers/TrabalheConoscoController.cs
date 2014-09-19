using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;
using System.Text;
using HLP.EMAIL;
using System.Web.Security;

namespace HLP.Portal.MVC.Controllers
{
    public class TrabalheConoscoController : Controller
    {
        public ActionResult Formulario()
        {
            if (Request.IsAuthenticated)
            {
                TrabalheConoscoRepository rep = new TrabalheConoscoRepository();

                return View(model: rep.GetCurriculumByEmail(xEmail: User.Identity.Name));
            }

            return View();
        }

        [HttpPost]
        public ActionResult Formulario(CurriculumModel objCurriculum)
        {
            TrabalheConoscoRepository rep = new TrabalheConoscoRepository();
            string emailFrom = System.Configuration.ConfigurationManager.AppSettings[name: "emailGuest"];
            string emailTo = System.Configuration.ConfigurationManager.AppSettings[name: "email"];
            string passwordEmailFrom = System.Configuration.ConfigurationManager.AppSettings[name: "senhaEmailGuest"];

            if (rep.Save(objCurriculum: objCurriculum))
            {
                TempData["Sucesso"] = "Curriculum cadastrado com sucesso!";

                if (!string.IsNullOrEmpty(value: emailFrom) && !string.IsNullOrEmpty(value: emailTo)
                    && !string.IsNullOrEmpty(value: passwordEmailFrom))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(value: objCurriculum.xNome + " enviou um curriculum");
                    sb.AppendLine();
                    sb.Append(value: "Id curriculum: " + objCurriculum.idCurriculumVitae);

                    HlpEmail email = new HlpEmail(_objSettings: new SettingsEmail
                    {
                        enableSsl = false,
                        host = "smtp.hlp.com.br",
                        nPort = 587
                    });

                    email.SendEmail(mailFrom: emailFrom, mailTo: emailTo, xSubject: "Curriculum recebido!", xBody: sb.ToString(), xPassword: passwordEmailFrom);
                }

                return RedirectToAction("Home", "Home");
            }

            return View();
        }
    }
}
