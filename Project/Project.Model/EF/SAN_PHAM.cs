namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SAN_PHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SAN_PHAM()
        {
            CT_DON_HANG = new List<CT_DON_HANG>();
        }

        [Key]
        public int MASP { get; set; }

        [StringLength(250)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Chưa có tên sản phẩm")]
        public string TEN_SP { get; set; }

        [StringLength(50)]
        [DisplayName("Đơn vị tính")]
        [Required(ErrorMessage = "chưa có đơn vị tính")]
        public string DVT { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Chưa có đơn giá")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal? DON_GIA { get; set; }

        [StringLength(250)]
        [DisplayName("Mô tả sản phẩm")]
        public string MO_TA { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? NGAY_TAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<CT_DON_HANG> CT_DON_HANG { get; set; }
    }
}
