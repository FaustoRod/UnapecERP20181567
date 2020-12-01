using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnapecErpData.Dto;
using UnapecErpData.ViewModel;

namespace UnapecErpWeb.Pages.Documento
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            DocumentoSearch = new DocumentSearchDto();
        }
        public IList<DocumentoViewModel> Documento { get;set; }
        public DocumentSearchDto DocumentoSearch { get;set; }

        public async Task OnGetAsync()
        {
        }
    }
}
