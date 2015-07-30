using System.Web;
using System.Web.Optimization;

namespace Mantenimiento
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jasny-bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/dynamics").Include(
                       "~/Scripts/dynamics-{version}.js",
                      "~/Scripts/chosen.jquery.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/jquery.validationEngine.js",
                      "~/Scripts/jquery.validationEngine-es.js",
                       "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUi").Include(
                       "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content/cssBootstrap").Include(
                     "~/Content/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/Site.css",
                      "~/Content/dynamics.css",
                      "~/Content/chosen.css",
                      "~/Content/jquery.dataTables.css",
                       "~/Content/jasny-bootstrap.css",
                       "~/Content/dinamycs-style.css",
                "~/Content/multi-select.css",
                "~/Content/awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-messages.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/angular-ui/ui-utils.js"
                ));
            bundles.Add(new StyleBundle("~/Content/cssAngular").Include(
                      "~/Content/css/bootstrap.css",
                "~/Content/css/Site.css"));
        }
    }
}
