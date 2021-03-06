﻿using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using System;
using System.Threading.Tasks;

namespace SalesReportConverter.DAL.Repositories
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
                    Buyers.Dispose();
                    Buyings.Dispose();
                    Managers.Dispose();
                    Products.Dispose();
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
