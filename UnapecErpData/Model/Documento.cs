namespace UnapecErpData.Model
{
    public class Documento:BaseModel
    {
        public int ProveedorId { get; set; }
        public string Numero { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Monto { get; set; }
        public int EstadoDocumentoId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual EstadoDocumento EstadoDocumento { get; set; }
    }
}