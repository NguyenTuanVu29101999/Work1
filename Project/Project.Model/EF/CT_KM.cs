namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_KM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKM { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAKH { get; set; }

        public int? ORDERNUMER { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        public virtual KHUYEN_MAI KHUYEN_MAI { get; set; }
    }
}
