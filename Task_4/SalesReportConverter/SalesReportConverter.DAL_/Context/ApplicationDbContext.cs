using SalesReportConverter.Model_.Models;
using System.Data.Entity;

namespace SalesReportConverter.DAL_.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DbConnection")
        {            
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
