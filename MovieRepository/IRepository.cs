using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieRentalRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAllAsQueryable();

        void Update(TEntity entity);

        void Detach(TEntity entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void StateTheChangeAsModified(TEntity entity);
    }
}