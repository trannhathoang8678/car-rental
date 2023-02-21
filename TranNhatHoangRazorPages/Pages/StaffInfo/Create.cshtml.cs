using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Repository;

namespace TranNhatHoangRazorPages.Pages.StaffInfo
{
    public class CreateModel : PageModel
    {
        private StaffRepository staffRepository;


        public CreateModel()
        {
            staffRepository = new StaffRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var dataValidation = new DataValidation();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!dataValidation.IsValidEmail(StaffAccount.Email))
            {
                ModelState.AddModelError("StaffAccount.Email", "Invalid email address.");
                return Page();
            }

            staffRepository.Add(StaffAccount);
            ViewData["Message"] = "Create staff account successfully!";
            return RedirectToPage("./Index");
        }
    }
}
