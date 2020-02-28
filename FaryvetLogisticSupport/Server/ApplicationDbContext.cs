using FaryvetLogisticSupport.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaryvetLogisticSupport.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FARYVET");
        }

        public DbSet<Conductor> FLS_Conductores { get; set; }
        public DbSet<DivisionGeografica> FLS_DivisionesGeograficas { get; set; }
        public DbSet<Entrega> FLS_Entregas { get; set; }
        public DbSet<Factura> FLS_Facturas { get; set; }
        public DbSet<Vehiculo> FLS_Vehiculos { get; set; }
    }
}
