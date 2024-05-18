using System.Web;
using System.Web.Optimization;

namespace LMS.HRMatrix.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/base/css").Include("~/content/icons/icomoon/styles.css", new CssRewriteUrlTransform())
                                                    .Include("~/content/icons/fontawesome/styles.min.css",
                                                             "~/content/bootstrap.css",
                                                             "~/content/core.css",
                                                             "~/content/components.css",
                                                             "~/content/colors.css",
                                                             "~/content/style.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include("~/Content/kendo/kendo.common-nova.min.css",
                                                                       "~/Content/kendo/kendo.nova.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendo/kendo.all.min.js",
                                                                    "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/base/script").Include("~/scripts/plugins/loaders/pace.min.js",
                                                                  "~/scripts/core/libraries/jquery.min.js",
                                                                  "~/scripts/core/libraries/bootstrap.min.js",
                                                                  "~/scripts/plugins/loaders/blockui.min.js",
                                                                  "~/scripts/plugins/ui/nicescroll.min.js",
                                                                  "~/scripts/plugins/ui/drilldown.js",
                                                                  "~/scripts/plugins/notifications/sweet_alert.min.js",
                                                                  "~/scripts/plugins/forms/styling/uniform.min.js",
                                                                  "~/scripts/plugins/forms/styling/switchery.min.js",
                                                                  "~/scripts/plugins/forms/styling/switch.min.js"));

            bundles.Add(new ScriptBundle("~/base/script/fixed").Include("~/scripts/pages/layout_navbar_secondary_fixed.js"));

            bundles.Add(new ScriptBundle("~/base/script/selects").Include("~/scripts/plugins/forms/selects/select2.min.js"));

            bundles.Add(new ScriptBundle("~/base/script/validation").Include("~/scripts/jquery.unobtrusive-ajax.min.js",
                                                                          "~/scripts/jquery.validate.min.js",
                                                                          "~/scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/base/script/default").Include("~/scripts/default.js"));

            bundles.Add(new ScriptBundle("~/base/script/editable").Include("~/scripts/core/libraries/jasny_bootstrap.min.js",
                                                                           "~/scripts/plugins/forms/editable/editable.min.js",
                                                                           "~/scripts/plugins/extensions/mockjax.min.js"));

            bundles.Add(new ScriptBundle("~/base/script/expense").Include("~/scripts/rexpense.js"));

            bundles.Add(new ScriptBundle("~/base/script/timesheet").Include("~/scripts/rtimesheet.js"));

            bundles.Add(new ScriptBundle("~/base/script/fileinput").Include("~/scripts/plugins/uploaders/fileinput.min.js"));

            bundles.Add(new ScriptBundle("~/base/script/formatter").Include("~/scripts/plugins/forms/inputs/formatter.min.js"));

            bundles.Add(new ScriptBundle("~/base/script/fullcalendar").Include("~/scripts/plugins/ui/moment/moment.min.js",
                                                                               "~/scripts/plugins/ui/fullcalendar/fullcalendar.min.js"));

            bundles.IgnoreList.Clear();
        }
    }
}
