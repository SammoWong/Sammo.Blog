using System.Web.Mvc;

namespace Sammo.Blog.Web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        [Route("Demo/IndexFor")]
        public string Index()
        {
            return "Hello,Word";
        }
    }
}