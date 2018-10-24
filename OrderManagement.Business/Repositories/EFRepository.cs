using OrderManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private OrderManagementContext _context;
        private DbSet<T> _dbSet;

        public EFRepository(OrderManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(object Id)
        {
            T entityToDelete = _dbSet.Find(Id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached) //Concurrency için 
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
        }

        public virtual T FindById(object Id)
        {
            return _dbSet.Find(Id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }
            return _dbSet;
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
