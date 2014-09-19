using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace HLP.Portal.MVC.Controllers
{
    public class NoticiaController : BaseController
    {
        private NoticiaRepository _NoticiasRepository = new NoticiaRepository();
        public NoticiaRepository noticiasRepository
        {
            get { return _NoticiasRepository; }
            set { _NoticiasRepository = value; }
        }

        public ActionResult Noticias(int? page)
        {
            return View(noticiasRepository.GetAll().ToPagedList(pageNumber: page ?? 1, pageSize: 10));
        }

        public ActionResult Detalhe(int id)
        {
            return View(this.noticiasRepository.GetNoticia(id));
        }



    }
}
