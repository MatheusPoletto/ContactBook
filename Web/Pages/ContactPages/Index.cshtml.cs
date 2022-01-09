using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Entity;
using Web.Models;
using Web.Paging;

namespace Web.Pages.ContactPages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Contact> repository;

        public IndexModel(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        
        public ContactList contactList { get; set; }

        public async Task OnGet(int id)
        {
            //contactList = await repository.ReadAllAsync();
            contactList = new ContactList();

            int pageSize = 3;

            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = id == 0 ? 1 : id;
            pagingInfo.ItemsPerPage = pageSize;
            
            var skip = pageSize * (Convert.ToInt32(id) - 1);
            var resultTuple = await repository.ReadAllFilterAsync(skip, pageSize);            

            pagingInfo.TotalItems = resultTuple.Total;
            contactList.contacts = resultTuple.Lista;
            
            contactList.pagingInfo = pagingInfo;
            
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
            return RedirectToPage("Index", new { id = 1 });
        }
    }
}
