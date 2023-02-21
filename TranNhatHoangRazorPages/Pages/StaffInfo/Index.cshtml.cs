using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;

namespace TranNhatHoangRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private StaffRepository StaffRepository;

        public IndexModel()
        {
        }
        [BindProperty]
        public IList<StaffAccount> StaffAccount { get;set; }

        public async Task OnGetAsync()
        {
            StaffRepository = new StaffRepository();
            StaffAccount = StaffRepository.GetAll().ToList();
        }
    }
}
