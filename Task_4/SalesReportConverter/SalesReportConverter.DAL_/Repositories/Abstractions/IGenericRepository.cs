using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesReportConverter.DAL_.Repositories.Abstractions
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {


         void Delete(object id);

        T FirstOrDefault(Func<T, bool> predicate);        

        void Add(T obj);        

        void Update(T obj);       

        bool Contains(T obj);              

        void Remove(IEnumerable<T> range);
        List<T> ToList();




    }
}
