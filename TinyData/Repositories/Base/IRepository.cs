using System;
using System.Collections.Generic;
using TinyModel;

namespace TinyData.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> p);
        T GetById(int id);
        T Insert(T entity);
        T Update(T entity);
        int Delete(int id);
    }
}
