using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpData.Model;

namespace UnapecErpWeb.Data
{
    public class UnapecErpWebContext : DbContext
    {
        public UnapecErpWebContext (DbContextOptions<UnapecErpWebContext> options)
            : base(options)
        {
        }

        public DbSet<UnapecErpData.Model.ConceptoPago> ConceptoPago { get; set; }

        public DbSet<UnapecErpData.Model.Proveedor> Proveedor { get; set; }

        public DbSet<UnapecErpData.Model.Documento> Documento { get; set; }
    }
}
