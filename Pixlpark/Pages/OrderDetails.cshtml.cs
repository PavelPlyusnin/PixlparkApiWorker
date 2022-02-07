using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Pixlpark.Models;

namespace Pixlpark.Pages
{
    public class OrderDetailsModel : PageModel {

        private PixlparkAPIWorker pixlparkApi;

        public OrderDetailsModel(PixlparkAPIWorker pixlparkApi) {
            this.pixlparkApi = pixlparkApi;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            List<Order> orders = await pixlparkApi.GetOrders();
            if (orders == null)
            {
                return NotFound();
            }

            Order = orders.SingleOrDefault(order => order.Id.Equals(id));
            if (Order == null) {
                return NotFound();
            }
            return Page();
        }

        public Order Order { get; set; }

    }
}
