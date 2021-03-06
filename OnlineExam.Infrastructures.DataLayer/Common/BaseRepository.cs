﻿using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core;
using System.Linq;

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
            //dbContext.Dispose();

            return dbContext.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return entity;

        }
    }
}
