//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Portal.MVC.Data.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_sistema
    {
        public tb_sistema()
        {
            this.tb_imagem = new HashSet<tb_imagem>();
        }
    
        public int idSistema { get; set; }
        public string xNome { get; set; }
        public string xTitulo { get; set; }
        public string xConteudo { get; set; }
    
        public virtual ICollection<tb_imagem> tb_imagem { get; set; }
    }
}