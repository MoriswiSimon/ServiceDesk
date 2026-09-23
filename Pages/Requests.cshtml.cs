using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Pages
{
    public class RequestsModel : PageModel
    {
        private readonly ServiceDeskContext _context;

        public RequestsModel(ServiceDeskContext context)
        {
            _context = context;
        }

        public List<ServiceRequest> Requests { get; set; } = new();

        public async Task OnGetAsync()
        {
            Requests = await _context.ServiceRequests
                .OrderByDescending(r => r.DateSubmitted)
                .ToListAsync();
        }
    }
}