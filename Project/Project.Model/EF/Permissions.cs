namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permissions")]
    [Serializable]
    public class Permissions
    {
        [Key]
        [StringLength(50)]
        public string ID_GROUP { get; set; }
        [StringLength(50)]
        public string ID_ROLES { get; set; }
    }
}
