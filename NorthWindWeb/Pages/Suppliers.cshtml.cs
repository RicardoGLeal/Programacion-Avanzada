using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindContextLib;
using Microsoft.AspNetCore.Mvc;
using NorthwindEntitiesLib;

namespace NorthWindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<String> Suppliers { get; set; }
        private Northwind db;
        public SuppliersModel(Northwind injectedContext) { db = injectedContext; }
        [BindProperty] public Supplier Supplier { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            //Suppliers = new[] { "Alpha Co", "Beta Limited", "Gamma Corp" };
            Suppliers = db.Suppliers.Select(s => s.CompanyName).ToArray();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}