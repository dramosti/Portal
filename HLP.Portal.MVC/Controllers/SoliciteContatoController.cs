using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;
using HLP.EMAIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string emailFrom = System.Configuration.ConfigurationManager.AppSettings[name: "emailGuest"];
            string emailTo = System.Configuration.ConfigurationManager.AppSettings[name: "email"];

            if (rep.Save(obj: obj))
            {
                TempData["Sucesso"] = "Solicitação Inserida com sucesso!";


                if (emailFrom != null && emailTo != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(value: obj.xNomeEmpresa + " solicitou contato");
                    sb.AppendLine();
                    sb.Append(value: "Id solicitação: " + obj.idSolicitacao);

                    HlpEmail email = new HlpEmail(_objSettings: new SettingsEmail
                        {
                            enableSsl = false,
                            host = "smtp.hlp.com.br",
                            nPort = 587
                        });

                    email.SendEmail(mailFrom: emailFrom, mailTo: emailTo, xSubject: "Aviso de Solicitação!", xBody: sb.ToString(), xPassword: "Uti1992yama");
                }

                return RedirectToAction("Home", "Home");
            }

            return View();
        }
    }
}
