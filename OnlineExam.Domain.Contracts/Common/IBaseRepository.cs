using OnlineExam.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Domain.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
