using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : BaseController
    {
        ZaSaStored db = new ZaSaStored();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var data = from a in db.SAN_PHAM select new { a.MASP, a.DON_GIA , a.TEN_SP };

            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AutoComplete()
        {
            return View();
        }

        public ActionResult GetAutoComplete(string term)
        {
            ZaSaStored db = new ZaSaStored();
            var rslt = db.KHACH_HANG.Where(x => x.NICK_NAME.Contains(term))
                .Select(s => new KHACH_HANG { NICK_NAME = s.NICK_NAME }).ToList();

            return Json(rslt, JsonRequestBehavior.AllowGet);
        }

    }
}