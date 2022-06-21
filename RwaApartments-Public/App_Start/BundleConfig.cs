using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RwaApartments_Public.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/Scripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new Bundle("~/Validation").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/Scripts").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/Content").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/validation.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/custom-styling.css"));
        }
    }
}