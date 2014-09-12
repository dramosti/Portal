using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Portal.MVC.Models.Registration
{
    public class UserModel
    {
        public UserModel()
        {
        }
        public int idUsuario { get; set; }

        [Display(Name = "Nome completo: ")]
        public string xNome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(45)]
        [Display(Name = "Endereço de e-mail: ")]
        public string xEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(45, MinimumLength = 6)]
        [Display(Name = "Senha: ")]
        public string xSenha { get; set; }

        public string idFaceBook { get; set; }

        [Display(Name = "Lembre-me")]
        public bool bRemember { get; set; }

        public ClienteModel cliente { get; set; }
    }
}
