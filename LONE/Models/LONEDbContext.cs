using LONE.Entities;
using Microsoft.EntityFrameworkCore;

namespace LONE.Models
{
    public class LONEDbContext : DbContext
    {
        public LONEDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}

