namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACH_HANG")]
    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            CT_KM = new List<CT_KM>();
            DON_HANG = new List<DON_HANG>();
            PHIEU_NHAN = new List<PHIEU_NHAN>();
        }

        [Key]
        [DisplayName("Mã khách hàng")]
        [Required(ErrorMessage = "Phải có mã khách hàng")]
        public int MAKH { get; set; }

        [StringLength(250)]
        [DisplayName("Tên Khách hàng")]
        [Required(ErrorMessage = "Phải có khách hàng")]
        public string TENKH { get; set; }

        [StringLength(50)]
        [DisplayName("Tên khác")]
        [Required(ErrorMessage = "Phải có Nickname")]
        public string NICK_NAME { get; set; }

        [StringLength(10)]
        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Phải có khách hàng")]
        public string GT { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? NGAY_SINH { get; set; }

        [DisplayName("Điện thoại")]
        public int? DT_KH { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Ghi chú")]
        public string GHI_CHU { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? NGAY_TAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<CT_KM> CT_KM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<DON_HANG> DON_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PHIEU_NHAN> PHIEU_NHAN { get; set; }
    }
}
