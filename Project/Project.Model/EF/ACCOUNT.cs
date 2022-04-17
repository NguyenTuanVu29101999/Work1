namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        public int ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string TAI_KHOAN { get; set; }

        [StringLength(250)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string MAT_KHAU { get; set; }

        [StringLength(50)]
        [DisplayName("Quyền đăng nhập")]
        //[Required(ErrorMessage = "Bạn chưa chọn quyền đăng nhập")]
        public string ID_GROUP { get; set; }

        [StringLength(250)]
        [DisplayName("Sở hữu")]
        public string OWNERS { get; set; }
        [DisplayName("Kích hoạt")]
        public bool TRANG_THAI { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? NGAY_TAO { get; set; }
    }
}
