using System.Web;
using System.Web.Optimization;

namespace PVMTrading_v1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                                 "~/Scripts/jquery-{version}.js",
                                      "~/Scripts/bootstrap.js",
                                      "~/Scripts/respond.js",
                "~/Scripts/Datatables/jquery.datatables.js",
                "~/Scripts/Datatables/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

                     

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));

            //css and js from temps

            bundles.Add(new ScriptBundle("~/bundles/core")
                .Include("~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/coreplugin")
                .Include("~/Content/vendor/jquery-easing/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/pageplugin")
               .Include("~/Content/vendor/chart.js/Chart.min.js",
               "~/Content/vendor/datatables/jquery.dataTables.js",
               "~/Content/vendor/datatables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/customscriptsallpages")
                .Include("~/Content/js/sb-admin.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/customscriptspage")
                .Include("~/Content/js/sb-admin-datatables.min.js",
                "~/Content/js/sb-admin-charts.min.js"));

            bundles.Add(new StyleBundle("~/bundles/corecss")
                .Include("~/Content/vendor/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/font-awesome")
                .Include("~/Content/vendor/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/bundles/plugincss")
                .Include("~/Content/vendor/datatables/dataTables.bootstrap4.css"));

            bundles.Add(new StyleBundle("~/bundles/customstyle")
                .Include("~/Content/css/sb-admin.css"));

            //pvmcore
            bundles.Add(new StyleBundle("~/pvm/core")
                .Include("~/Content/PVMcssandjs/css/bootstrap.css"));
            //pvmjs script
            bundles.Add(new ScriptBundle("~/pvm/plugin")
                .Include("~/Content/PVMcssandjs/js/jquery-1.11.1.min.js"));

            bundles.Add(new StyleBundle("~/pvm/customtheme")
                .Include("~/Content/PVMcssandjs/css/style.css",
                    "~/Content/PVMcssandjs/css/fasthover.css"));


            bundles.Add(new StyleBundle("~/pvm/customthemess")
                .Include("~/Content/PVMcssandjs/css/megamenu.css"));

            bundles.Add(new ScriptBundle("~/pvm/pluginsss")
                .Include("~/Content/PVMcssandjs/js/megamenu.js"));

            bundles.Add(new ScriptBundle("~/pvm/plugins")
                .Include("~/Content/PVMcssandjs/js/menu_jquery.js",
                    "~/Content/PVMcssandjs/js/simpleCart.min.js",
                    "~/Content/PVMcssandjs/js/responsiveslides.min.js",
                    "~/Content/PVMcssandjs/js/script.js",
                    "~/Content/PVMcssandjs/js/easyResponsiveTabs.js",
                    "~/Content/PVMcssandjs/js/bootstrap-3.1.1.min.js"));
            //Hover Card
            bundles.Add((new StyleBundle("~/css/hovercard")
                .Include("~/Content/hovercard.css")
            
            ));

            //bootstrap material design
            bundles.Add(new StyleBundle("~/Content/material-design-css")
                                    .Include("~/Content/vendor/bootstrap-material-design/css/google-font-roboto.css",
                                             "~/Content/vendor/bootstrap-material-design/css/google-font-icon.css",
                                             "~/Content/vendor/bootstrap-material-design/css/bootstrap-material-design.min.css"
                ));
            bundles.Add(new ScriptBundle("~/Content/material-design-js")
                                    .Include("~/Content/vendor/bootstrap-material-design/js/jquery-3.1.0.min.js",
                                             "~/Content/vendor/bootstrap-material-design/js/tether.min.js",
                                             "~/Content/vendor/bootstrap-material-design/js/bootstrap-material-design.iife.min.js",
                                             "~/Content/vendor/bootstrap-material-design/js/ie10-viewport-bug-workaround.js"

                ));
        }
    }
}
