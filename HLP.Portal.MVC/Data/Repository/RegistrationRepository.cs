using HLP.Portal.MVC.Data.Contexto;
using HLP.Portal.MVC.Models.Registration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Data.Repository
{
    public sealed class RegistrationRepository
    {
        public bool IsValid(string xEmail, string xSenha)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;
            using (var db = new PortalEntities())
            {
                var user = db.tb_usuario.FirstOrDefault(x => x.xEmail == xEmail);
                if (user != null)
                {
                    string sResult = crypto.Compute(xSenha, user.xSenhaSalt);
                    if (user.xSenha == sResult)
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        public bool Save(UserModel user)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encrypPass = crypto.Compute(user.xSenha);

                using (var db = new PortalEntities())
                {
                    tb_usuario u = new tb_usuario();
                    u.xEmail = user.xEmail;
                    u.xNome = user.xNome;
                    u.xSenha = encrypPass;
                    u.xSenhaSalt = crypto.Salt;
                    if (user.cliente != null)
                        u.idCliente = user.cliente.idCliente;
                    db.tb_usuario.Add(u);
                    db.SaveChanges();
                }
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