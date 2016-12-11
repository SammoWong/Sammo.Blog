using Sammo.Blog.Web.Common.Handlers;
using System.Web.Mvc;

namespace Sammo.Blog.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorHandler());
        }
    }
}
