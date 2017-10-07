Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include(
                  "~/Scripts/jquery-ui-{version}.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New ScriptBundle("~/bundles/custom").Include(
                  "~/Scripts/DataTables/jquery.dataTables.min.js",
                  "~/Scripts/chosen.jquery.js",
                  "~/Scripts/custom.js",
                  "~/Scripts/superfish.js",
                  "~/Scripts/modernizr.custom.js"))


        bundles.Add(New ScriptBundle("~/bundles/tinymce").Include(
                  "~/Scripts/tinymce/tinymce.min.js"))


        bundles.Add(New ScriptBundle("~/bundles/custom2").Include(
                  "~/Scripts/jquery.navgoco.js",
                   "~/Scripts/jquery.carouFredSel-6.2.1.js",
                    "~/Scripts/owl.carousel.js"
                 ))

        ' "~/Scripts/jquery.sticky.js"

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.min.css",
                  "~/Content/bootstrap-chosen.css",
                  "~/Content/site.css",
                  "~/Content/font-awesome.css",
                  "~/Content/superfish.css",
                  "~/Content/megafish.css",
                  "~/Content/jquery.navgoco.css",
                  "~/Content/owl.carousel.css",
                  "~/Content/owl.theme.css",
                  "~/Content/jquery.mCustomScrollbar.css",
                  "~/Content/bootstrap-slider.css",
                  "~/Content/style.css",
                  "~/Content/DataTables/css/jquery.dataTables.min.css",
                  "~/Content/font-awesome.css",
                  "~/Content/w3.css",
                  "~/Content/fontlatingreek.css"))


        BundleTable.EnableOptimizations = True

    End Sub
End Module

