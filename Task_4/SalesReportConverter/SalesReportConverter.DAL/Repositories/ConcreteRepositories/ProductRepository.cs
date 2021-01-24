using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.DAL.Repositories.ConcreteRepositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
