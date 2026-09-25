using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ServiceDeskContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginModel(ServiceDeskContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter your username and password.";
                return Page();
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Username == Username);

            if (user == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                Password);

            if (result == PasswordVerificationResult.Failed)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            return RedirectToPage("/Dashboard");
        }
    }
}