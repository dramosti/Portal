using DotNetOpenAuth.AspNet;
using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Registration;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HLP.Portal.MVC.Controllers
{
    public class UserController : BaseController
    {
        RegistrationRepository repository = new RegistrationRepository();


        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            try
            {
                if (repository.IsExist(xUserName: user.xUserName, xSenha: user.xSenha))
                {
                    this.SessionUserModel = repository.GetUser(user.xUserName);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Detalhes do login estão errados.");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult Register()
        {
            return View(new UserModel());
        }


        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (repository.Save(user: user))
                {
                    this.SessionUserModel = repository.GetUser(user.xUserName);
                    return RedirectToAction("Home", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Data is not correct");
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            this.SessionUserModel = null;
            return RedirectToAction(actionName: "Home", controllerName: "Home");
        }


        public ActionResult Recovery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recovery(UserModel user)
        {
            return View();
        }


        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                this.aviso = "Ocorreu um erro ao utilizar o login externo.";
            }
            UserModel user = null;
            if (!User.Identity.IsAuthenticated)
            {
                //user.xUserName = result.ExtraData.FirstOrDefault(x => x.Key == "username").Value;
                //user.idSocial = result.ExtraData.FirstOrDefault(x => x.Key == "id").Value;
                //user.ExternalLoginData = loginData;

                string xFullName = result.ExtraData.FirstOrDefault(x => x.Key == "name").Value;
                string userName = result.ExtraData.FirstOrDefault(x => x.Key == "username").Value;
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                string provider = null;
                string providerUserId = null;

                if (OAuthWebSecurity.TryDeserializeProviderUserId(loginData, out provider, out providerUserId))
                {
                    if (providerUserId == result.ProviderUserId)
                    {
                        if (repository.IsExist(xUserName: userName))
                        {
                            user = repository.GetUser(xUserName: userName);
                            if (user != null)
                            {
                                if (user.providers.Where(c => c.Provider == provider && c.ProviderUserId == providerUserId).Count() == 0)
                                {
                                    user.providers.Add(new ProvidersModel
                                    {
                                        idUsuario = Convert.ToInt32(user.idUsuario),
                                        Provider = provider,
                                        ProviderUserId = providerUserId
                                    });
                                }
                            }
                        }
                        else
                        {
                            user = new UserModel
                            {
                                xFullName = xFullName,
                                xUserName = userName,
                            };
                            user.providers.Add(new ProvidersModel
                            {
                                Provider = provider,
                                ProviderUserId = providerUserId
                            });
                        }


                        repository.Save(user);
                        this.SessionUserModel = repository.GetUser(user.xUserName);
                        ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                        ViewBag.ReturnUrl = returnUrl;                       
                    }
                }
            }
            return RedirectToAction(actionName: "Home", controllerName: "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(UserModel model, string returnUrl)
        {
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }







        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

    }
}
