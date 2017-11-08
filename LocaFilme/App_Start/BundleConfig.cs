﻿using System.Web;
using System.Web.Optimization;

namespace LocaFilme
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/lib").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/bootstrap.js",
            //            "~/Scripts/bootbox.js",
            //            "~/Scripts/respond.js",
            //            "~/Scripts/DataTables/dataTables.bootstap.js",
            //            "~/Scripts/DataTables/jquery.dataTables.js"
            //            ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js",
                         "~/scripts/bootbox.js",
                         "~/Scripts/respond.js",
                         "~/scripts/datatables/jquery.datatables.js",
                         "~/scripts/datatables/datatables.bootstrap.js"
                         ));

            // Essa parte eh utilizada para o client side validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap-lumen.css",
            //          "~/Content/DataTables/css/dataTables.bootstrap.css",
            //          "~/Content/Site.css"
            //          ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap-lumen.css",
                        "~/content/datatables/css/datatables.bootstrap.css",
                        "~/Content/site.css"));
        }
    }
}
