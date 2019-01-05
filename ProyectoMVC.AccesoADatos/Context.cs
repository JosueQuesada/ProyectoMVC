using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProyectoMVC.AccesoADatos
{
    public class Context:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Clientes>().ToTable("CLIENTES");
            modelBuilder.Entity<Model.Prestamos>().ToTable("PRESTAMOS");
            modelBuilder.Entity<Model.Vehiculo>().ToTable("VEHICULO");

        }
        public DbSet<Model.Clientes> Clientes { get; set; }
        public DbSet<Model.Prestamos> Prestamos { get; set; }
        public DbSet<Model.Vehiculo> Vehiculo { get; set; }
    }
}
