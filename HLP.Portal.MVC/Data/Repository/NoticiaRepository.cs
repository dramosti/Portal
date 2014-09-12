using HLP.Portal.MVC.Data.Contexto;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Data.Repository
{
    public class NoticiaRepository
    {

        public List<NoticiaModel> GetNoticiaCarrossel()
        {
            try
            {
                var Noticias = new List<NoticiaModel>();
                ImagemRepository imagemRep = new ImagemRepository();
                using (var db = new PortalEntities())
                {
                    var dados = db.tb_noticias.Where(c => c.stCarrocel).ToList();

                    dados.ForEach((c) =>
                    {
                        var noticia = new NoticiaModel
                        {
                            idNoticias = c.idNoticias,
                            dtNoticia = c.dtNoticia,
                            stCarrocel = c.stCarrocel,
                            stDestaque = c.stDestaque,
                            xNoticia = c.xNoticia,
                            xTitulo = c.xTitulo
                        };
                        noticia.Imagens = imagemRep.GetImagens(noticia.idNoticias, ImagemRepository.tabela.TB_NOTICIA);
                        if (noticia.Imagens.Count() > 0)
                            Noticias.Add(noticia);
                    });
                }
                return Noticias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}