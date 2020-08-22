using Microsoft.EntityFrameworkCore.Infrastructure;
using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {

        private readonly OnlineExamDbContext dbContext;
        public BaseRepository(OnlineExamDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public TEntity Add(TEntity entity)
        {

            dbContext.Add(entity);

            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity { Id = id };
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }


        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
    }
}
