using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLP.Portal.MVC.Controllers
{
    public class NoticiaController : BaseController
    {
        private NoticiaRepository _NoticiasRepository = new NoticiaRepository();
        public NoticiaRepository NoticiasRepository
        {
            get { return _NoticiasRepository; }
            set { _NoticiasRepository = value; }
        }
        

        public ActionResult Noticias()
        {
            return View();
        }

        public ActionResult Detalhe(int id)
        {
            return View(this.NoticiasRepository.GetNoticia(id));
        }



    }
}
