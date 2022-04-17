using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Model.DAO;
using Project.Model.EF;
using Project.Models;

namespace Project.Controllers
{
    public class ProductController : BaseController
    {
        private ZaSaStored db = new ZaSaStored();

        // GET: Product
        [CheckPermissionAttributes(ID_ROLES = "VIEW")]
        public ActionResult Index()
        {
            var dao = new ProductDAO();
            var model = dao.ListAll();
            return View(model);
            //return View(db.SAN_PHAM.ToList());
        }

        // GET: Product/Create
        [HttpGet]
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create(SAN_PHAM product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(product);
        }
        // GET: Product/Edit/5
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            //if (sAN_PHAM == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(sAN_PHAM);

            var product = new ProductDAO().ViewDetail(id);
            return View(product);
        }
        [HttpPost]
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(SAN_PHAM product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();

                bool rslt = dao.Update(product);
                if (rslt)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(product);
        }
        [CheckPermissionAttributes(ID_ROLES = "DELETE")]
        public ActionResult Delete(int id)
        {
            var dao = new ProductDAO();
            bool rslt = dao.Deletes(id);
            if (rslt)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Xóa thất bại");
            }
            return View(id);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
