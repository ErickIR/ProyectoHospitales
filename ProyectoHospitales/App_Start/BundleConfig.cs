using System.Web;
using System.Web.Optimization;

namespace ProyectoHospitales
{
    using System.Web.Hosting;
    using System.Web.Optimization;

    // a more fault-tolerant bundle that doesn't blow up if the file isn't there
    public class BundleRelaxed : Bundle
    {
        public BundleRelaxed(string virtualPath)
            : base(virtualPath)
        {
        }

        public new BundleRelaxed IncludeDirectory(string directoryVirtualPath, string searchPattern, bool searchSubdirectories)
        {
            var truePath = HostingEnvironment.MapPath(directoryVirtualPath);
            if (truePath == null) return this;

            var dir = new System.IO.DirectoryInfo(truePath);
            if (!dir.Exists || dir.GetFiles(searchPattern).Length < 1) return this;

            base.IncludeDirectory(directoryVirtualPath, searchPattern);
            return this;
        }

        public new BundleRelaxed IncludeDirectory(string directoryVirtualPath, string searchPattern)
        {
            return IncludeDirectory(directoryVirtualPath, searchPattern, false);
        }
    }

    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new BundleRelaxed("~/bundles/admin")
            //.IncludeDirectory("~/Content/Admin", "*.js")
            //.IncludeDirectory("~/Content/Admin/controllers", "*.js")
            //.IncludeDirectory("~/Content/Admin/directives", "*.js")
            //.IncludeDirectory("~/Content/Admin/services", "*.js")
            //);
            //bundles.Add(new BundleRelaxed("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new BundleRelaxed("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new BundleRelaxed("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new BundleRelaxed("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
