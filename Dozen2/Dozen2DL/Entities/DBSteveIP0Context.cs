using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dozen2DL.Entities
{
    public partial class DBSteveIP0Context : DbContext
    {
        public DBSteveIP0Context()
        {
        }

        public DBSteveIP0Context(DbContextOptions<DBSteveIP0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:server-stevei-p0.database.windows.net,1433;Initial Catalog=DBSteveI-P0;Persist Security Info=False;User ID=simas;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.ToTable("Drink");

                entity.Property(e => e.DrinkId).HasColumnName("drinkID");

                entity.Property(e => e.Abv).HasColumnName("ABV");

                entity.Property(e => e.DrinkName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("drinkName");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.DrinkId).HasColumnName("DrinkID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Drink__73BA3083");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Locat__74AE54BC");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("locationName");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.DrinkId).HasColumnName("drinkID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__customer__7E37BEF6");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__drinkID__00200768");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__location__7F2BE32F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
