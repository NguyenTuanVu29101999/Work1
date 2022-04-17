namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHUYEN_MAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHUYEN_MAI()
        {
            CT_KM = new List<CT_KM>();
        }

        [Key]
        public int IDKM { get; set; }

        [Required(ErrorMessage = "Phải có Mã KM")]
        [StringLength(50)]
        [DisplayName("Mã dùng")]
        public string MAKM { get; set; }

        
        [StringLength(250)]
        [DisplayName("Chương trình")]
        [Required(ErrorMessage = "Phải có chương trình khuyến mãi")]
        public string TEN_CH_TRINH { get; set; }
        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "Phải có ngày bắt đầu")]
        public DateTime? NGAY_BD { get; set; }
        [DisplayName("Ngày kết thúc")]
        [Required(ErrorMessage = "Phải có ngày kết thúc")]
        public DateTime? NGAY_KT { get; set; }
        [DisplayName("Ngày tạo")]
        [Column(TypeName = "date")]
        public DateTime? NGAY_TAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<CT_KM> CT_KM { get; set; }
    }
}
