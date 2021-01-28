namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drivers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drivers()
        {
            Car = new HashSet<Car>();
            HistoriesCars = new HashSet<HistoriesCars>();
            Licensies = new HashSet<Licensies>();
        }

        public double id { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastNAme { get; set; }

        [StringLength(255)]
        public string MiddleName { get; set; }

        [Column("passport serial")]
        public double? passport_serial { get; set; }

        [Column("passport number")]
        public double? passport_number { get; set; }

        public double? postcode { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [Column("address life")]
        [StringLength(255)]
        public string address_life { get; set; }

        [StringLength(255)]
        public string company { get; set; }

        [StringLength(255)]
        public string jobname { get; set; }

        public double? phone { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public byte[] photoimg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Car { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriesCars> HistoriesCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Licensies> Licensies { get; set; }
    }
}
