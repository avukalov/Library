using Library.DAL;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(LibraryDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        protected LibraryDbContext DbContext { get; private set; }

        public void Create(TEntity entity)
        {
            this.DbContext.Set<TEntity>().Add(entity);
        }

        void IGenericRepository<TEntity>.Delete(TEntity entity)
        {
            this.DbContext.Set<TEntity>().Remove(entity);
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.FindAll()
        {
            return this.DbContext.Set<TEntity>().AsNoTracking();
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        void IGenericRepository<TEntity>.Update(TEntity entity)
        {
            this.DbContext.Set<TEntity>().Update(entity);
        }
    }
}