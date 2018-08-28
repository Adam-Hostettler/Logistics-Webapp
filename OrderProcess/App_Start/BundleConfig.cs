using System.Web.Optimization;

namespace OrderProcess
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/productonhandhelper").Include(
            "~/Scripts/productonhandhelper.js"));

            bundles.Add(new ScriptBundle("~/bundles/fancyforms").Include(
                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/polyfiller.js",
                "~/Scripts/html5shiv.js",
                "~/Scripts/index.js"
 
            )
            .IncludeDirectory("~/Scripts/shims", "*.js", false)
            .IncludeDirectory("~/Scripts/shims", "*.css", true)
            .IncludeDirectory("~/Scripts/shims", "*.png", true)
            .IncludeDirectory("~/Scripts/shims", "*.gif", true)
            .IncludeDirectory("~/Scripts/shims", "*.svg", true)
            );
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Logistics/css").Include(
                "~/Content/main.css"));
        }
    }
}