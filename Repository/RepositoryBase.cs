using Entities;
using Contracts;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public DataContext DataContext { get; set; }

        public RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return DataContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DataContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }
    }
}
