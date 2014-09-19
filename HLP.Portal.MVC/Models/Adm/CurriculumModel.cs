using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Adm
{
    public class CurriculumModel
    {
        public CurriculumModel()
        {
        }

        private int _idCurriculumVitae;

        public int idCurriculumVitae
        {
            get { return _idCurriculumVitae; }
            set { _idCurriculumVitae = value; }
        }

        private string _xNome;

        [Display(Name = "Nome")]
        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; }
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
        [Display(Name = "Email")]
        public string xEmail
        {
            get { return _xEmail; }
            set { _xEmail = value; }
        }

        private string _xEndereco;
        [Display(Name = "Endereço")]
        public string xEndereco
        {
            get { return _xEndereco; }
            set { _xEndereco = value; }
        }

        private string _xBairro;
        [Display(Name = "Bairro")]
        public string xBairro
        {
            get { return _xBairro; }
            set { _xBairro = value; }
        }

        private string _xCidade;
        [Display(Name = "Cidade")]
        public string xCidade
        {
            get { return _xCidade; }
            set { _xCidade = value; }
        }

        private string _xEstado;
        [Display(Name = "Estado")]
        public string xEstado
        {
            get { return _xEstado; }
            set { _xEstado = value; }
        }

        private string _xSobreMim;
        [Display(Name = "Sobre")]
        public string xSobreMim
        {
            get { return _xSobreMim; }
            set { _xSobreMim = value; }
        }

        private string _xExperiencia;
        [Display(Name = "Experiência")]
        public string xExperiencia
        {
            get { return _xExperiencia; }
            set { _xExperiencia = value; }
        }

        private string _xFormacao;
        [Display(Name = "Formação")]
        public string xFormacao
        {
            get { return _xFormacao; }
            set { _xFormacao = value; }
        }

        private string _xAtividadesComplementares;
        [Display(Name = "Atividades Complementares")]
        public string xAtividadesComplementares
        {
            get { return _xAtividadesComplementares; }
            set { _xAtividadesComplementares = value; }
        }

        private string _xCompetencias;
        [Display(Name = "Competências")]
        public string xCompetencias
        {
            get { return _xCompetencias; }
            set { _xCompetencias = value; }
        }

        private string _xObjetivo;
        [Display(Name = "Objetivo")]
        public string xObjetivo
        {
            get { return _xObjetivo; }
            set { _xObjetivo = value; }
        }

        private string _xInformacoesComplementares;
        [Display(Name = "Informações Complementares")]
        public string xInformacoesComplementares
        {
            get { return _xInformacoesComplementares; }
            set { _xInformacoesComplementares = value; }
        }

        private int? _idUsuario;

        public int? idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        
    }
}