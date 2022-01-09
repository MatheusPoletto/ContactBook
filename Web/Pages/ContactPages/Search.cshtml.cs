using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Entity;
using Web.Models;

namespace Web.Pages.ContactPages
{
    public class SearchModel : PageModel
    {
        private readonly IRepository<Contact> repository;

        public SearchModel(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Contact contact { get; set; }
        public List<Contact> contactList { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            Expression<Func<Contact, bool>> filter = c => c.Name == contact.Name;
            contactList = await repository.ReadAllAsync(filter);
            return Page();
        }

    }
}
