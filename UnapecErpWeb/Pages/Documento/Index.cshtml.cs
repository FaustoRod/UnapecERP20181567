using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnapecErpData.ViewModel;

namespace UnapecErpWeb.Pages.Documento
{
    public class IndexModel : PageModel
    {

        public IList<DocumentoViewModel> Documento { get;set; }

        public async Task OnGetAsync()
        {
        }
    }
}
