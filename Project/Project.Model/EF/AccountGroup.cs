namespace Project.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountGroup")]
    public class AccountGroup
    {
        [Key]
        [StringLength(50)]
        public string ID_GROUP { get; set; }
        [StringLength(50)]
        public string NAME_GROUP { get; set; }
    }
}
