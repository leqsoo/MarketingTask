using Microsoft.EntityFrameworkCore;

namespace MarketingTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<DistributorSales> DistributorSales { get; set; }
    }
}
