using System;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Repository.Common
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}