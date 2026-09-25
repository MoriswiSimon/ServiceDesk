using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Pages
{
    public class RequestDetailsModel : PageModel
    {
        private readonly ServiceDeskContext _context;

        public RequestDetailsModel(ServiceDeskContext context)
        {
            _context = context;
        }

        public ServiceRequest Request { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var request = await _context.ServiceRequests
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            Request = request;

            return Page();
        }
    }
}