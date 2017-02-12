using Sammo.Blog.Application.Blog;
using Sammo.Blog.Application.Blog.Dto;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sammo.Blog.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin"), Authorize]
    public class BlogController : AdminBaseController
    {
        private readonly BlogAppService _service;
        public BlogController()
        {
            _service = IoCConfig.Get<BlogAppService>();
        }
        [Route("Blog/Add")]
        public ActionResult Add()
        {
            var categories = _service.GetCategories();
            TempData["Categories"] = categories;
            return View();
        }

        [Route("Blog/Add"), HttpPost]
        public async Task<ActionResult> Add(AddBlogInput input)
        {
            await CheckModelStateAsync();
            return View();
        }

        [Route("Blog/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Blog/List")]
        public ActionResult List()
        {
            return View();
        }

        [Route("Blog/Edit")]
        public ActionResult Edit()
        {
            return View();
        }
    }
}