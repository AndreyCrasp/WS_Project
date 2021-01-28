namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HistoriesCars
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public double? DriverID { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public int CarID { get; set; }

        public virtual Car Car { get; set; }

        public virtual Drivers Drivers { get; set; }
    }
}
