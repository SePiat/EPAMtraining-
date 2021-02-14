using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;

namespace SalesReportConverter.DAL.Repositories.ConcreteRepositories
{
    public class BuyerRepository : Repository<Buyer>
    {
        public BuyerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
