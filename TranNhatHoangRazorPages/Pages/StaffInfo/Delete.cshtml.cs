using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;

namespace TranNhatHoangRazorPages.Pages.StaffInfo
{
    public class DeleteModel : PageModel
    {
        private StaffRepository staffRepository;

        public DeleteModel()
        {
            staffRepository = new StaffRepository();
        }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffAccount = staffRepository.GetById(id);
            if (StaffAccount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffAccount = staffRepository.GetById(id);

            if (StaffAccount != null)
            {
                staffRepository.Delete(StaffAccount);
            }

            return RedirectToPage("./Index");
        }
    }
}
