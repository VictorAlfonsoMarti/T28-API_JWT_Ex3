using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace T28_API_JWT_Ex3.Models
{
    public partial class T28API_JWT_Ex3Context : DbContext
    {

        public T28API_JWT_Ex3Context(DbContextOptions<T28API_JWT_Ex3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cajeros> Cajeros { get; set; }
        public virtual DbSet<MaquinasRegistradoras> MaquinasRegistradoras { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajeros>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Cajeros__06370DADDB515BF2");

                entity.Property(e => e.NomApels).HasMaxLength(255);
            });

            modelBuilder.Entity<MaquinasRegistradoras>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Maquinas__06370DADCCDA364C");

                entity.ToTable("Maquinas_Registradoras");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Producto__06370DADAC04DD0F");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CFCBFCCF1");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => new { e.Cajero, e.Maquina, e.Producto });

                entity.HasOne(d => d.CajeroNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Cajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__Cajero__3C69FB99");

                entity.HasOne(d => d.MaquinaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Maquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__Maquina__3D5E1FD2");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__Producto__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
