namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarsColor")]
    public partial class CarsColor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarsColor()
        {
            Car = new HashSet<Car>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Color_ID { get; set; }

        [Column("Color code")]
        [StringLength(255)]
        public string Color_code { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Column("Color name")]
        [StringLength(255)]
        public string Color_name { get; set; }

        [Column("Name EN")]
        [StringLength(255)]
        public string Name_EN { get; set; }

        [Column("Color name (EN)")]
        [StringLength(255)]
        public string Color_name__EN_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Car { get; set; }
    }
}
