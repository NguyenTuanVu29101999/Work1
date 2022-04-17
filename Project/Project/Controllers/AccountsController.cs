using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using Project.Model.DAO;
using Project.Model.EF;
using Project.Models;

namespace Project.Controllers
{
    public class AccountsController : BaseController
    {
        private ZaSaStored db = new ZaSaStored();

        // GET: Accounts
        [CheckPermissionAttributes(ID_ROLES = "VIEW")]
        public ActionResult Index(string searchString)
        {
            var dao = new UserDAO();
            var model = dao.ListAll(searchString);
            return View(model);
        }

        // GET: Accounts/Create
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create()
        {
            SetViewBagGroupID();
            return View();
        }

        // POST: Accounts/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create(ACCOUNT account)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                long id = dao.Insert(account);
                
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Accounts");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            SetViewBagGroupID();
            return View(account);
            //if (ModelState.IsValid)
            //{
            //    db.ACCOUNT.Add(aCCOUNT);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(aCCOUNT);
        }

        // GET: Accounts/Edit/5
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            SetViewBagGroupID();
            return View(user);
        }

        // POST: Accounts/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(ACCOUNT user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                bool rslt = dao.Update(user);
                if (rslt)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "Accounts");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            SetViewBagGroupID();
            return View(user);
        }

        // POST: Accounts/Delete/5
        [CheckPermissionAttributes(ID_ROLES = "DELETE")]
        public ActionResult Delete(int id)
        {
            var dao = new UserDAO();
            bool rslt = dao.Delete(id);
            if (rslt)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "Accounts");
            }
            else
            {
                ModelState.AddModelError("", "Sửa không thành công");
            }
            return View(id);
        }
        [HttpPost]
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public JsonResult ChangeStatus(long id)
        {
            var rslt = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = rslt
            });

        }
        #region "SetViewBag"
        public void SetViewBagGroupID(int? SelectedId = null)
        {
            var dao = new UserDAO();
            ViewBag.ID_GROUP = new SelectList(dao.GetSelectGroupID(), "ID_GROUP", "ID_GROUP", SelectedId);
        }
        #endregion
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
