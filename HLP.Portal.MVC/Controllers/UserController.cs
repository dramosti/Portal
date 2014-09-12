using HLP.Portal.MVC.Data.Repository;
using HLP.Portal.MVC.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HLP.Portal.MVC.Controllers
{
    public class UserController : Controller
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
                if (repository.IsValid(xEmail: user.xEmail, xSenha: user.xSenha))
                {
                    FormsAuthentication.SetAuthCookie(userName: user.xEmail, createPersistentCookie: user.bRemember);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login details are wrong.");
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


    }
}
