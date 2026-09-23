using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceDesk.Data;

namespace ServiceDesk.Pages;

public class IndexModel : PageModel
{
    private readonly ServiceDeskContext _context;

    public IndexModel(ServiceDeskContext context)
    {
        _context = context;
    }

    public int OpenRequests { get; set; }
    public int InProgressRequests { get; set; }
    public int ResolvedRequests { get; set; }

    public void OnGet()
    {
        OpenRequests = _context.ServiceRequests.Count(r => r.Status == "Open");

        InProgressRequests = _context.ServiceRequests.Count(r => r.Status == "In Progress");

        ResolvedRequests = _context.ServiceRequests.Count(r => r.Status == "Resolved");
    }
}