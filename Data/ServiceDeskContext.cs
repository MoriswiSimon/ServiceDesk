using Microsoft.EntityFrameworkCore;
using ServiceDesk.Models;

namespace ServiceDesk.Data
{
    public class ServiceDeskContext : DbContext
    {
        public ServiceDeskContext(DbContextOptions<ServiceDeskContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}