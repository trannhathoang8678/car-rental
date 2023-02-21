using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Repository;

namespace TranNhatHoangRazorPages.Pages.CustomerInfo
{
    public class EditModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;

        public EditModel()
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

            Customer = _customerRepository.GetById(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dataValidation = new DataValidation();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!dataValidation.IsValidEmail(Customer.CustomerEmail))
            {
                ModelState.AddModelError("Customer.CustomerEmail", "Invalid email address.");
                return Page();
            }

            if (!dataValidation.IsAllDigits(Customer.IdentityCard) || (Customer.IdentityCard.Length != 9 && Customer.IdentityCard.Length != 12))
            {
                ModelState.AddModelError("Customer.IdentityCard", "Identity card number is not valid.");
                return Page();
            }

            if (!dataValidation.IsAllDigits(Customer.LicenceNumber))
            {
                ModelState.AddModelError("Customer.LicenceNumber", "Licence number is not valid.");
                return Page();
            }

            if (!dataValidation.IsAllDigits(Customer.Mobile) || Customer.Mobile.Length != 10)
            {
                ModelState.AddModelError("Customer.Mobile", "Mobile number is not valid.");
                return Page();
            }

            _customerRepository.Update(Customer);
            ViewData["Message"] = "Update customer account successfully!";
            return RedirectToPage("./Index");
        }
    }
}