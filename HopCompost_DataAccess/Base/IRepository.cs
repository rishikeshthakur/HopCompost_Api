using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HopCompost_Common.Misc;

namespace HopCompost_DataAccess.Base
{
        public interface IRepository<TEntity>
           where TEntity : class
        {
            bool Any(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            int Count(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            int Count(params Expression<Func<TEntity, object>>[] includeProperties);

            IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

            IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            TEntity Single(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            TEntity First(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where,
                params Expression<Func<TEntity, object>>[] includeProperties);

            TEntity NewObject();

            void Add(TEntity entity);

            void Remove(TEntity entity);

            void Modify(TEntity entity);

            ResultAndMessage TryToSaveChanges();
        }

}