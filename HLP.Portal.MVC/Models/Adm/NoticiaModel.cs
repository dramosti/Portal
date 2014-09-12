using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Adm
{
    public sealed class NoticiaModel
    {
        public int idNoticias { get; set; }

        public string xTitulo { get; set; }

        public string xNoticia { get; set; }

        public DateTime dtNoticia { get; set; }

        public bool stCarrocel { get; set; }

        public bool stDestaque { get; set; }

        public List<ImagemModel> Imagens { get; set; }
    }
}