using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApartmentRentProject.Models
{
    public partial class ApartmentDataBaseContext : DbContext
    {
        public ApartmentDataBaseContext()
        {
        }

        public ApartmentDataBaseContext(DbContextOptions<ApartmentDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApartmentDataBase;Trusted_Connection=True;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Number).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Order)
                    .HasForeignKey<Order>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__Id__52593CB8");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__StatusId__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__UserId__4F7CD00D");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId })
                    .HasName("PK__OrderPro__5835C3715C1C5D4A");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.AddingDate).HasColumnType("datetime");

                entity.Property(e => e.Category).IsRequired();

                entity.Property(e => e.Color).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Size).IsRequired();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
