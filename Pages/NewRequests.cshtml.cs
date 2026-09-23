using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceDesk.Pages
{
    public class NewRequestModel : PageModel
    {
        [BindProperty]
        public string RequestTitle { get; set; } = "";

        [BindProperty]
        public string Category { get; set; } = "";

        [BindProperty]
        public string Priority { get; set; } = "";

        [BindProperty]
        public string SubmittedBy { get; set; } = "";

        [BindProperty]
        public string Description { get; set; } = "";

        public IActionResult OnPost()
        {
            return RedirectToPage("/Requests");
        }
    }
}