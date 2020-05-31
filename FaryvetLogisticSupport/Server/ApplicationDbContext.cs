using FaryvetLogisticSupport.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaryvetLogisticSupport.Server
{
    /// <summary>
    /// Clase ApplicationDbContext.
    /// Puente entre las entidades y la base de datos.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor de la clase ApplicationDbContext
        /// </summary>
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Sobreescritura del metodo OnModelCreating().
        /// El metodo creará las tablas en la base de datos en el schema FARYVET
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FARYVET");
        }

        /// <value>Get y Set del atributo FLS_Conductores</value>
        public DbSet<Conductor> FLS_Conductores { get; set; }

        /// <value>Get y Set del atributo FLS_DivisionesGeograficas</value>
        public DbSet<DivisionGeografica> FLS_DivisionesGeograficas { get; set; }

        /// <value>Get y Set del atributo FLS_Entregas</value>
        public DbSet<Entrega> FLS_Entregas { get; set; }

        /// <value>Get y Set del atributo FLS_Facturas</value>
        public DbSet<Factura> FLS_Facturas { get; set; }

        /// <value>Get y Set del atributo FLS_Vehiculos</value>
        public DbSet<Vehiculo> FLS_Vehiculos { get; set; }
    }
}
