namespace QLSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Class
    {
        public Guid Id { get; set; }

        [StringLength(30)]
        public string ClassCode { get; set; }

        [StringLength(30)]
        public string ClassName { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? OrderNumber { get; set; }
    }
}
