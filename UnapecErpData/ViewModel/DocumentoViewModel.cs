namespace UnapecErpData.ViewModel
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public string Numero { get; set; }
        public string Factura { get; set; }
        public string Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }
    }
}