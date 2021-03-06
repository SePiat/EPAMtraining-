﻿using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;

namespace SalesReportConverter.DAL_.Repositories.ConcreteRepositories
{
    public class ManagerRepository : Repository<Manager>
    {
        public ManagerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
