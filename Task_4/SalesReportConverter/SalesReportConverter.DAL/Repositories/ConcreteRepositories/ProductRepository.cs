using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;

namespace SalesReportConverter.DAL_.Repositories.ConcreteRepositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
