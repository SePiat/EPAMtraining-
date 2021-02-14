using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;

namespace SalesReportConverter.DAL_.Repositories.ConcreteRepositories
{
    public class BuyingRepository : Repository<Buying>
    {
        public BuyingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
