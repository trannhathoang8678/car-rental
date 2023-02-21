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
    public class DeleteModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;

        public DeleteModel()
        {
            _customerRepository = new CustomerRepository();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
