using HealthCheckSample.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthCheckSample
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
