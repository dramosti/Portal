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
            this.providers = new List<ProvidersModel>();
        }
        public int? idUsuario { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [Display(Name = "Nome completo: ")]
        public string xFullName { get; set; }

        /// <summary>
        /// username
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(45)]
        [Display(Name = "Endereço de e-mail: ")]
        public string xUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(45, MinimumLength = 6)]
        [Display(Name = "Senha: ")]
        public string xSenha { get; set; }

        [Display(Name = "Lembre-me")]
        public bool bRemember { get; set; }

        public List<ProvidersModel> providers { get; set; }

    }
  
}
