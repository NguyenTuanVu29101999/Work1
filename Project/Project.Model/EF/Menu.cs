namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menus")]
    public partial class Menus
    {
        public int Id { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string  Description { get; set; }
        public int OrderNumber { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
