using HLP.Portal.MVC.Data.Contexto;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Data.Repository
{
    public class ImagemRepository
    {

        public enum tabela { TB_NOTICIA, TB_SEGMENTO };
        public List<ImagemModel> GetImagens(int id, tabela tb)
        {
            try
            {
                var imagens = new List<ImagemModel>();
                using (var db = new PortalEntities())
                {
                    List<tb_imagem> dados = null;
                    switch (tb)
                    {
                        case tabela.TB_NOTICIA:
                            dados = db.tb_imagem.Where(c => c.idNoticias == id).ToList();
                            break;
                        case tabela.TB_SEGMENTO:
                            dados = db.tb_imagem.Where(c => c.idSegmento == id).ToList();
                            break;
                        default:
                            break;
                    }

                    dados.ForEach((c) =>
                        {
                            imagens.Add(new ImagemModel
                            {
                                idImagem = c.idImagem,
                                stPrincipal = c.stPrincipal,
                                xComentario = c.xComentario,
                                xUrlImg = c.xUrlImg
                            });
                        });
                }
                return imagens;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}