using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        public async Task OnGetAsync()
{
    var query = _context.ServiceRequests.AsQueryable();

    if (!string.IsNullOrWhiteSpace(SearchTerm))
    {
        query = query.Where(r =>
            r.RequestTitle.Contains(SearchTerm) ||
            r.Category.Contains(SearchTerm) ||
            r.SubmittedBy.Contains(SearchTerm) ||
            r.Status.Contains(SearchTerm));
    }

    Requests = await query
        .OrderByDescending(r => r.DateSubmitted)
        .ToListAsync();
}
    }
}