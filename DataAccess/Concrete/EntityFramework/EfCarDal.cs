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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> expressionFilter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return expressionFilter == null
                        ? context.Set<Car>().ToList()
                        : context.Set<Car>().Where(expressionFilter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> expressionFilter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Car>().SingleOrDefault(expressionFilter);
            }

        }

        public void Update(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }
    }
}