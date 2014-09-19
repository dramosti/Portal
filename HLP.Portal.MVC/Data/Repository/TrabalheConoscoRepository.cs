using HLP.Portal.MVC.Data.Contexto;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Data.Repository
{
    public class TrabalheConoscoRepository
    {
        public TrabalheConoscoRepository()
        {

        }

        public bool Save(CurriculumModel objCurriculum)
        {
            using (var con = new PortalEntities())
            {
                tb_curriculum objDbCurriculum = new tb_curriculum
                        {
                            idUsuario = objCurriculum.idUsuario,
                            xAtividadesComplementares = objCurriculum.xAtividadesComplementares,
                            xBairro = objCurriculum.xBairro,
                            xCelular = objCurriculum.xCelular,
                            xCidade = objCurriculum.xCidade,
                            xCompetencias = objCurriculum.xCompetencias,
                            xEmail = objCurriculum.xEmail,
                            xEndereco = objCurriculum.xEndereco,
                            xEstado = objCurriculum.xEstado,
                            xExperiencia = objCurriculum.xExperiencia,
                            xFormacao = objCurriculum.xFormacao,
                            xInformacoesComplementares = objCurriculum.xInformacoesComplementares,
                            xNome = objCurriculum.xNome,
                            xObjetivo = objCurriculum.xObjetivo,
                            xSobreMim = objCurriculum.xSobreMim,
                            xTelefone = objCurriculum.xTelefone
                        };

                if (objCurriculum.idCurriculumVitae == 0)
                {
                    con.tb_curriculum.Add(entity: objDbCurriculum);
                }
                else
                {
                    con.tb_curriculum.Attach(entity: objDbCurriculum);
                    con.Entry(entity: objDbCurriculum).State = System.Data.EntityState.Modified;
                }
                try
                {
                    con.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}