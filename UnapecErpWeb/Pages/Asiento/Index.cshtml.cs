using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnapecErpData.Dto;
using UnapecErpData.ViewModel;

namespace UnapecErpWeb.Pages.Asiento
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            DocumentoSearch = new DocumentSearchDto
            {
                FechaDesde = DateTime.Now.AddDays(-7),
                FechaHasta = DateTime.Now
            };
        }
        public IList<DocumentoViewModel> Documento { get;set; }
        public DocumentSearchDto DocumentoSearch { get; set; }
    }
}
