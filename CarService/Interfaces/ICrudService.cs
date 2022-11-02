using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarService.Interfaces
{
    public interface ICrudService<T>
        where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWhere(Expression<Func<T, bool>> where);
        T Insert(T model);
        T Update(T model);
        bool Delete(int id);
    }
}