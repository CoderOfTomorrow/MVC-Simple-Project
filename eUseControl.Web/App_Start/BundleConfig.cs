using System.Web.Optimization;

namespace eUseControl.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/main/css").Include("~/Content/style.css", 
                new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style_new/css").Include("~/Content/style_new.css",
                new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css",
                new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/font-awesome.min.css",
                new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include("~/Scripts/jquery-3.5.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                "~/Scripts/jquery.validate.min.js"));
        }
    }
}