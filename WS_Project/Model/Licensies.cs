namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Licensies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Licensies()
        {
            HistiesLicensies = new HashSet<HistiesLicensies>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public double? Driver_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Licence_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expire_date { get; set; }

        [StringLength(255)]
        public string Categories { get; set; }

        public int? Licenceseries { get; set; }

        public int? Licence_number { get; set; }

        public int? Status_id { get; set; }

        public virtual Drivers Drivers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistiesLicensies> HistiesLicensies { get; set; }

        public virtual Status Status { get; set; }
    }
}
