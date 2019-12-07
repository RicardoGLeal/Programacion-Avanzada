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
    public class CustomersModel : PageModel
    {

        public IList<Customer> Customers { get; set; }
        private Northwind db;
        public CustomersModel(Northwind injectedContext) { db = injectedContext; }

        public async Task OnGetAsync()
        {
            Customers = await db.Customers.OrderBy(x => x.Country)
                .ToListAsync();

            ViewData["Title"] = "Northwind Web Site - Customers";
        }
    }
}