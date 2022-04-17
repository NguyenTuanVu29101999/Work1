using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public class CheckPermissionAttributes :AuthorizeAttribute
    {
        public string ID_ROLES { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[Constant.UserSession];
            if(session == null)
            {
                return false;
            }
            List<string> privilegeLevels = this.GetPermissionByLogged(session.UserName);

            if (privilegeLevels.Contains(this.ID_ROLES) || session.ID_GROUP == CommonConstant.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/401.cshtml"
            };
        }

        private List<string> GetPermissionByLogged(string username)
        {
            var permission = (List<string>)HttpContext.Current.Session[Constant.SESSION_PERMISSION];
            return permission;
        }
    }
}