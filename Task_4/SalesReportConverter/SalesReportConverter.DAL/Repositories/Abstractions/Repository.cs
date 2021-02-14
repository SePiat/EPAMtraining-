
using SalesReportConverter.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace SalesReportConverter.DAL.Repositories.Abstractions

{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<T> table;

        public Repository(ApplicationDbContext dbContext)
        {
            context = dbContext;
            table = context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return table.FirstOrDefault(predicate);
        }

        public void Add(T obj)
        {
            if (obj == null) throw new ArgumentNullException("entity");
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }

        public bool Contains(T obj)
        {
            if (table.Contains(obj))
            {
                return true;
            }
            return false;
        }

        public void Remove(IEnumerable<T> range)
        {
            table.RemoveRange(range);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
