using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Adm
{
    public class SoliciteContatoModel
    {
        private sbyte _stObjetivo;

        [Display(Name = "Objetivo do Contato"), Required(ErrorMessage= "Campo Obrigatório!")]
        public sbyte stObjetivo
        {
            get { return _stObjetivo; }
            set { _stObjetivo = value; }
        }

        private string _xMessage;
        [Display(Name = "Mensagem"), Required(ErrorMessage = "Campo Obrigatório!")]
        public string xMessage
        {
            get { return _xMessage; }
            set { _xMessage = value; }
        }

        private string _xTelefone;
        [Display(Name = "Telefone")]
        public string xTelefone
        {
            get { return _xTelefone; }
            set { _xTelefone = value; }
        }

        private string _xCelular;
        [Display(Name = "Celular")]
        public string xCelular
        {
            get { return _xCelular; }
            set { _xCelular = value; }
        }

        private string _xEmail;
        [Display(Name = "Email"), Required(ErrorMessage = "Campo Obrigatório!")]
        public string xEmail
        {
            get { return _xEmail; }
            set { _xEmail = value; }
        }

        private string _xNomeEmpresa;
        [Display(Name = "Nome/Empresa"), Required(ErrorMessage = "Campo Obrigatório!")]
        public string xNomeEmpresa
        {
            get { return _xNomeEmpresa; }
            set { _xNomeEmpresa = value; }
        }

        private sbyte? _stContatoPreferencial;
        [Display(Name = "Qual a preferência para entrarmos em contato com você?")]
        public sbyte? stContatoPreferencial
        {
            get { return _stContatoPreferencial; }
            set { _stContatoPreferencial = value; }
        }

    }
}