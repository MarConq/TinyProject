using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyData.Repositories;
using TinyModel;
using TinyModel.Context;

namespace TinyData
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly LocalDbContext _context;
        protected DbSet<T> dbSet;
        public BaseRepository(LocalDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> Find(Func<T, bool> p)
        {
            return dbSet.Where(p);
        }
        public T GetById(int id)
        {
            return dbSet.SingleOrDefault(s => s.Id == id);
        }
        public T Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            
            dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }
        public int Delete(int id)
        {
            if (GetById(id) == null) throw new ArgumentNullException("entity");

            T entity = dbSet.SingleOrDefault(s => s.Id == id);
            dbSet.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
