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
    public class StaffController : BaseController
    {
        private ZaSaStored db = new ZaSaStored();

        // GET: Staff
        [CheckPermissionAttributes(ID_ROLES = "VIEW")]
        public ActionResult Index()
        {
            var dao = new StaffDAO();
            var model = dao.ListAll();
            return View(model);
        }


        // GET: Staff/Create
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create(NHAN_VIEN staff)
        {
            if (ModelState.IsValid)
            {
                var dao = new StaffDAO();

                long id = dao.Insert(staff);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }

            return View(staff);
        }

        // GET: Staff/Edit/5
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(int id)
        {
            var staff = new StaffDAO().ViewDetail(id);
            return View(staff);
        }

        // POST: Staff/Edit/5

        [HttpPost]
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(NHAN_VIEN staff)
        {
            if (ModelState.IsValid)
            {
                var dao = new StaffDAO();

                bool rslt = dao.Update(staff);
                if (rslt)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(staff);
        }



        // POST: Staff/Delete/id
        [CheckPermissionAttributes(ID_ROLES = "DELETE")]
        public ActionResult Delete(int id)
        {
            var dao = new StaffDAO();
            bool rslt = dao.Deletes(id);
            if (rslt)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "Staff");
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
