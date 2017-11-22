using System.Web.Optimization;

namespace Presentación.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle ScBundle = new ScriptBundle("~/bundles/scripts");
            StyleBundle StBundle = new StyleBundle("~/bundles/styles");

            // Script bundles
            ScBundle.Include(
                "~/Content/jquery-3.2.1/*.js", 
                "~/Content/bootstrap-3.3.7/js/*.js",
                "~/Content/js/*.js");

            // Style bundles
            StBundle.Include(
                "~/Content/bootstrap-3.3.7/css/bootstrap.*",
                "~/Content/styles/*.css");
            
            // Habilitamos la inteligencia para que durante la sesión de debug se utilicen los archivos de desarrollo en lugar de los de producción, la minificación, etc.
            BundleTable.EnableOptimizations = true;

            // Agregamos los bundles a la colección de bundles.
            bundles.Add(ScBundle);
            bundles.Add(StBundle);
        }
    }
}