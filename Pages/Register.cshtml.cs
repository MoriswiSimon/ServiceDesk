using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ServiceDeskContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public RegisterModel(ServiceDeskContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [BindProperty]
        public string FullName { get; set; } = "";

        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        [BindProperty]
        public string ConfirmPassword { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "Please complete all fields.";
                return Page();
            }

            if (Password.Length < 6)
            {
                ErrorMessage = "Password must be at least 6 characters.";
                return Page();
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return Page();
            }

            if (_context.Users.Any(u => u.Username == Username))
            {
                ErrorMessage = "Username already exists.";
                return Page();
            }

            var user = new User
            {
                FullName = FullName,
                Username = Username,
                Role = "User"
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToPage("/Login");
        }
    }
}