using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Paging
{
    public class ContactList
    {
        public IEnumerable<Contact> contacts { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}
