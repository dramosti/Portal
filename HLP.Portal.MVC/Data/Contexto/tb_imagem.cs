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
    
    public partial class tb_imagem
    {
        public int idImagem { get; set; }
        public string xUrlImg { get; set; }
        public string xComentario { get; set; }
        public bool stPrincipal { get; set; }
        public Nullable<int> idNoticias { get; set; }
        public Nullable<int> idModulo { get; set; }
        public Nullable<int> idSistema { get; set; }
    
        public virtual tb_modulo tb_modulo { get; set; }
        public virtual tb_sistema tb_sistema { get; set; }
    }
}
