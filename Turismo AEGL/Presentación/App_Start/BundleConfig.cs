using System.Web.Optimization;

namespace Presentación.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Script bundles
            bundles.Add(new ScriptBundle("~/Bundles/scripts").Include("~/Content/jquery-3.2.1/jquery-3.2.1.*"));
            bundles.Add(new ScriptBundle("~/Bundles/scripts").Include("~/Content/bootstrap-3.3.7/js/*.js"));

            // Style bundles
            bundles.Add(new StyleBundle("~/Bundles/styles").Include("~/Content/bootstrap-3.3.7/css/*"));
            
            // Habilitamos la inteligencia para que durante la sesión de debug se utilicen los archivos de desarrollo en lugar de los de producción, la minificación, etc.
            BundleTable.EnableOptimizations = true;
        }
    }
}