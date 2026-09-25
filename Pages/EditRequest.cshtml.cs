using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Pages
{
    public class EditRequestModel : PageModel
    {
        private readonly ServiceDeskContext _context;

        public EditRequestModel(ServiceDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceRequest Request { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            Request = request;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var request = await _context.ServiceRequests.FindAsync(Request.Id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = Request.Status;
            request.AssignedTo = Request.AssignedTo;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Requests");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var request = await _context.ServiceRequests.FindAsync(Request.Id);

            if (request == null)
            {
                return NotFound();
            }

            _context.ServiceRequests.Remove(request);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Requests");
        }
    }
}