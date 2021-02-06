using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


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
                    ? context.Color.ToList()
                    : context.Color.Where(expressionFilter).ToList();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> expressionFilter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Color.SingleOrDefault(expressionFilter);
            }
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
