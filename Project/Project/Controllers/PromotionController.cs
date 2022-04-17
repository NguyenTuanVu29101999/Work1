using Project.Model.DAO;
using Project.Model.EF;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class PromotionController : BaseController
    {
        private ZaSaStored db = new ZaSaStored();
        // GET: Promotion
        [CheckPermissionAttributes(ID_ROLES = "VIEW")]
        public ActionResult Index()
        {
            var dao = new PromotionDAO();
            var model = dao.ListAll();
            return View(model);
        }


        // GET: Promotion/Create
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promotion/Create
        [HttpPost]
        [CheckPermissionAttributes(ID_ROLES = "ADD")]
        public ActionResult Create(KHUYEN_MAI promotion)
        {
            if (ModelState.IsValid)
            {
                var dao = new PromotionDAO();
                long id = dao.Insert(promotion);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Promotion");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(promotion);
        }

        // GET: Promotion/Edit/5
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //KHUYEN_MAI kHUYEN_MAI = db.KHUYEN_MAI.Find(id);
            //if (kHUYEN_MAI == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(kHUYEN_MAI);

            var promotion = new PromotionDAO().ViewDetail(id);
            return View(promotion);
        }

        // POST: Promotion/Edit/5
        [HttpPost]
        [CheckPermissionAttributes(ID_ROLES = "EDIT")]
        public ActionResult Edit(KHUYEN_MAI promotion)
        {
            if (ModelState.IsValid)
            {
                var dao = new PromotionDAO();

                bool rslt = dao.Update(promotion);
                if (rslt)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "Promotion");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(promotion);
        }
        // POST: Promotion/Delete/5
        [CheckPermissionAttributes(ID_ROLES = "DELETE")]
        public ActionResult Delete(int id)
        {
            var dao = new PromotionDAO();
            bool rslt = dao.Deletes(id);
            if (rslt)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "Promotion");
            }
            else
            {
                ModelState.AddModelError("", "Sửa không thành công");
            }
            return View(id);
        }
    }
}
