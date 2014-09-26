using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Adm;
using HLP.Portal.MVC.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HLP.Portal.MVC.Controllers
{
    public class BaseController : Controller
    {
        RegistrationRepository repository = new RegistrationRepository();

        public HomeModel SessionHomeModel
        {
            get { return Session["home"] != null ? Session["home"] as HomeModel : new HomeModel(); }
            set { Session.Add("home", value); }
        }

        public UserModel SessionUserModel
        {
            get
            {
                if (Request != null)
                {
                    if (Session["user"] == null && Request.IsAuthenticated)
                    {
                        Session["user"] = repository.GetUser(User.Identity.Name);
                    }
                    else if(Session["user"] == null)
                    {
                        Session["user"] = new UserModel();
                    }
                }
                else
                {
                    Session["user"] = new UserModel();
                }
                return Session["user"] as UserModel;
            }
            set
            {
                Session.Add("user", value);
                if (value != null)
                {
                    FormsAuthentication.SetAuthCookie(userName: (value as UserModel).xUserName, createPersistentCookie: (value as UserModel).bRemember);
                }

            }
        }


        public string aviso
        {
            set
            {
                if (TempData.Keys.Contains("Sucesso"))
                {
                    TempData["Sucesso"] = value;
                }
                else
                {
                    TempData.Add("Sucesso", value);
                }
            }
        }
    }
}