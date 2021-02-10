using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
       


        public void Add(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> expressionFilter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return expressionFilter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(expressionFilter).ToList();
            }
        }

        public Brand GetById(System.Linq.Expressions.Expression<Func<Brand, bool>> expressionFilter)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }
    }
}
