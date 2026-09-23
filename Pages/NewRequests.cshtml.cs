using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Pages
{
    public class NewRequestModel : PageModel
    {
        private readonly ServiceDeskContext _context;

        public NewRequestModel(ServiceDeskContext context)
        {
            _context = context;
        }

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
            var request = new ServiceRequest
            {
                RequestTitle = RequestTitle,
                Category = Category,
                Priority = Priority,
                SubmittedBy = SubmittedBy,
                Description = Description,
                Status = "Open",
                DateSubmitted = DateTime.Now
            };

            _context.ServiceRequests.Add(request);
            _context.SaveChanges();

            return RedirectToPage("/Requests");
        }
    }
}