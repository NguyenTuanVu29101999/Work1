namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            CT_DON_HANG = new List<CT_DON_HANG>();
        }

        [Key]
        public int IDDH { get; set; }

        public int MAKH { get; set; }

        [StringLength(10)]
        [DisplayName("Điện thoai")]
        public string DT_GH { get; set; }

        [DisplayName("Giao hàng")]
        public bool? SHIP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY_TAO { get; set; }

        [DisplayName("Trạng thái")]
        public string TRANG_THAI { get; set; }

        [StringLength(50)]
        [DisplayName("Ghi chú")]
        public string NOTE { get; set; }

        public DateTime NGAY_LAY_DO { get; set; }

        public DateTime NGAY_HEN_KHACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<CT_DON_HANG> CT_DON_HANG { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
