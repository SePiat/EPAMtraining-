using SalesReportConverter.DAL_.Context;
using SalesReportConverter.DAL_.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;

namespace SalesReportConverter.DAL_.Repositories.ConcreteRepositories
{
    public class BuyerRepository : Repository<Buyer>
    {
        public BuyerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
