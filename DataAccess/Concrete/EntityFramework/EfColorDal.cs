using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
            }
        }

        public void Delete(Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> expressionFilter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return expressionFilter == null
                    ? context.Colors.ToList()
                    : context.Colors.Where(expressionFilter).ToList();
            };
        }



        public void Update(Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }
    }
}