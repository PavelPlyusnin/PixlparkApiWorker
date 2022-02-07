using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Pixlpark.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixlpark.Pages
{
    public class IndexModel : PageModel
    {
        private PixlparkAPIWorker pixlparkApi;

        public IndexModel(PixlparkAPIWorker pixlparkApi) 
        {
            this.pixlparkApi = pixlparkApi;
        }

        [BindProperty]
        public IList<Order> Orders { get; set; }

        public async Task<IActionResult> OnGetAsync() {
            Orders = await pixlparkApi.GetOrders();

            if (Orders == null) {
                return NotFound();
            }

            return Page();
        }

    }
}
