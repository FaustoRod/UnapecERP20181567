using System;
using System.ComponentModel.DataAnnotations;

namespace UnapecErpData.Dto
{
    public class DocumentSearchDto
    {
        public DocumentSearchDto()
        {
            FechaHasta = DateTime.Today;
            FechaDesde = DateTime.Today.AddDays(-30);
        }
        public int ProveedorId { get; set; }
        public string Numero { get; set; }
        [Display(Name = "No. Factura")]
        public string NumeroFactura { get; set; }
        [Display(Name = "Desde")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaDesde { get; set; }
        [Display(Name = "Hasta")]
        public DateTime FechaHasta { get; set; }
        [Display(Name = "Estado")]
        public int EstadoDocumentoId { get; set; }
    }
}