using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnapecErpData.Model
{
    public class Documento:BaseModel
    {
        public int ProveedorId { get; set; }
        [MaxLength(8)]
        [Required]
        public string Numero { get; set; }
        [Required]
        [MaxLength(8)]
        public string NumeroFactura { get; set; }
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Monto { get; set; }
        public int EstadoDocumentoId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual EstadoDocumento EstadoDocumento { get; set; }
    }
}