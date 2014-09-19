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

        public CurriculumModel GetCurriculumByEmail(string xEmail)
        {
            using (var con = new PortalEntities())
            {
                tb_curriculum objCurrDb = con.tb_curriculum.FirstOrDefault(i => i.xEmail == xEmail);

                if (objCurrDb != null)
                {
                    return new CurriculumModel
                    {
                        idCurriculumVitae = objCurrDb.idCurriculumVitae,
                        idUsuario = objCurrDb.idUsuario,
                        xAtividadesComplementares = objCurrDb.xAtividadesComplementares,
                        xBairro = objCurrDb.xBairro,
                        xCelular = objCurrDb.xCelular,
                        xCidade = objCurrDb.xCidade,
                        xCompetencias = objCurrDb.xCompetencias,
                        xEmail = objCurrDb.xEmail,
                        xEndereco = objCurrDb.xEndereco,
                        xEstado = objCurrDb.xEstado,
                        xExperiencia = objCurrDb.xExperiencia,
                        xFormacao = objCurrDb.xFormacao,
                        xInformacoesComplementares = objCurrDb.xInformacoesComplementares,
                        xNome = objCurrDb.xNome,
                        xObjetivo = objCurrDb.xObjetivo,
                        xSobreMim = objCurrDb.xSobreMim,
                        xTelefone = objCurrDb.xTelefone
                    };
                }

                return new CurriculumModel();
            }
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
                    objCurriculum.idCurriculumVitae = objDbCurriculum.idCurriculumVitae;
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