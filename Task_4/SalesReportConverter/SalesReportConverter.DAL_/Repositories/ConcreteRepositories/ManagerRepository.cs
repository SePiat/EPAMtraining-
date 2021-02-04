using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model.Models;

namespace SalesReportConverter.DAL.Repositories.ConcreteRepositories
{
    public class ManagerRepository : Repository<Manager>
    {
        public ManagerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
