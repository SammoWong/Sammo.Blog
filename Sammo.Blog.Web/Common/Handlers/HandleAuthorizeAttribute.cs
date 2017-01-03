using System.Web.Mvc;
using System.Web.Security;

namespace Sammo.Blog.Web.Common.Handlers
{
    public class HandleAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            GenerateUserContext(filterContext);

            base.OnAuthorization(filterContext);
        }

        private static void GenerateUserContext(AuthorizationContext filterContext)
        {
            var formsIdentity = filterContext.HttpContext.User.Identity as FormsIdentity;
            if (formsIdentity == null || string.IsNullOrWhiteSpace(formsIdentity.Name))
                return;
            
            var fields = formsIdentity.Name.Split('|');
            //UserContext.Set();
        }
    }
}