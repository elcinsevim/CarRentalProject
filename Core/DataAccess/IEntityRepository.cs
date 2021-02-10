﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
   public interface IEntityRepository<T> where T:class,IEntity,new ()
   
    {
        List<T> GetAll(Expression<Func<T, bool>> expressionFilter = null);

        List<T> Get(Func<object, bool> p);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
