using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Adm
{
    public sealed class ImagemModel
    {
        public int idImagem { get; set; }

        public string xUrlImg { get; set; }

        public string xComentario { get; set; }

        public bool stPrincipal { get; set; }


    }
}