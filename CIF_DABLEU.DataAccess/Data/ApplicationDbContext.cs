using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CIF_DABLEU.DataAccess/Data/ApplicationDbContext.cs
using CIF_DABLEU.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CIF_DABLEU.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Tablas de la base de datos
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aquí va la cadena de conexión a nuestra base de datos PostgreSQL
            // IMPORTANTE: Reemplaza 'tu_contraseña_segura' por la contraseña que estableciste para el usuario 'postgres'.
            var connectionString = "Host=localhost;Port=5432;Database=cif_dableu_db;Username=postgres;Password=maloserelmalo;";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para asegurar que el email del usuario sea único
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
