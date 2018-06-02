using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Schedule
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        void Delete(TEntity item);
        void Update(TEntity item);
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity[] GetArray()
        {
            return _dbSet.ToArray();
        }

        public int Length
        {
            get
            {
                return _dbSet.Count();
            }
        }

        public TEntity this[int index]
        {
            get
            {
                if (index > 0 && index < _dbSet.Count())
                    return _dbSet.ElementAt(index);
                else
                    return _dbSet.ElementAt(0);
            }
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public bool DeleteAt(int index)
        {
            if (index > 0 && index < _dbSet.Count())
            {
                _dbSet.Remove(_dbSet.ElementAt(index));
                return true;
            }else
            {
                return false;
            }
        }
        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
