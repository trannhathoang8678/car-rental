using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;

namespace TranNhatHoangRazorPages.Pages.CustomerInfo
{
    public class IndexModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;

        public IndexModel()
        {
            _customerRepository = new CustomerRepository();
        }
        [BindProperty]
        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = _customerRepository.GetAll().ToList();
        }
    }
}
