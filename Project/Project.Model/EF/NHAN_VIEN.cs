namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAN_VIEN")]
    public partial class NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAN_VIEN()
        {
            PHIEU_NHAN = new List<PHIEU_NHAN>();
        }

        [Key]
        public int MANV { get; set; }

        [StringLength(250)]
        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Bạn chưa nhập Họ tên")]
        public string HO_TEN { get; set; }

        [StringLength(10)]
        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Bạn chưa nhập giới tính")]
        public string GT { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
      
        public DateTime? NGAY_SINH { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [DisplayName("Lương")]
        [Required(ErrorMessage = "Nhân viên phải có lương")]
        public double? LUONG { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? NGAY_TAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PHIEU_NHAN> PHIEU_NHAN { get; set; }

    }
}
