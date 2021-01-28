namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string login { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string datetime { get; set; }
    }
}
