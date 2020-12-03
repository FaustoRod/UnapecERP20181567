using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnapecErpData.Model
{
    public class Documento:BaseModel
    {
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }
        [MaxLength(8)]
        [Required]
        public string Numero { get; set; }
        [Required]
        [MaxLength(8)]
        [Display(Name = "No. Factura")]
        public string NumeroFactura { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Monto { get; set; }
        public int EstadoDocumentoId { get; set; }
        public int? AsientoContableIdNumero { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual EstadoDocumento EstadoDocumento { get; set; }
    }
}