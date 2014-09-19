using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Adm
{
    public class HomeModel
    {
        public HomeModel() 
        {
            CarrosselNoticias = new List<NoticiaModel>();
            DestaqueNoticias = new List<NoticiaModel>();
        }

        public List<NoticiaModel> CarrosselNoticias { get; set; }

        public List<NoticiaModel> DestaqueNoticias { get; set; }

    }
}