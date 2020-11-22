using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnapecErpWeb.Pages.Proveedor
{
    public class IndexModel : PageModel
    {
        private readonly UnapecErpWeb.Data.UnapecErpWebContext _context;

        public IndexModel(UnapecErpWeb.Data.UnapecErpWebContext context)
        {
            _context = context;
        }

        public IList<UnapecErpData.Model.Proveedor> Proveedor { get;set; }

        public async Task OnGetAsync()
        {
        }
    }
}
