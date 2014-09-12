using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Portal.MVC.Models.Adm
{
    public class ClienteModel
    {
        public int idCliente { get; set; }

        public string xRazao { get; set; }

        public string xFantasia { get; set; }

        public string xUrlImg { get; set; }

        public bool stClienteEspecial { get; set; }
    }
}
