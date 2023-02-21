using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Repository;

namespace TranNhatHoangRazorPages.Pages.CustomerInfo
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;

        public DetailsModel()
        {
            _customerRepository = new CustomerRepository();
        }
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            Customer = _customerRepository.GetById(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

