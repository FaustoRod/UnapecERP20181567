using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UnapecErpData.Model;

namespace UnapecErpApi.Context
{
    public class ErpDbContext:DbContext
    {
        public ErpDbContext(DbContextOptions<ErpDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data
            modelBuilder.Entity<TipoPersona>().HasData(new List<TipoPersona>()
            {
                new TipoPersona{Id = 1,Descripcion = "Fisica",FechaCreacion = DateTime.Now,FechaModificacion = DateTime.Now,Activo = true},
                new TipoPersona{Id = 2,Descripcion = "Juridica",FechaCreacion = DateTime.Now,FechaModificacion = DateTime.Now,Activo = true}
            });

            modelBuilder.Entity<EstadoDocumento>().HasData(new List<EstadoDocumento>()
            {
                new EstadoDocumento{Id = 1,Descripcion = "Pendiente",FechaCreacion = DateTime.Now,FechaModificacion = DateTime.Now,Activo = true},
                new EstadoDocumento{Id = 2,Descripcion = "Pagado",FechaCreacion = DateTime.Now,FechaModificacion = DateTime.Now,Activo = true}
            });


            #endregion
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ConceptoPago> ConceptoPago { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<EstadoDocumento> EstadoDocumentos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
    }
}