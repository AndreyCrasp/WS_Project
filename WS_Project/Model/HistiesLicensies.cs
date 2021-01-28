namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HistiesLicensies
    {
        public int Id { get; set; }

        public int LicensiesId { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public int Status_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public virtual Licensies Licensies { get; set; }

        public virtual Status Status { get; set; }
    }
}
