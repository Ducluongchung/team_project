using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EcommerceCore.Common.Controller
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected ActionResult AccessDeniedView()
        {
            return RedirectToAction("AccessDenied", "Error", new { area = "", pageUrl = Request.RawUrl });
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!
            // _Logger.Error(filterContext.Exception);

            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
            // OR 
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/ErrorHandler/Index.cshtml"
            };
        }
    }
}
