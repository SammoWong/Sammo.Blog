using Sammo.Blog.Web.Common.Results;
using System.Net;
using System.Web.Mvc;

namespace Sammo.Blog.Web.Common.Handlers
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            filterContext.Result = new Json
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new JsonData(false, filterContext.Exception.Message)
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}