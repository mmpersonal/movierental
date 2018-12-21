using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MovieRentalRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _dbSet { get; set; }

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DBContext is required to use this repository", "context");
            }
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            DbEntityEntry entry = this._context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _context.Set<TEntity>().Add(entity);
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }


        public void Update(TEntity entity)
        {
            DbEntityEntry entry = this._context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this._dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
        public void Detach(TEntity entity)
        {
            DbEntityEntry entry = this._context.Entry(entity);

            entry.State = EntityState.Detached;
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity GetByID(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void StateTheChangeAsModified(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

        }
    }
}
