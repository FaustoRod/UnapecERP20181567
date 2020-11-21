using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UnapecErpData.Model;

namespace UnapecErpWeb.Pages.Concepto
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {
        }

        public IList<ConceptoPago> ConceptoPago { get;set; }

        public async Task OnGetAsync()
        {
        }
    }
}
