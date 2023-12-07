using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Xml.Linq;

namespace MvcLibrary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //// Panel alanı için route
            //routes.MapRoute(
            //    name: "Panel_default",
            //    url: "Panel/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "Panel.Controllers" } // Panel controller'ları için ad alanı belirtme
            //);
            //routes.MapRoute(
            //     name: "Admin_Announcement",
            //     url: "Panel/{controller}/{action}/{id}",
            //     new { controller = "Announcement" }
            //    ); routes.MapRoute(
            //     name: "Auth",
            //     url: "{controller}/{action}/{id}",
            //     new { controller = "Auth" }
            //    ); routes.MapRoute(
            //     name: "Admin_Author",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Author" }
            //    ); routes.MapRoute(
            //     name: "Admin_Book",
            //     url: "Admin/{controller}/{action}/{id}"
            //     new { controller = "Book" ,action="*",id= UrlParameter.Optional }
            //    ); routes.MapRoute(
            //     name: "Admin_Borrow",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Borrow" }
            //    ); routes.MapRoute(
            //     name: "Admin_Category",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Category" }
            //    ); routes.MapRoute(
            //     name: "Admin_Home",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Home" }
            //    ); routes.MapRoute(
            //     name: "Admin_Member",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Member" }
            //    ); routes.MapRoute(
            //     name: "Admin_Message",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Message" }
            //    ); routes.MapRoute(
            //     name: "Admin_Panel",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Panel" }
            //    ); routes.MapRoute(
            //     name: "Admin_Showcase",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Showcase" }
            //    ); routes.MapRoute(
            //     name: "Admin_Staff",
            //     url: "Admin/{controller}/{action}/{id}",
            //     new { controller = "Staff" }
            //    ); 
        }
    }
}
