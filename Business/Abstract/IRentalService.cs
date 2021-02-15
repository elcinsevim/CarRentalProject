using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(Rentals rentals);
        IResult Delete(Rentals rental);
        IResult Update(Rentals rental);
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetById(int id);
        IDataResult<List<CarDetailDto>> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null);
    }
}

   