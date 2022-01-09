using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Entity;
using Web.Models;

namespace Web.Pages.ContactPages
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Contact> repository;

        public CreateModel(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Contact contact { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(contact);
                return RedirectToPage("Index", new { id = 1 });
            }

            return Page();
        }
        
    }
}
