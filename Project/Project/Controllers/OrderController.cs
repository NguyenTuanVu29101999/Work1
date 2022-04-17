using Project.Model.DAO;
using Project.Model.EF;
using System.Data.Entity;
using Project.Model.ViewModel;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class OrderController : BaseController
    {
        ZaSaStored db = new ZaSaStored();

        public double TotalPrice()
        {
            return db.CT_DON_HANG.Sum(x => x.THANH_TIEN);
        }
        // GET: Order
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var dao = new OrderDAO();
                var model = dao.LisAlltOrder();
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public JsonResult Name(int id)
        {
            SAN_PHAM obj = db.SAN_PHAM.FirstOrDefault(m => m.MASP == id);
            return Json(obj.DON_GIA, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DonViTinh(int id)
        {
            SAN_PHAM objs = db.SAN_PHAM.FirstOrDefault(m => m.MASP == id);
            return Json(objs.DVT, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            SetViewBagSanPham();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewOrderModel data)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDAO();
                DON_HANG donhang = new DON_HANG()
                {
                    MAKH = data.MAKH,
                    SHIP = data.SHIP,
                    DT_GH = data.DT_GH,
                    NGAY_TAO = DateTime.Now,
                    TRANG_THAI = data.TRANG_THAI,
                    NOTE = data.NOTE,
                    NGAY_LAY_DO = data.NGAY_LAY_DO,
                    NGAY_HEN_KHACH = data.NGAY_HEN_KHACH
                    

                };
                CT_DON_HANG ctdonhang = new CT_DON_HANG()
                {
                    MASP = data.MASP,
                    SO_LUONG = data.SO_LUONG,
                    THANH_TIEN = (double)(data.DON_GIA * data.SO_LUONG)
                };

                donhang.CT_DON_HANG.Add(ctdonhang);
                dao.Insert(donhang);

                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index", "Order");
            }
            SetViewBagSanPham();
            return View("Index");
        }

        #region "SetViewBag"
        // Dropdown list SAN_PHAM , KHACH_HANG
        public void SetViewBagSanPham(int? SelectedId = null)
        {
            ViewBag.Name = new SelectList(db.SAN_PHAM.ToList(), "MASP", "TEN_SP", SelectedId);

            var daos = new CustomerDAO();
            ViewBag.MAKH = new SelectList(daos.GetSelectNickName(), "MAKH", "NICK_NAME", SelectedId);
          
        }

        #endregion
        //AutoComplete for input NICK_NAME
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            ZaSaStored entities = new ZaSaStored();
            var customers = (from a in entities.KHACH_HANG
                             where a.NICK_NAME.Contains(prefix)
                             select new
                             {
                                 label = a.NICK_NAME,
                                 val = a.MAKH
                             }).ToList();

            return Json(customers);
        }
        public ActionResult Delete(int id)
        {
            var dao = new OrderDAO();
            bool rslt = dao.Deletes(id);
            if (rslt)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "Order");
            }
            else
            {
                SetAlert("Xóa thất bại", "error");
            }
            return View("Index");
        }
    }
}