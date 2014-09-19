using HLP.Portal.MVC.Data.Contexto;
using HLP.Portal.MVC.Models.Adm;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Data.Repository
{
    public class SoliciteContatoRepository
    {
        public SoliciteContatoRepository()
        {

        }

        public bool Save(SoliciteContatoModel obj)
        {
            using (var con = new PortalEntities())
            {
                tb_solicitecontato objTbSolicitacao = new tb_solicitecontato
                    {
                        stObjetivo = obj.stObjetivo,
                        xCelular = obj.xCelular,
                        xEmail = obj.xEmail,
                        xMessage = obj.xMessage,
                        xTelefone = obj.xTelefone,
                        xNomeEmpresa = obj.xNomeEmpresa,
                        stContatoPreferencial = obj.stContatoPreferencial
                    };

                con.tb_solicitecontato.Add(entity:
                    objTbSolicitacao);

                try
                {
                    con.SaveChanges();
                    obj.idSolicitacao = objTbSolicitacao.idSoliciteContato;
                    return true;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
    }
}