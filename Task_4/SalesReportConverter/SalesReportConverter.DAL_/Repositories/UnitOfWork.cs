using SalesReportConverter.DAL_.Context;
using SalesReportConverter.DAL_.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using System;
using System.Threading.Tasks;

namespace SalesReportConverter.DAL_.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public IGenericRepository<Buyer> Buyers { get; }
        public IGenericRepository<Buying> Buyings { get;}
        public IGenericRepository<Manager> Managers { get; }
        public IGenericRepository<Product> Products{ get; }



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Buyers = new Repository<Buyer>(_context);
            Buyings = new Repository<Buying>(_context);
            Managers = new Repository<Manager>(_context);
            Products = new Repository<Product>(_context);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    Buyers.Dispose();
                    Buyings.Dispose();
                    Managers.Dispose();
                    Products.Dispose();                    
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();

        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
