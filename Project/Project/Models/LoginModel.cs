using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập Username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập Password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}