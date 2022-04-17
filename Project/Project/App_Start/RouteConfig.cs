using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "dang-nhap",
              url: "dang-nhap",
              defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "tai-khoan/danh-sach-tai-khoan",
              url: "tai-khoan/danh-sach-tai-khoan",
              defaults: new { controller = "Accounts", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "Account/Create",
               url: "tai-khoan/tao-moi-tai-khoan",
               defaults: new { controller = "Accounst", action = "Create", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Account/Edit/{id}",
               url: "tai-khoan/chinh-sua-thong-tin/{id}",
               defaults: new { controller = "Accounts", action = "Edit", id = UrlParameter.Optional }
           );



            routes.MapRoute(
               name: "trang-chu",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "san-pham/danh-sach-san-pham",
               url: "san-pham/danh-sach-san-pham",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
           );
            



            routes.MapRoute(
               name: "khach-hang/danh-sach-khach-hang",
               url: "khach-hang/danh-sach-khach-hang",
               defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "nhan-vien-danh-sach-nhan-vien",
               url: "nhan-vien/danh-sach-nhan-vien",
               defaults: new { controller = "Staff", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "khuyen-mai/chuong-trinh-khuyen-mai",
              url: "khuyen-mai/chuong-trinh-khuyen-mai",
              defaults: new { controller = "Promotion", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "don-hang/danh-sach-don-hang",
              url: "don-hang/danh-sach-don-hang",
              defaults: new { controller = "Order", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "don-hangs/danh-sach-don-hangs",
             url: "don-hangs/danh-sach-don-hangs",
             defaults: new { controller = "DonHang", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
               name: "don-hang/chi-tiet-don-hang/{id}",
               url: "don-hang/chi-tiet-don-hang/{id}",
               defaults: new { controller = "Order", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}
