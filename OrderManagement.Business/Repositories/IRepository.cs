using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Repositories
{
    public interface IRepository<T> where T : class
    {
        T FindById(object Id);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(object Id);
        void Delete(T Entity);
    }
}
