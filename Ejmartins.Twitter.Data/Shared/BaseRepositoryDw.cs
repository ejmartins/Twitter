using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Data.Shared
{
    public class BaseRepositoryDw<TEntity> : IDisposable, IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DatabaseContextDW _dbContext;
        public BaseRepositoryDw(DatabaseContextDW dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Add(entity);
        }

        public void CreateAll(List<TEntity> entity)
        {
            _dbContext
                .Set<TEntity>()
                .AddRange(entity);
        }

        public void Delete(int id)
        {
            _dbContext
                .Set<TEntity>()
                .Where(_ => _.Id == id)
                .ToList()
                .ForEach(_ => _dbContext.Set<TEntity>()
                    .Remove(_));
        }

        public void DeleteAll()
        {
            _dbContext
                .Set<TEntity>()
                .ToList()
                .ForEach(_ => _dbContext.Set<TEntity>()
                    .Remove(_));
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(_ => _.Id == id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
