using SalesReportConverter.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<T> AsQueryable()
        {
            return table.AsQueryable();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public T FirstOrDefault(IEnumerable<T> obj)
        {
            return obj.FirstOrDefault();
        }

        public T FirstOrDefault_(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return table.FirstOrDefault(predicate);
        }


        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public void Add(T obj)
        {
            table.Add(obj);
        }      

        public void AddRange(IEnumerable<T> objects)
        {
            table.AddRange(objects);
        }       

        public List<T> ToList()
        {
            return table.ToList();
        }

        public async Task<List<T>> ToListAsync()
        {
            return await table.ToListAsync();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<T> Where1(Func<T, bool> predicate)
        {

            return table.Where(predicate);
        }


        public IEnumerable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return table.Where(predicate);
        }

        public IEnumerable<T> OrderBy(Func<T, string> predicate)
        {
            return table.OrderBy(predicate);
        }

        public IEnumerable<T> OrderByDescending(Func<T, string> predicate)
        {
            return table.OrderByDescending(predicate);
        }

        public IEnumerable<T> Take(int count)
        {
            return table.Take(count);
        }

        public bool Contains(T obj)
        {
            if (table.Contains(obj))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ContainsAsync(T obj)
        {
            if (await table.ContainsAsync(obj))
            {
                return true;
            }
            return false;
        }

        public int Count()
        {
            return table.Count();
        }

        public async Task<int> CountAsync()
        {
            return await table.CountAsync();
        }

        public IEnumerable<T> Skip(int count)
        {
            return table.Skip(count);
        }

        public IQueryable<T> Include(string predicate)
        {
            return table.Include(predicate);
        }

        public void Remove(IEnumerable<T> range)
        {
            
            table.RemoveRange(range);
        }
    }
}
