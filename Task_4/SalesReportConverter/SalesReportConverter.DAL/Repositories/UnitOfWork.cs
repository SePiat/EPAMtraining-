using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model.Models;
using System;
using System.Threading.Tasks;

namespace SalesReportConverter.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Buyer> buyersRepository;
        private IGenericRepository<Buying> buyingsRepository;
        private IGenericRepository<Manager> managersRepository;
        private IGenericRepository<Product> productsRepository;

        public IGenericRepository<Buyer> Buyers
        {
            get
            {
                if (buyersRepository == null)
                {
                    buyersRepository = new Repository<Buyer>(_context);
                }
                return buyersRepository;
            }
        }
        public IGenericRepository<Buying> Buyings
        {
            get
            {
                if (buyingsRepository == null)
                {
                    buyingsRepository = new Repository<Buying>(_context);
                }
                return buyingsRepository;
            }
        }
        public IGenericRepository<Manager> Managers
        {
            get
            {
                if (managersRepository == null)
                {
                    managersRepository = new Repository<Manager>(_context);
                }
                return managersRepository;
            }
        }
        public IGenericRepository<Product> Products
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new Repository<Product>(_context);
                }
                return productsRepository;
            }
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
