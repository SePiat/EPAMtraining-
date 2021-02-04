using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model.Models;

namespace SalesReportConverter.DAL.Repositories.ConcreteRepositories
{
    public class BuyingRepository : Repository<Buying>
    {
        public BuyingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
