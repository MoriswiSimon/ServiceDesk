using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceDesk.Data;

namespace ServiceDesk.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ServiceDeskContext _context;

        public DashboardModel(ServiceDeskContext context)
        {
            _context = context;
        }

        public int OpenRequests { get; set; }
        public int InProgressRequests { get; set; }
        public int ResolvedRequests { get; set; }
        public int TotalRequests { get; set; }

        public void OnGet()
        {
            OpenRequests = _context.ServiceRequests.Count(r => r.Status == "Open");

            InProgressRequests = _context.ServiceRequests.Count(r => r.Status == "In Progress");

            ResolvedRequests = _context.ServiceRequests.Count(r => r.Status == "Resolved");

            TotalRequests = _context.ServiceRequests.Count();
        }
    }
}