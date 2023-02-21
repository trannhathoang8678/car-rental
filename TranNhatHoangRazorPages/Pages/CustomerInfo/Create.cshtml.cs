using System;
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
    public class CreateModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        public CreateModel()
        {
            _customerRepository = new CustomerRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
            _customerRepository.Add(Customer);
            ViewData["Message"] = "Create customer account successfully!";
            return RedirectToPage("./Index");
        }
    }
}