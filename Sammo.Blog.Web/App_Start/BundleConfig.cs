using System.Web;
using System.Web.Optimization;

namespace Sammo.Blog.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region MyRegion
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            //// 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css")); 
            #endregion

            #region Style
            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Blog/Common").Include(
                "~/Static/Shared/Css/bootstrap.min.css",
                "~/Static/Shared/Css/font-awesome.min.css",
                "~/Static/Shared/Css/rewrite-bootstrap.css",
                "~/Static/Blog/Css/blogStyle.css"));

            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Admin/Common").Include(
                "~/Static/Shared/Css/bootstrap-admin.min.css",
                "~/Static/Shared/Css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Admin/Style").Include("~/Static/Admin/Css/adminStyle.css"));

            #region Plugins
            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Animate").Include("~/Static/Shared/Plugins/Animate/animate.css"));
            bundles.Add(new StyleBundle("~/Bundles/Static/Css/ICheck").Include("~/Static/Shared/Plugins/ICheck/custom.css"));
            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Toastr").Include("~/Static/Shared/Plugins/ICheck/toastr.min.css"));
            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Summernote").Include("~/Static/Shared/Plugins/Summernote/summernote.css"
                , "~/Static/Shared/Plugins/Summernote/summernote-bs3.css"));
            bundles.Add(new StyleBundle("~/Bundles/Static/Css/Chosen").Include("~/Static/Shared/Plugins/Chosen/chosen.css"));
            #endregion

            #endregion

            #region Script
            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Blog/Common").Include(
                "~/Static/Shared/Js/jquery.min.js",
                "~/Static/Shared/Js/bootstrap.min.js",
                "~/Static/Blog/Js/base.js"));

            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Admin/Common").Include(
                "~/Static/Shared/Js/jquery.min.js",
                "~/Static/Shared/Js/bootstrap.min.js",
                //"~/Static/Shared/Js/jquery.validate.min.js",
                "~/Static/Shared/Js/message_zh.min.js",
                "~/Static/Admin/Js/hplus.js"));

            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Vue").Include(
                "~/Static/Shared/Js/Vue/vue.min.js",
                "~/Static/Shared/Js/Vue/vue-validator.min.js"));

            #region Plugins
            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/ICheck").Include("~/Static/Shared/Plugins/ICheck/icheck.min.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Toastr").Include("~/Static/Shared/Plugins/Toastr/toastr.min.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/MetisMenu").Include("~/Static/Shared/Plugins/MetisMenu/jquery.metisMenu.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Summernote").Include("~/Static/Shared/Plugins/Summernote/summernote.min.js"
                , "~/Static/Shared/Plugins/Summernote/summernote-zh-CN.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Chosen").Include("~/Static/Shared/Plugins/Chosen/chosen.jquery.js"));

            #endregion

            bundles.Add(new ScriptBundle("~/Bundles/Static/Js/Register").Include("~/Static/Admin/Js/Account/register.js"));
            

            #endregion

        }
    }
}
