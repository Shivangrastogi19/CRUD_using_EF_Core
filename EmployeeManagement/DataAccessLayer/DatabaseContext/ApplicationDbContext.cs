using Microsoft.EntityFrameworkCore;
using Model;

namespace Data.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee>Employees { get; set; }
    }
}
