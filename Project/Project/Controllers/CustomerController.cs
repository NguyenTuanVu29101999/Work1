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
    public class CustomerController : BaseController
    {
        private ZaSaStored db = new ZaSaStored();

        // GET: Customer
        public ActionResult Index()
        {
            var dao = new CustomerDAO();
            var model = dao.ListAll();
            return View(model);
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACH_HANG customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();

                long id = dao.Insert(customer);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            //if (kHACH_HANG == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(kHACH_HANG);

            var product = new CustomerDAO().ViewDetail(id);
            return View(product);
        }

        // POST: Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(KHACH_HANG customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();

                bool rslt = dao.Update(customer);
                if (rslt)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
        //    if (kHACH_HANG == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(kHACH_HANG);
        //}

        // POST: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var dao = new CustomerDAO();
            bool rslt = dao.Deletes(id);
            if (rslt)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "Sửa không thành công");
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
