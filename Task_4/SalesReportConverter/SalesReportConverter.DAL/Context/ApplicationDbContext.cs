using SalesReportConverter.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace SalesReportConverter.DAL.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base("DbConnection")
        { }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }       

    }
}
