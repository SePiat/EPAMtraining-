using SalesReportConverter.DAL_.Context;
using SalesReportConverter.DAL_.Repositories.Abstractions;
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
