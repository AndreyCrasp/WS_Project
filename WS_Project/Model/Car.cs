namespace WS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            HistoriesCars = new HashSet<HistoriesCars>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string VIN { get; set; }

        [StringLength(255)]
        public string Manufacturer { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        public int? Year { get; set; }

        public int? Weight { get; set; }

        public int? Color { get; set; }

        public int? Engine_Type { get; set; }

        public int? type_of_drive { get; set; }

        public double? Driver_ID { get; set; }

        [MaxLength(255)]
        public byte[] Photoimg { get; set; }

        [StringLength(50)]
        public string TypeCar { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public int? Year_Engine { get; set; }

        [StringLength(50)]
        public string EngineModel { get; set; }

        public int? EngineNumber { get; set; }

        public double? EnginePower { get; set; }

        public double? EnginePowerHorse { get; set; }

        public double? MaxKg { get; set; }

        [StringLength(50)]
        public string Comment { get; set; }

        public virtual CarsColor CarsColor { get; set; }

        public virtual Drivers Drivers { get; set; }

        public virtual engine_types engine_types { get; set; }

        public virtual TypeOfDrive TypeOfDrive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriesCars> HistoriesCars { get; set; }
    }
}
