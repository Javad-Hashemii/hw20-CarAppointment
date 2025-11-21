using CarAppointment.Core.Services;
using CarAppointment.Domain.Core.AdminAgg.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarAppointment.Presentation.RazorPages.Pages.Authentication
{
    public class LoginModel(IAdminService adminService) : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var admin = adminService.Login(Username, Password);

            if (admin == null)
            {
                ErrorMessage = "نام کاربری یا کلمه عبور اشتباه است";
                return Page();
            }

            return RedirectToPage("/Admin/AdminPanel");
        }

    }
}
