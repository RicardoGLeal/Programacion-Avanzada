using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindEntitiesLib;

namespace NorthWindWeb.Pages
{
    public class CustomerInfoModel : PageModel
    {
        public Northwind db;
        public CustomerInfoModel(Northwind injectedContext) { db = injectedContext; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; }


        #region snippet
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await db.Customers
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.CustomerID == id);

            Orders = db.Orders.Where(c => c.CustomerID == id).ToList();
            Console.WriteLine("");

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
