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
    
    public partial class tb_noticias
    {
        public int idNoticias { get; set; }
        public string xTitulo { get; set; }
        public string xNoticia { get; set; }
        public System.DateTime dtNoticia { get; set; }
        public bool stCarrocel { get; set; }
        public bool stDestaque { get; set; }
        public int idUsuario { get; set; }
    
        public virtual tb_usuario tb_usuario { get; set; }
    }
}
