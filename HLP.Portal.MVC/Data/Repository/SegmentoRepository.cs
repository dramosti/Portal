using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HLP.Portal.MVC.Models.Sistema;
using HLP.Portal.MVC.Data.Contexto;

namespace HLP.Portal.MVC.Data.Repository
{
    public class SegmentoRepository
    {
        public SegmentoRepository()
        {

        }

        public SegmentoModel GetSegmento(int idSegmento)
        {
            SegmentoModel objSegmento = null;
            using (var con = new PortalEntities())
            {
                tb_segmento objDbSegmento = con.tb_segmento.FirstOrDefault(i => i.idSegmento == idSegmento);

                if (objDbSegmento != null)
                    objSegmento = new SegmentoModel
                    {
                        idSegmento = objDbSegmento.idSegmento,
                        xConteudoCompleto = objDbSegmento.xConteudoCompleto,
                        xConteudoDiferencial = objDbSegmento.xConteudoDiferencial,
                        xConteudoHome = objDbSegmento.xConteudoHome,
                        xTituloCompleto = objDbSegmento.xTituloCompleto,
                        xTituloDiferencial = objDbSegmento.xTituloDiferencial,
                        xTituloHome = objDbSegmento.xTituloHome
                    };
            }

            return objSegmento;
        }
    }
}