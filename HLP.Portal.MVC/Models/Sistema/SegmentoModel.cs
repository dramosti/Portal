using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Sistema
{
    public class SegmentoModel
    {
        public SegmentoModel()
        {
            this.lModulos = new List<ModuloModel>();
            this.lImagens = new List<ImagemModel>();
        }

        private List<ModuloModel> _lModulos;

        public List<ModuloModel> lModulos
        {
            get { return _lModulos; }
            set { _lModulos = value; }
        }

        private List<ImagemModel> _lImagens;

        public List<ImagemModel> lImagens
        {
            get { return _lImagens; }
            set { _lImagens = value; }
        }


        private int? _idSegmento;

        public int? idSegmento
        {
            get { return _idSegmento; }
            set { _idSegmento = value; }
        }

        private string _xTituloHome;

        public string xTituloHome
        {
            get { return _xTituloHome; }
            set { _xTituloHome = value; }
        }

        private string _xConteudoHome;

        public string xConteudoHome
        {
            get { return _xConteudoHome; }
            set { _xConteudoHome = value; }
        }

        private string _xTituloCompleto;

        public string xTituloCompleto
        {
            get { return _xTituloCompleto; }
            set { _xTituloCompleto = value; }
        }

        private string _xConteudoCompleto;

        public string xConteudoCompleto
        {
            get { return _xConteudoCompleto; }
            set { _xConteudoCompleto = value; }
        }

        private string _xTituloDiferencial;

        public string xTituloDiferencial
        {
            get { return _xTituloDiferencial; }
            set { _xTituloDiferencial = value; }
        }

        private string _xConteudoDiferencial;

        public string xConteudoDiferencial
        {
            get { return _xConteudoDiferencial; }
            set { _xConteudoDiferencial = value; }
        }

    }
}