using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sammo.Blog.Web.Startup))]
namespace Sammo.Blog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
