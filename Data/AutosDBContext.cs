using AutosSOAP.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AutosSOAP.Data
{
    public class AutosDBContext : DbContext
    {
        public AutosDBContext(DbContextOptions<AutosDBContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;

        public DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250);

                entity.Property(e => e.Estado)
                    .IsRequired();
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo);

                entity.Property(e => e.IdVehiculo)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasIndex(e => e.Placa)
                    .IsUnique();

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Anio)
                    .IsRequired();

                entity.Property(e => e.Precio)
                    .IsRequired();

                entity.Property(e => e.Estado)
                    .IsRequired();

                entity.Property(e => e.IdCategoria)
                    .IsRequired();

                entity.HasOne(e => e.Categoria)
                    .WithMany(c => c.Vehiculos)
                    .HasForeignKey(e => e.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}