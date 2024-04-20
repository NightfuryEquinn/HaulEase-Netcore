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
        optionsBuilder.UseSqlServer("Data Source=haulease-db.cj2se06k8m4v.us-east-1.rds.amazonaws.com;Initial Catalog=hauleasedb;User ID=hauleaseadmin;Password=hauleaseadmin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
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
          .HasMaxLength(255);
        
        entity.Property(e => e.Avatar)
          .IsRequired();

        entity.Property(e => e.Email)
          .IsRequired()
          .HasMaxLength(255);
        
        entity.Property(e => e.Password)
          .IsRequired()
          .HasMaxLength(255);

        entity.Property(e => e.Address)
          .IsRequired();
        
        entity.Property(e => e.Company);

        entity.Property(e => e.CompanyEmail)
          .HasMaxLength(255);

        entity.Property(e => e.CompanyAddress);
      });

      modelBuilder.Entity<Cargo>(entity => 
      {
        entity.ToTable("Cargo");

        entity.Property(e => e.Type)
          .IsRequired()
          .HasMaxLength(255);

        entity.Property(e => e.Weight)
          .IsRequired()
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Length)
          .IsRequired()
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Width)
          .IsRequired()
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Height)
          .IsRequired()
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Image);

        entity.Property(e => e.Description);
      });

      modelBuilder.Entity<Shipment>(entity => {
        entity.ToTable("Shipment");

        entity.Property(e => e.Status)
          .IsRequired()
          .HasMaxLength(255);

        entity.Property(e => e.Origin)
          .IsRequired();

        entity.Property(e => e.Destination)
          .IsRequired();
      });

      modelBuilder.Entity<Payment>(entity => {
        entity.ToTable("Payment");

        entity.Property(e => e.First)
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Second)
          .HasColumnType("decimal(10,2)");

        entity.Property(e => e.Final)
          .HasColumnType("decimal(10,2)");
      });

      modelBuilder.Entity<Tracking>(entity => {
        entity.ToTable("Tracking");

        entity.Property(e => e.Time)
          .IsRequired()
          .HasMaxLength(255);

        entity.Property(e => e.Latitude)
          .IsRequired()
          .HasColumnType("decimal(8,6)");

        entity.Property(e => e.Longitude)
          .IsRequired()
          .HasColumnType("decimal(9,5)");
      });

      modelBuilder.Entity<Truck>(entity => {
        entity.ToTable("Truck");

        entity.Property(e => e.Status)
          .IsRequired()
          .HasMaxLength(255);

        entity.Property(e => e.DriverName)
          .IsRequired()
          .HasMaxLength(255);

        entity.Property(e => e.LicensePlate)
          .IsRequired()
          .HasMaxLength(255);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
