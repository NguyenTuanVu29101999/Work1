using Project.Model.DAO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public string UserSession { get; private set; }
        public ActionResult Index()
        {
            return View();
        }
        protected void LoginAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var reslt = dao.Login(model.UserName, model.Password,true); // dùng khi mật khẩu kh băm bằng MD5

                if (reslt == 1) // mật khẩu truyền vào khớp với mật khẩu trong csdl
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    if(model.UserName == user.TAI_KHOAN && model.Password == user.MAT_KHAU )
                    {
                        Session["Login"] = model;
                    }
                    //userSession.UserName = user.TAI_KHOAN;
                    userSession.UserID = user.ID;
                    userSession.ID_GROUP = user.ID_GROUP;

                    var listpermission = dao.GetListPermission(model.UserName);

                    Session.Add(Constant.SESSION_PERMISSION, listpermission);
                    Session.Add(Constant.UserSession, userSession);

                    LoginAlert("Đăng nhập thành công", "success");
                    return RedirectToAction("Index", "Home");

                }
                else if (reslt == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (reslt == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không hoạt động");
                }
                else if (reslt == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (reslt == -3)
                {
                    ModelState.AddModelError("", "Không có quyền truy cập");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}