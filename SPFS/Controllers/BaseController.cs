using SPFS.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
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