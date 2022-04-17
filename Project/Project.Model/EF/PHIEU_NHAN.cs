namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEU_NHAN")]
    [Serializable]
    public class PHIEU_NHAN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int MAKH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MANV { get; set; }

        [StringLength(250)]
        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Phải có nội dung")]
        public string NOI_DUNG { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? NGAY_TAO { get; set; }

        [StringLength(250)]
        [DisplayName("Khách hàng")]
        [Required(ErrorMessage = "Phải có tên khách hàng")]
        public string TEN_KH { get; set; }

        [StringLength(250)]
        [DisplayName("Nhân viên")]
        [Required(ErrorMessage = "Phải có tên nhân viên")]
        public string TEN_NV { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }
    }
}
