using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using SPFS.Models;
using System.Web.Security;
using SPFS.Helpers;
using System.Security.Principal;
using System.Threading;

namespace SPFS.Controllers
{   
    public class AccountController : BaseController
    {
        public AccountController()
        {
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (returnUrl != null && (returnUrl.ToLower().Contains("logoff") || returnUrl.ToLower().Contains("exception")))
                returnUrl = null;

            if (ModelState.IsValid)
            {
                bool checkUserWithAd = false;
                checkUserWithAd = true;//Membership.ValidateUser(model.UserName, model.Password)
                if (checkUserWithAd)
                {
                    Utilities utils = new Utilities();

                    String[] roles = utils.GetRolesForCurrentUser(model.UserName);
                    GenericPrincipal principal = new GenericPrincipal(User.Identity, roles);
                    Thread.CurrentPrincipal = principal;

                    System.Web.HttpContext.Current.User = principal;

                    
                    this.Logger.Log( model.UserName + " Logged in",Logging.LoggingLevel.Info);

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\") && !returnUrl.Contains("Account/Login"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect");
                }
            }

            // if we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
           // AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        protected override void Dispose(bool disposing)
        {
            //if (disposing && UserManager != null)
            //{
            //    UserManager.Dispose();
            //    UserManager = null;
            //}
            base.Dispose(disposing);
        }
    }
}