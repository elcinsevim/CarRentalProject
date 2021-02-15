﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
        where TContext:DbContext,new()

    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> Get(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expressionFilter = null)
        {
            using (TContext context = new TContext())
            {
                return expressionFilter == null
                        ? context.Set<TEntity>().ToList()
                        : context.Set<TEntity>().Where(expressionFilter).ToList();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> expressionFilter)
        {
            throw new NotImplementedException();

        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}