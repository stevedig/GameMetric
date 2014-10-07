using System.Web;
using System.Web.Optimization;

namespace GameMetrics
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }
        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                            .Include("~/Content/bootstrap.css")
                            .Include("~/Content/bootstrap-responsive.css")
                            .Include("~/Content/site.css"));
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
                            .Include("~/Scripts/jquery-{version}.js")
                            .Include("~/Scripts/jquery-ui-{version}.js")
                            .Include("~/Scripts/bootstrap.js"));
        }
    }
}