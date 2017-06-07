using System.Web;
using System.Web.Optimization;

namespace Luckyfive.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery.js",
                         "~/Scripts/jquery.maskedinput.js",
                         "~/Scripts/jquery-migrate-1.2.1.js",
                         "~/Scripts/jquery.easing.1.3.js",
                         "~/Scripts/jquery.mobilemenu.js",
                         "~/Scripts/jquery.cookie.js",
                         "~/Scripts/jquery.mousewheel.min.js",
                         "~/Scripts/jquery.simplr.smoothscroll.min.js",
                         "~/Scripts/stellar/jquery.stellar.js",
                         "~/Scripts/jquery.ui.totop.js",
                         "~/Scripts/jquery.equalheights.js"));

            bundles.Add(new ScriptBundle("~/bundles/tm-scripts").Include(
                    "~/Scripts/tm-scripts.js",
                    "~/Scripts/device.min.js",
                    "~/Scripts/superfish.js",
                    "~/Scripts/device.min.js"
                    ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.maskedinput.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/moment.min.js",
                "~/App/Services/*.js",
                "~/App/*.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                "~/Scripts/dropzone/dropzone.js"));


            bundles.Add(new StyleBundle("~/dropzone/css").Include(
                      "~/Scripts/dropzone/basic.css",
                      "~/Scripts/dropzone/dropzone.css"
                      ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/animate.css",
                      "~/Content/style.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
