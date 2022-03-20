using Managment_Services_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment_Services_API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {
        }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<TypeOfServices> TypeOfServices { get; set; }
    }
}
