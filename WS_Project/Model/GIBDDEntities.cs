namespace WS_Project
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GIBDDEntities : DbContext
    {
        public GIBDDEntities()
            : base("name=GIBDDEntities")
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarsColor> CarsColor { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<engine_types> engine_types { get; set; }
        public virtual DbSet<HistiesLicensies> HistiesLicensies { get; set; }
        public virtual DbSet<HistoriesCars> HistoriesCars { get; set; }
        public virtual DbSet<Licensies> Licensies { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeOfDrive> TypeOfDrive { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.TypeCar)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.EngineModel)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.HistoriesCars)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarsColor>()
                .HasMany(e => e.Car)
                .WithOptional(e => e.CarsColor)
                .HasForeignKey(e => e.Color);

            modelBuilder.Entity<Drivers>()
                .HasMany(e => e.Car)
                .WithOptional(e => e.Drivers)
                .HasForeignKey(e => e.Driver_ID);

            modelBuilder.Entity<Drivers>()
                .HasMany(e => e.HistoriesCars)
                .WithOptional(e => e.Drivers)
                .HasForeignKey(e => e.DriverID);

            modelBuilder.Entity<Drivers>()
                .HasMany(e => e.Licensies)
                .WithOptional(e => e.Drivers)
                .HasForeignKey(e => e.Driver_ID);

            modelBuilder.Entity<engine_types>()
                .Property(e => e.TypeEn)
                .IsUnicode(false);

            modelBuilder.Entity<engine_types>()
                .Property(e => e.TypeRU)
                .IsUnicode(false);

            modelBuilder.Entity<engine_types>()
                .HasMany(e => e.Car)
                .WithOptional(e => e.engine_types)
                .HasForeignKey(e => e.Engine_Type);

            modelBuilder.Entity<HistoriesCars>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Licensies>()
                .HasMany(e => e.HistiesLicensies)
                .WithRequired(e => e.Licensies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.HistiesLicensies)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Licensies)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.Status_id);

            modelBuilder.Entity<TypeOfDrive>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfDrive>()
                .HasMany(e => e.Car)
                .WithOptional(e => e.TypeOfDrive)
                .HasForeignKey(e => e.type_of_drive);

            modelBuilder.Entity<users>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.datetime)
                .IsUnicode(false);
        }
    }
}
