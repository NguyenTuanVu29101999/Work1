namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Roles")]
    public class Roles
    {
        [Key]
        [StringLength(50)]
        public string ID_ROLES { get; set; }
        [StringLength(50)]
        public string NAME_ROLES { get; set; }
    }
}
