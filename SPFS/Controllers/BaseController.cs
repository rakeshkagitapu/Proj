using SPFS.Helpers;
using SPFS.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SPFS.Controllers
{
    public class BaseController : Controller
    {
        private ILogger _logger;

        public ILogger Logger
        {
            get { return _logger; }
        }

        public BaseController()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
        }
        [AllowAnonymous]
        public ActionResult Exception()
        {
            return View();
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            ViewBag.ShowMenus = false;
            ViewBag.ShowAdmin = false;
            if (Request.IsAuthenticated)
                base.OnAuthentication(filterContext);
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            ViewBag.ShowRatings = false;
            ViewBag.ShowAdmin = false;
            if (Request.IsAuthenticated)
            {
                Utilities utils = new Utilities();
                var user = utils.GetCurrentUser();
                string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string action = filterContext.ActionDescriptor.ActionName;

                if (user == null)
                {
                    filterContext.Result = new ViewResult { ViewName = "Unauthorized", ViewData = this.ViewData };
                }
                else
                {

                    ViewBag.ShowRatings = true;
                    if (controller.Equals("Account", StringComparison.InvariantCultureIgnoreCase) && action.Equals("LogOff", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ViewBag.ShowRatings = false;
                    }
                    String[] roles = utils.GetRolesForCurrentUser();
                    GenericPrincipal principal = new GenericPrincipal(User.Identity, roles);
                    Thread.CurrentPrincipal = principal;
                }
            }
            base.OnAuthorization(filterContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}