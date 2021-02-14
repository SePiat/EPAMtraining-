using SalesReportConverter.Model_.Models;
using System;
using System.Threading.Tasks;

namespace SalesReportConverter.DAL.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Buyer> Buyers { get; }
        IGenericRepository<Buying> Buyings { get; }
        IGenericRepository<Manager> Managers { get; }
        IGenericRepository<Product> Products { get; }
        void Save();       

    }
}
