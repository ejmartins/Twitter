using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Data.Shared
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void CreateAll(List<TEntity> entity);

        void Update(TEntity entity);
        void Delete(int id);
        void DeleteAll();

        void SaveChanges();
    }
}
