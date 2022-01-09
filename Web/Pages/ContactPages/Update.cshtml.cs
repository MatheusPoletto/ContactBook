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
    public class UpdateModel : PageModel
    {
        private readonly IRepository<Contact> repository;

        public UpdateModel(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Contact contact { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            contact = await repository.ReadAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await repository.UpdateAsync(contact);
                return RedirectToPage("Index", new { id = 1 });
            }

            return Page();
        }
    }
}
