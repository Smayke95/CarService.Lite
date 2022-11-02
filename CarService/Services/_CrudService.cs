using CarService.Interfaces;
using CarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarService.Services
{
    public class CrudService<T> : ICrudService<T>
        where T : class, new()
    {
        public virtual T Get(int id)
        {
            using (var context = new CSContext())
            {
                var isNew = id == 0;

                if (!isNew)
                {
                    var entity = context
                        .Set<T>()
                        .Find(id);

                    return entity ?? new T();
                }

                return new T();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var context = new CSContext())
            {
                return context
                    .Set<T>()
                    .ToList();
            }
        }

        public virtual IEnumerable<T> GetAllWhere(Expression<Func<T, bool>> where)
        {
            using (var context = new CSContext())
            {
                return context
                    .Set<T>()
                    .Where(where)
                    .ToList();
            }
        }

        public virtual T Insert(T model)
        {
            using (var context = new CSContext())
            {
                var addedEntity = context
                    .Set<T>()
                    .Add(model);

                context.SaveChanges();

                return addedEntity.Entity;
            }
        }

        public virtual T Update(T model)
        {
            using (var context = new CSContext())
            {
                var updatedEntity = context
                    .Set<T>()
                    .Update(model);

                context.SaveChanges();

                return updatedEntity.Entity;
            }
        }

        public virtual bool Delete(int id)
        {
            using (var context = new CSContext())
            {
                var entity = context
                    .Set<T>()
                    .Find(id);

                if (entity == null)
                    return false;

                context.Set<T>().Remove(entity);
                context.SaveChanges();

                return true;
            }
        }
    }
}