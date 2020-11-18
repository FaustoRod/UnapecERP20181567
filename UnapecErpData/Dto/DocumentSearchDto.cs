using System;

namespace UnapecErpData.Dto
{
    public class DocumentSearchDto
    {

        public int ProveedorId { get; set; }
        public string Numero { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int EstadoDocumentoId { get; set; }
    }
}