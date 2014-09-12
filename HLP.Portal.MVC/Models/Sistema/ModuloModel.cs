using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Models.Sistema
{
    public class ModuloModel
    {
        public ModuloModel()
        {
            this.lModuloItens = new List<Modulo_ItemModel>();
        }

        private List<Modulo_ItemModel> _lModuloItens;

        public List<Modulo_ItemModel> lModuloItens
        {
            get { return _lModuloItens; }
            set { _lModuloItens = value; }
        }


        private int? _idModulo;

        public int? idModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }


        private string _xTitulo;

        public string xTitulo
        {
            get { return _xTitulo; }
            set { _xTitulo = value; }
        }

    }

    public class Modulo_ItemModel
    {
        public Modulo_ItemModel()
        {

        }

        private int? _idModulo;

        public int? idModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }


        private int? _idModuloItem;

        public int? idModuloItem
        {
            get { return _idModuloItem; }
            set { _idModuloItem = value; }
        }

        private string _xDescricao;

        public string xDescricao
        {
            get { return _xDescricao; }
            set { _xDescricao = value; }
        }
    }
}