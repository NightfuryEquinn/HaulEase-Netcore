using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Models
{
  public partial class HaulEaseDBContext : DbContext
  {
    public HaulEaseDBContext() { }
    public HaulEaseDBContext(DbContextOptions<HaulEaseDBContext> options) : base(options) { }

    public virtual DbSet<Consignor> Consignors { get; set; }
    public virtual DbSet<Cargo> Cargos { get; set; }
    public virtual DbSet<Shipment> Shipments { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Tracking> Trackings { get; set; }
    public virtual DbSet<Truck> Trucks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Consignor>(entity =>
      {
        entity.ToTable("Consignor");

        entity.Property(e => e.Username)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("username");
        
        entity.Property(e => e.Avatar)
          .IsRequired()
          .HasColumnName("avatar");

        entity.Property(e => e.Email)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("email");
        
        entity.Property(e => e.Password)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("password");

        entity.Property(e => e.Address)
          .IsRequired()
          .HasColumnName("address");
        
        entity.Property(e => e.Company)
          .HasColumnName("company");

        entity.Property(e => e.CompanyEmail)
          .HasMaxLength(255)
          .HasColumnName("companyEmail");

        entity.Property(e => e.CompanyAddress)
          .HasColumnName("companyAddress");
      });

      modelBuilder.Entity<Cargo>(entity => 
      {
        entity.ToTable("Cargo");

        entity.Property(e => e.Type)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("type");

        entity.Property(e => e.Weight)
          .IsRequired()
          .HasColumnName("weight")
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Length)
          .IsRequired()
          .HasColumnName("length")
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Width)
          .IsRequired()
          .HasColumnName("width")
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Height)
          .IsRequired()
          .HasColumnName("height")
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Image)
          .HasColumnName("image");

        entity.Property(e => e.Description)
          .IsRequired()
          .HasColumnName("description");
      });

      modelBuilder.Entity<Shipment>(entity => {
        entity.ToTable("Shipment");

        entity.Property(e => e.Status)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("status");

        entity.Property(e => e.Origin)
          .IsRequired()
          .HasColumnName("origin");

        entity.Property(e => e.Destination)
          .IsRequired()
          .HasColumnName("destination");
      });

      modelBuilder.Entity<Payment>(entity => {
        entity.ToTable("Payment");

        entity.Property(e => e.First)
          .HasColumnName("first")
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Second)
          .HasColumnName("second")
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Final)
          .HasColumnName("final")
          .HasColumnType("decimal(10,2)");
      });

      modelBuilder.Entity<Tracking>(entity => {
        entity.ToTable("Tracking");

        entity.Property(e => e.Time)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("time");

        entity.Property(e => e.Latitude)
          .IsRequired()
          .HasColumnType("decimal(8,6)")
          .HasColumnName("latitude");

        entity.Property(e => e.Longitude)
          .IsRequired()
          .HasColumnType("decimal(9,5)")
          .HasColumnName("longitude");
      });

      modelBuilder.Entity<Truck>(entity => {
        entity.ToTable("Truck");

        entity.Property(e => e.Status)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("status");

        entity.Property(e => e.DriverName)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("driverName");

        entity.Property(e => e.LicensePlate)
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnName("licensePlate");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
