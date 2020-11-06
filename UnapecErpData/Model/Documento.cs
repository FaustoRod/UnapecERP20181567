using System.ComponentModel.DataAnnotations;

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
        public decimal Monto { get; set; }
        public int EstadoDocumentoId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual EstadoDocumento EstadoDocumento { get; set; }
    }
}