using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;
using Microsoft.AspNetCore.Http;

namespace TranNhatHoangRazorPages.Pages.StaffInfo
{
    public class EditModel : PageModel
    {
        private StaffRepository StaffRepository;

        public EditModel()
        {
            StaffRepository = new StaffRepository();
        }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
           if (id == null)
            {
                return Redirect("/Error/AuthorizedError");
            }
            else if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Redirect("/Error/AuthorizedError"); ;
            }
            else
            {
                StaffAccount = StaffRepository.GetById(id);
                ViewData["Pass"] = StaffAccount.Password;

                if (StaffAccount == null)
                {
                    return Redirect("/Error/AuthorizedError");
                }
                return Page();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            StaffRepository = new StaffRepository();

            ViewData["Pass"] = StaffAccount.Password;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Redirect("/Error/AuthorizedError"); ;
            }
            else
            {
                    StaffRepository.Update(StaffAccount);
                    return RedirectToPage("./Index");
            }

            
        }

    }
}
