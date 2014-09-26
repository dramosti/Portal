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
        public bool IsExist(string xUserName, string xSenha)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();
                bool IsValid = false;
                using (var db = new PortalEntities())
                {
                    var user = db.tb_usuario.FirstOrDefault(x => x.xUserName == xUserName);
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
            catch (Exception)
            {
                return false;
            }
           
        }

        /// <summary>
        /// Redes sociais
        /// </summary>
        /// <param name="xEmail"></param>
        /// <param name="xSenha"></param>
        /// <returns></returns>
        public bool IsExist(string xUserName)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;
            using (var db = new PortalEntities())
            {
                var user = db.tb_usuario.FirstOrDefault(x => x.xUserName == xUserName);
                if (user != null)
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }


        public UserModel GetUser(string xUserName)
        {
            try
            {
                UserModel user = null;

                using (var db = new PortalEntities())
                {
                    var dados = db.tb_usuario.FirstOrDefault(c => c.xUserName == xUserName);
                    if (dados != null)
                    {
                        user = new UserModel
                        {
                            idUsuario = dados.idUsuario,
                            xFullName = dados.xFullName,
                            xSenha = dados.xSenha,
                            xUserName = dados.xUserName
                        };
                        if (dados.tb_providers.Count() > 0)
                        {
                            dados.tb_providers.ToList().ForEach((c) =>
                            {
                                user.providers.Add(new ProvidersModel
                                {
                                    idUsuario = Convert.ToInt32(c.idUsuario),
                                    Provider = c.Provider,
                                    ProviderUserId = c.ProviderUserId
                                });
                            });
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Save(UserModel user)
        {
            try
            {
                using (var db = new PortalEntities())
                {
                    tb_usuario u = new tb_usuario();
                    if (user.idUsuario == null)
                    {
                        SetPassword(user, u);
                        u.xUserName = user.xUserName;
                        u.xFullName = user.xFullName;
                        db.tb_usuario.Add(u);

                        foreach (var prov in user.providers)
                        {
                            u.tb_providers.Add(new tb_providers
                            {
                                idUsuario = u.idUsuario,
                                Provider = prov.Provider,
                                ProviderUserId = prov.ProviderUserId
                            });
                        }

                    }
                    else
                    {
                        u = db.tb_usuario.FirstOrDefault(c => c.xUserName == user.xUserName);
                        SetPassword(user, u);
                        u.xUserName = user.xUserName;
                        u.xFullName = user.xFullName;

                        foreach (var prov in user.providers)
                        {
                            tb_providers provider = null;
                            if (u.tb_providers.Where(c => c.ProviderUserId == prov.ProviderUserId).Count() > 0)
                            {
                                provider = u.tb_providers.FirstOrDefault(c => c.ProviderUserId == prov.ProviderUserId);
                                provider.ProviderUserId = prov.ProviderUserId;
                                provider.Provider = prov.Provider;
                                provider.idUsuario = prov.idUsuario;
                            }
                            else
                            {
                                provider = new tb_providers();
                                provider.ProviderUserId = prov.ProviderUserId;
                                provider.Provider = prov.Provider;
                                provider.idUsuario = prov.idUsuario;
                                u.tb_providers.Add(provider);
                            }
                        }
                    }
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

        private static void SetPassword(UserModel user, tb_usuario u)
        {
            if (user.xSenha != null)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encrypPass = crypto.Compute(user.xSenha);
                u.xSenha = encrypPass;
                u.xSenhaSalt = crypto.Salt;
            }
        }
    }
}