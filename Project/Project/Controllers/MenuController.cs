using Project.Model.DAO;
using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class MenuController : BaseController
    {
        private ZaSaStored db = new ZaSaStored();
        // GET: Menu
        public ActionResult Index()
        {
            var dao = new MenuDAO();
            var model = dao.ListAll();
            return View(model);
        }
    }
}