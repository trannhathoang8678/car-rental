
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Microsoft.Extensions.Logging;

namespace TranNhatHoangRazorPages.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost(string loginType)
        {
            _logger.LogInformation("OnPost method called with loginType: {loginType}", loginType);

            if (loginType == "staff")
            {
                var staffAccount = checkStaffAccount();
                if (staffAccount != null)
                {
                    HttpContext.Session.SetString("Username", Username);
                    HttpContext.Session.SetString("Role", staffAccount.Role == 2 ? "staff" : "admin");
                    _logger.LogInformation("Staff login successful. Redirecting to /StaffInfo/Index.");
                    return RedirectToPage("/StaffInfo/Index");
                }
            }
            else
            {
                var customer = checkCustomerAccount();
                if (customer != null)
                {
                    HttpContext.Session.SetString("Username", Username);
                    HttpContext.Session.SetString("Role", "customer");
                    _logger.LogInformation("Customer login successful. Redirecting to /CustomerInfo/Index.");
                    return RedirectToPage("/CustomerInfo/Index");
                }
            }
            ErrorMessage = "Invalid username or password.";
            _logger.LogInformation("Login failed. Returning to login page.");
            return Page();
        }

        private StaffAccount checkStaffAccount()
        {
            _logger.LogInformation("Checking staff account for username: {Username}", Username);

            StaffRepository staffRepository = new StaffRepository();
            return staffRepository.Login(Username, Password);
        }

        private Customer checkCustomerAccount()
        {
            _logger.LogInformation("Checking customer account for username: {Username}", Username);

            CustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.Login(Username, Password);
        }
    }
}
